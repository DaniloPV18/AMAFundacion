namespace FundacionAMA.Domain.Shared.Interfaces
{
    public interface IUserEntity
    {
        public long IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? InicioSesion { get; set; }
        public string? Token { get; set; }
        public string? Identificacion { get; set; }
        public ICollection<string>? Roles { get; set; }
        public string? Hash { get; set; }
    }
}
