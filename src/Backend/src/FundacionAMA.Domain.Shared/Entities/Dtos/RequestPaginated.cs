namespace FundacionAMA.Domain.Shared.Entities.Dtos
{
    /// <summary>
    /// Request de Paginacion
    /// </summary>
    public class RequestPaginated
    {
        /// <summary>
        /// Pagina a obtener
        /// </summary>
        public int Offset { get; set; } = 0;
        /// <summary>
        /// Cantidad de elementos a obtener
        /// </summary>
        public int Take { get; set; } = 10;
        /// <summary>
        /// Ordenamiento
        /// </summary>
        public string? Sort { get; set; }// por implementarse funcionalidad
    }
}
