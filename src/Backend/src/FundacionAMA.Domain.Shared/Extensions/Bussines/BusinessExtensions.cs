using AutoMapper;
using AutoMapper.QueryableExtensions;

using FundacionAMA.Domain.Shared.Entities.Operation;
using FundacionAMA.Domain.Shared.Interfaces;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

using System.Globalization;
using System.Linq.Expressions;
using System.Net;

namespace FundacionAMA.Domain.Shared.Extensions.Bussines
{
    public static class BusinessExtensions
    {
        private static IMapper _mapper = null!;

        public static string[] ConvertToMemberNames(TypeMap typeMap)
        {
            string[] memberNames = typeMap.PropertyMaps
                .Where(propertyMap => propertyMap.SourceMember != null)
                .Select(propertyMap => propertyMap.DestinationMember.Name)
                .ToArray();

            return memberNames;
        }

        public static void Initialize(IServiceProvider services)
        {
            _mapper = (IMapper)services.GetService(typeof(IMapper))!;
        }

        public static DateTime? ToDateTime(this string date)
        {
            if (!string.IsNullOrWhiteSpace(date))
            {
                if (DateTime.TryParse(date, CultureInfo.GetCultureInfo("ec"), DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }
            }

            return default;
        }

        public static IOperationRequest<T> ToRequest<T>(this T entity, IOperationRequest request)
        {
            return new OperationRequest<T>(data: entity, ip: request.Ip, fecha: request.Fecha, fechaUTC: request.FechaUTC, usuario: request.Usuario);
        }

        public static IOperationRequest<T> ToRequest<T>(this T entity, IPAddress ip, DateTime? fechaUtc = default, DateTime? fecha = default, IUserEntity? usuario = default)
        {
            return new OperationRequest<T>(data: entity, ip: ip, fechaUTC: fechaUtc ?? DateTime.UtcNow, fecha: fecha ?? DateTime.UtcNow, usuario: usuario);
        }

        public static Task<IOperationRequest<T>> ToRequestAsync<T>(this T entity, IOperationRequest request)
        {
            return Task.FromResult(entity.ToRequest(request));
        }

        public static Task<IOperationRequest<T>> ToRequestAsync<T>(this T entity, IPAddress ip, DateTime? fechaUtc = default, DateTime? fecha = default, IUserEntity? usuario = default)
        {
            return Task.FromResult(entity.ToRequest(ip: ip, fechaUtc, fecha: fecha, usuario: usuario));
        }

        public static IOperationResult<T> ToResult<T>(this T entity, HttpStatusCode status = HttpStatusCode.OK, string? message = default, string? error = default)
        {
            try
            {
                return new OperationResult<T>(status: status, message: message, result: entity, error: error);
            }
            catch (Exception ex)
            {
                return ex.ToResult<T>();
            }
        }

        public static IOperationResult<TDestination> ToResult<TSource, TDestination>(this TSource entity, HttpStatusCode status = HttpStatusCode.OK, string? message = default, string? error = default)
        where TSource : class where TDestination : class
        {
            try
            {
                TDestination result = _mapper.Map<TDestination>(entity);
                return new OperationResult<TDestination>(status, message, result, error);
            }
            catch (Exception ex)
            {
                return new OperationResult<TDestination>(ex);
            }
        }

        public static IOperationResult ToResult(this Exception ex)
        {
            return new OperationResult(ex);
        }

        public static IOperationResult<T> ToResult<T>(this Exception ex)
        {
            return new OperationResult<T>(ex);
        }

        public static async Task<IOperationResult> ToResultAsync(this Exception ex)
        {
            return await Task.FromResult(ex.ToResult());
        }

        public static async Task<IOperationResult<T>> ToResultAsync<T>(this Exception ex)
        {
            return await Task.FromResult(ex.ToResult<T>());
        }

        public static async Task<IOperationResult<TDestination>> ToResultAsync<TSource, TDestination>(this TSource entity)
                    where TSource : class where TDestination : class
        {
            return await Task.FromResult(entity.ToResult<TSource, TDestination>());
        }

        public static async Task<IOperationResult<TDestination>> ToResultAsync<TSource, TDestination>(this Task<TSource> entity)
                  where TSource : class where TDestination : class
        {
            TSource entidad = await entity;
            return await Task.FromResult(entidad.ToResult<TSource, TDestination>());
        }

        public static async Task<IOperationResult<T>> ToResultAsync<T>(this T entity, HttpStatusCode status = HttpStatusCode.OK, string? message = default, string? error = default)
        {
            return await Task.FromResult(entity.ToResult(status: status, message: message, error: error));
        }

        public static IOperationResultList<T> ToResultList<T>(this IEnumerable<T> entity,
                        HttpStatusCode status = HttpStatusCode.OK,
                        int Offset = 1,
                        int? Take = 10,
                          string? message = default

                        )
        {
            int count = entity.Count();
            return new OperationResultList<T>(status, message, entity, Offset, Take, count);
        }

        public static IOperationResultList<TResult> ToResultList<TQuery, TResult>(this IQueryable<TQuery> entity,
                            int Offset = 0,
                            int Take = default)
        {
            IQueryable<TQuery> query = entity;
            int count = query.Count();
            if (Take > 0)
            {
                query = query.Skip(Offset).Take(Take);
            }


            List<TResult> result = query.ProjectTo<TResult>(_mapper.ConfigurationProvider).ToList();

            return new OperationResultList<TResult>(HttpStatusCode.OK, default, result, Offset, Take, count);
        }

        public static IOperationResultList<TQuery> ToResultList<TQuery>(this IQueryable<TQuery> entity,
                           int Offset = 0,
                           int Take = default)
        {
            IQueryable<TQuery> query = entity;
            int count = query.Count();


            if (Take > 0)
            {
                query = query.Skip(Offset).Take(Take);
            }



            List<TQuery> result = query.ToList();

            return new OperationResultList<TQuery>(HttpStatusCode.OK, default, result, Offset, Take, count);
        }

        public static async Task<IOperationResultList<TResult>> ToResultList<TQuery, TResult>(
              this List<TQuery> entity,
              int Offset = 0,
              int? Take = default,
              Expression<Func<TResult, object>>? orderByDesc = null)
        {
            try
            {
                List<TQuery> query = entity;
                int count = query.Count();

                // Aplicar ordenamiento si se especificó

                List<TResult> result = _mapper.Map<List<TResult>>(query);

                if (orderByDesc != null)
                {
                    IQueryable<TResult> asquerabel = result.AsQueryable();
                    result = asquerabel.OrderByDescending(orderByDesc).ToList();
                }

                return await Task.FromResult(
                    new OperationResultList<TResult>(
                        HttpStatusCode.OK,
                        default,
                        result,
                        Offset,
                        Take,
                        count));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new OperationResultList<TResult>(ex));
            }
        }

        public static IOperationResultList<T> ToResultList<T>(this Exception ex) where T : class
        {
            return new OperationResultList<T>(ex);
        }

        public static async Task<IOperationResultList<TResult>> ToResultListAsync<TQuery, TResult>(this IOrderedQueryable<TQuery> entity,
                                int Offset = 0,
                        int? Take = default)
        {
            return await Task.FromResult(entity.ToResultList<TQuery, TResult>(Offset, (int)Take));
        }

        public static TDestination MapTo<TDestination>(this object destination)
        {
            return MapTo<TDestination>(destination, sources: default);
        }

        public static TDestination MapTo<TDestination>(this object destination, params object[]? sources)
        {
            TDestination mappedResult;

            if (sources != null && sources.Any())
            {
                mappedResult = _mapper.Map<TDestination>(destination);

                foreach (object src in sources)
                {
                    mappedResult = _mapper.Map(src, mappedResult);
                }
            }
            else
            {
                mappedResult = _mapper.Map<TDestination>(destination);
            }

            return mappedResult;
        }


        public static async Task<IOperationResultList<TResult>> ToResultListAsync<TQuery, TResult>(this IQueryable<TQuery> entity,
                        int Offset = 0,
                        int Take = default)
        {
            return await Task.FromResult(entity.ToResultList<TQuery, TResult>(Offset, Take));
        }

        public static async Task<IOperationResultList<TResult>> ToResultListAsync<TQuery, TResult>(this List<TQuery> entity,
                     int Offset = 0,
                     int? Take = default)
        {
            return await entity.ToResultList<TQuery, TResult>(Offset, Take);
        }

        public static async Task<IOperationResultList<T>> ToResultListAsync<T>(this IEnumerable<T> entity,
                        int Offset = 0,
                        int? Take = default,
                        int? count = default)
        {
            return await Task.FromResult(new OperationResultList<T>(HttpStatusCode.OK, default, entity, Offset, Take, count));
        }

        public static async Task<IOperationResultList<T>> ToResultListAsync<T>(this IEnumerable<T> entity,
                        HttpStatusCode status,
                        string? message = default,
                        int Offset = 0,
                        int? Take = default,
                        int? count = default)
        {
            return await Task.FromResult(new OperationResultList<T>(status, message, entity, Offset, Take, count));
        }

        public static async Task<IOperationResultList<T>> ToResultListAsync<T>(this Exception ex)
        {
            return await Task.FromResult(new OperationResultList<T>(ex));
        }
    }
}