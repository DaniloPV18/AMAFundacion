using FundacionAMA.Domain.Shared.Interfaces;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Domain.Shared.Entities.Operation
{
    public class OperationRequest<T> : OperationRequest, IOperationRequest<T>, IEquatable<OperationRequest<T>?>
    {
        public T Data { get; set; }

        public OperationRequest(T data, object? ip, DateTime fecha, DateTime fechaUTC, IUserEntity? usuario)
            : base(ip, fecha, fechaUTC, usuario)
        {
            Data = data;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as OperationRequest<T>);
        }

        public bool Equals(OperationRequest<T>? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   Ip == other.Ip &&
                   Fecha == other.Fecha &&
                   FechaUTC == other.FechaUTC &&
                   EqualityComparer<IUserEntity?>.Default.Equals(Usuario, other.Usuario) &&
                   EqualityComparer<T>.Default.Equals(Data, other.Data);
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Ip, Fecha, FechaUTC, Usuario, Data);
        }

        public static bool operator ==(OperationRequest<T>? left, OperationRequest<T>? right)
        {
            return EqualityComparer<OperationRequest<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(OperationRequest<T>? left, OperationRequest<T>? right)
        {
            return !(left == right);
        }
    }

    public class OperationRequest : IOperationRequest, IEquatable<OperationRequest?>
    {
  

        public OperationRequest(object? ip, DateTime fecha, DateTime fechaUTC, IUserEntity? usuario)
        {
            Ip = $"{ip}";
            Fecha = fecha;
            FechaUTC = fechaUTC;

            Usuario = usuario;
        }

      

        public string? Ip { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
        public DateTime FechaUTC { get; set; } = DateTime.UtcNow;

        public IUserEntity? Usuario { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as OperationRequest);
        }

        public bool Equals(OperationRequest? other)
        {
            return other is not null &&
                   Ip == other.Ip &&
                   Fecha == other.Fecha &&
                   FechaUTC == other.FechaUTC &&
                   EqualityComparer<IUserEntity?>.Default.Equals(Usuario, other.Usuario);
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Ip, Fecha, FechaUTC, Usuario);
        }

        public static bool operator ==(OperationRequest? left, OperationRequest? right)
        {
            return EqualityComparer<OperationRequest>.Default.Equals(left, right);
        }

        public static bool operator !=(OperationRequest? left, OperationRequest? right)
        {
            return !(left == right);
        }
    }
}