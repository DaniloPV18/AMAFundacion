using FundacionAMA.Domain.Shared.Interfaces;

namespace FundacionAMA.Domain.Shared.Models
{
    public class UsuarioDto : IUserEntity
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
