using FundacionAMA.Domain.DTO.Person;
using FundacionAMA.Domain.DTO.Person.FilterDto;
using FundacionAMA.Domain.DTO.Person.Request;
using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Shared.Entities.Operation;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace FundacionAMA.Application.Services.PersonApp
{
    internal class PersonAppService : IPersonAppService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly IVolunteerRepository _volunteerRepository;

        public PersonAppService(IPersonRepository personRepository, IDonorRepository donorRepository, IVolunteerRepository volunteerRepository)
        {
            _personRepository = personRepository;
            _donorRepository = donorRepository;
            _volunteerRepository = volunteerRepository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<PersonRequest> entity)
        {
            try
            {
                if (await IsExitByIdentification(entity))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la person con identificación {entity.Data.Identification} ya existe");
                }
                entity.Data.GetNameCompleted();
                Person persona = entity.Data.MapTo<Person>();
                if (persona.Donor)
                {
                    persona.IdNavigation = new Donor()
                    {
                        Active = true,
                        PersonId = persona.Id,
                        Status = "A"
                    };
                }
                if (persona.Volunteer)
                {
                    if (entity.Data.volunaterRequest == null)
                    {
                        return new OperationResult(System.Net.HttpStatusCode.BadRequest,
                            $"Se debe proporcionar datos si es voluntario");
                    }
                    entity.Data.volunaterRequest.MapTo<Volunteer>();
                    persona.VolunteerNavigation = entity.Data.volunaterRequest.MapTo<Volunteer>();
                    persona.VolunteerNavigation.PersonId = persona.Id;

                }
                await _personRepository.InsertAsync(persona);
                await _personRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.Created, $"la person con identificación {entity.Data.Identification} se creo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }

        private async Task<bool> IsExitByIdentification(IOperationRequest<PersonRequest> entity)
        {
            return await _personRepository.ExistsAscyn(e => e.Active && e.Identification == entity.Data.Identification);
        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            try
            {
                Person? persona = await _personRepository.All.Where(e => e.Active && e.Id == id.Data).FirstOrDefaultAsync();
                if (persona == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la person con id {id.Data} no existe");
                }
                await _personRepository.DeleteAsync(persona);
                await _personRepository.SaveChangesAsync(id);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la person con id {id.Data} se elimino correctamente");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public Task<IOperationResultList<PersonDto>> GetAll(PersonFilter filter)
        {
            Task<IOperationResultList<PersonDto>> persona = _personRepository.All
                .Where(GetFilters(filter))

                .ToResultListAsync<Person, PersonDto>(Offset: filter.Offset, Take: filter.Take);

            return persona;
        }

        private static Expression<Func<Person, bool>> GetFilters(PersonFilter filter)
        {
            return e => e.Active &&
                (!filter.Volunteer.HasValue || e.Volunteer == filter.Volunteer.Value) &&
                (!filter.Donor.HasValue || e.Donor == filter.Donor.Value) &&
                (string.IsNullOrEmpty(filter.Identification) || e.Identification.Contains(filter.Identification)) &&
                (string.IsNullOrEmpty(filter.FirstName) || e.FirstName.Contains(filter.FirstName)) &&
                (string.IsNullOrEmpty(filter.Phone) || e.Phone.Contains(filter.Phone)) &&
                (string.IsNullOrEmpty(filter.LastName) || e.LastName.Contains(filter.LastName)) &&
                (string.IsNullOrEmpty(filter.Name) || e.FirstName.Contains(filter.Name) || e.SecondName.Contains(filter.Name) || e.LastName.Contains(filter.Name) || e.SecondLastName.Contains(filter.Name)) &&
                (string.IsNullOrEmpty(filter.Email) || e.Email.Contains(filter.Email));
        }

        public async Task<IOperationResult<PersonDto>> GetById(int id)
        {
            Person? persona = await _personRepository.All.Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
            return persona == null
                ? new OperationResult<PersonDto>(System.Net.HttpStatusCode.NotFound, $"la person con id {id} no existe")
                : await persona.ToResultAsync<Person, PersonDto>();
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<PersonRequest> entity)
        {
            try
            {
                Person? persona = await _personRepository.All
                    .Include(e => e.IdNavigation)
                    .Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
                if (persona == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la person con id {id} no existe");
                }
                if (await _personRepository.ExistsAscyn(e => e.Active && e.Id != id && e.Identification == entity.Data.Identification))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la person con identificación {entity.Data.Identification} ya existe");
                }
                entity.Data.GetNameCompleted();

                persona = entity.Data.MapTo<Person>(persona, entity.Data);
                if (persona.Donor)
                {
                    if (persona.IdNavigation == null)
                    {
                        await _donorRepository.InsertAsync(new Donor()
                        {
                            Active = true,
                            PersonId = persona.Id,
                            Status = "A"
                        });

                    }
                    else
                    {
                        persona.IdNavigation.Active = true;
                        persona.IdNavigation.PersonId = persona.Id;
                        persona.IdNavigation.Status = "A";
                    }

                }
                else
                {
                    if (persona.IdNavigation != null)
                    {
                        persona.IdNavigation.Active = false;
                    }

                }


                if (persona.Volunteer)
                {

                    if (persona.VolunteerNavigation == null)
                    {

                        if (entity.Data.volunaterRequest == null)
                        {
                            return new OperationResult(System.Net.HttpStatusCode.BadRequest,
                                $"Se debe proporcionar datos si es voluntario");
                        }
                        entity.Data.volunaterRequest.MapTo<Volunteer>();
                        Volunteer volunet = entity.Data.volunaterRequest.MapTo<Volunteer>();
                        volunet.PersonId = persona.Id;
                        await _volunteerRepository.InsertAsync(volunet);
                    }
                    else
                    {
                        if (entity.Data.volunaterRequest == null)
                        {
                            return new OperationResult(System.Net.HttpStatusCode.BadRequest,
                                $"Se debe proporcionar datos si es voluntario");
                        }

                        Volunteer volunterEntity = entity.Data.volunaterRequest.MapTo<Volunteer>();
                        volunterEntity.PersonId = persona.Id;
                        persona.VolunteerNavigation = volunterEntity;
                    }

                }
                else
                {
                    if (persona.VolunteerNavigation != null)
                    {
                        persona.VolunteerNavigation.Active = false;
                    }

                }

                if (persona.Beneficiary != null)
                {
                    persona.Beneficiary.PersonId = persona.Id;


                }
                await _personRepository.UpdateAsync(persona);
                await _personRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la person con id {id} se actualizo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }
    }
}
