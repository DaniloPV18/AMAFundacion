﻿using FundacionAMA.Application.Services.BrigadeApp;
using FundacionAMA.Application.Services.DonationApp;
using FundacionAMA.Domain.DTO.Donation.Dto;
using FundacionAMA.Domain.DTO.Donation.Filter;
using FundacionAMA.Domain.DTO.Donation.Request;
using FundacionAMA.Domain.DTO.Volunteer.Dto;
using FundacionAMA.Domain.DTO.Volunteer.Filter;
using FundacionAMA.Domain.Interfaces.Controller.Donation;
using FundacionAMA.Domain.Shared.Entities.Operation;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FundacionAMA.API.Controllers.Donation
{
    /// <summary>
    /// controlador de donacion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DonationController : ControllerBase, IDonationController
    {
        private readonly IDonationServiceApp _service;
        /// <summary>
        /// contructior de donacion
        /// </summary>
        /// <param name="service"></param>
        public DonationController(IDonationServiceApp service)
        {
            _service = service;
        }
        /// <summary>
        /// obtener donacion por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<DonationDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetById(int id)
        {
            IOperationResult<DonationDto> result = await _service.GetById(id);
            return StatusCode(result);
        }

        // modifico yo 
        /// <summary>
        /// obtener donacion por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{identification}")]
        [ProducesResponseType(typeof(IOperationResult<DonationDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetByIdentification(string identification)
        {
            IOperationResult<DonationDto> result = await _service.GetByIdentification(identification);
            return StatusCode(result);
        }
        //

        /// <summary>
        /// Obtener todas las donaciones paginado
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IOperationResult<DonationDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] DonationFilter filter)
        {
            IOperationResultList<DonationDto> result = await _service.GetAll(filter);
            return StatusCode(result);
        }
        /// <summary>
        /// Creacion de donaciones
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult<DonationDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(DonationRequest entity)
        {
            IOperationResult result = await _service.Create(entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        /// actualizar donacion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResult<DonationDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(int id, DonationRequest entity)
        {
            IOperationResult result = await _service.Update(id, entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        /// eliminar donacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IOperationResult<DonationDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            IOperationResult result = await _service.Delete(id.ToRequest(this));
            return StatusCode(result);
        }

        [HttpGet("count")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetCount()
        {
            try
            {
                IOperationResultList<DonationDto> Result = await _service.GetAll(new DonationFilter());
                //var count = await _service.GetCount();
                var count = new OperationResult<int>(HttpStatusCode.OK, result: Result.Result.Count());
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }

}
