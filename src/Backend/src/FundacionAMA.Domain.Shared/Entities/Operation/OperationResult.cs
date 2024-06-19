using FundacionAMA.Domain.Shared.Interfaces.Operations;
using System.Net;

namespace FundacionAMA.Domain.Shared.Entities.Operation
{
    public class OperationResult : IOperationResult, IEquatable<OperationResult?>
    {
        public OperationResult(Exception ex)
        {
            Message = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
            StatusCode = HttpStatusCode.InternalServerError;
#if DEBUG
            Error = ex.ToString();
#else
            Error = $"{ex.Message} {ex?.InnerException?.Message} {ex?.InnerException?.InnerException?.Message}";
#endif
        }

        public OperationResult(HttpStatusCode status, string? message = default, string? exception = null)
        {
            StatusCode = status;
            Message = message ?? $"The server responded with status code: {(int)status} {status}";
            Error = exception;
        }

        public string? Error { get; set; }
        public string? Message { get; set; } = "OK";
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool Success =>StatusCode < HttpStatusCode.BadRequest;

        public override bool Equals(object? obj)
        {
            return Equals(obj as OperationResult);
        }

        public bool Equals(OperationResult? other)
        {
            return other is not null &&
                   Error == other.Error &&
                   Message == other.Message &&
                   StatusCode == other.StatusCode &&
                   Success == other.Success;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Error, Message, StatusCode, Success);
        }

        public override string ToString() =>
            $"{(Success ? "SUCCESS" : "ERROR")} | {(int)StatusCode} {StatusCode} : {Message} - {Error}";

        public static bool operator ==(OperationResult? left, OperationResult? right)
        {
            return EqualityComparer<OperationResult>.Default.Equals(left, right);
        }

        public static bool operator !=(OperationResult? left, OperationResult? right)
        {
            return !(left == right);
        }
    }

    public class OperationResult<T> : OperationResult, IOperationResult<T>, IEquatable<OperationResult<T>?>
    {
        public T? Result { get; internal set; }

        public OperationResult(Exception ex, T? result = default) : base(ex)
        {
            Result = result;
        }

        public OperationResult(HttpStatusCode status, string? message = null, T? result = default, string? error = default)
            : base(status, message, error)
        {
            if (result == null && StatusCode == HttpStatusCode.OK)
            {
                StatusCode = HttpStatusCode.NotFound;
                Message = message ?? "The requested record does not exist or has already been deleted!";
            }
            else
            {
                Result = result;
            }
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as OperationResult<T>);
        }

        public bool Equals(OperationResult<T>? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   Error == other.Error &&
                   Message == other.Message &&
                   StatusCode == other.StatusCode &&
                   Success == other.Success &&
                   EqualityComparer<T?>.Default.Equals(Result, other.Result);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Error, Message, StatusCode, Success, Result);
        }

        public static bool operator ==(OperationResult<T>? left, OperationResult<T>? right)
        {
            return EqualityComparer<OperationResult<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(OperationResult<T>? left, OperationResult<T>? right)
        {
            return !(left == right);
        }
    }

    public class OperationResultList<T> : OperationResult, IOperationResultList<T>, IEquatable<OperationResultList<T>?>
    {
        private const int maxPageSize = 50;
        private int _pageSize = 10;
        private int _length = 0;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > maxPageSize ? maxPageSize : value;
        }

        public int Length
        {
            get => _length;
            set => _length = value < Result.Count() ? Result.Count() : value;
        }

        public int TotalPages => Length > 0 ? (int)Math.Ceiling(Length / (double)PageSize) : 0;
        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;

        public IEnumerable<T> Result { get; set; } = Enumerable.Empty<T>();

        public OperationResultList(Exception ex, IEnumerable<T>? entity = default) : base(ex)
        {
            Result = entity ?? Enumerable.Empty<T>();
        }

        public OperationResultList(HttpStatusCode status, string? message = null, IEnumerable<T>? result = default, int Offset = 1, int? Take = default, int? count = default)
            : base(status, message)
        {
            Result = result ?? Enumerable.Empty<T>();

            Length = count ?? Result.Count();
            PageSize = Take ?? Length;
            PageNumber = Offset;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as OperationResultList<T>);
        }

        public bool Equals(OperationResultList<T>? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   Error == other.Error &&
                   Message == other.Message &&
                   StatusCode == other.StatusCode &&
                   Success == other.Success &&
                   _pageSize == other._pageSize &&
                   _length == other._length &&
                   PageNumber == other.PageNumber &&
                   PageSize == other.PageSize &&
                   Length == other.Length &&
                   TotalPages == other.TotalPages &&
                   HasPrevious == other.HasPrevious &&
                   HasNext == other.HasNext &&
                   EqualityComparer<IEnumerable<T>>.Default.Equals(Result, other.Result);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(Error);
            hash.Add(Message);
            hash.Add(StatusCode);
            hash.Add(Success);
            hash.Add(_pageSize);
            hash.Add(_length);
            hash.Add(PageNumber);
            hash.Add(PageSize);
            hash.Add(Length);
            hash.Add(TotalPages);
            hash.Add(HasPrevious);
            hash.Add(HasNext);
            hash.Add(Result);
            return hash.ToHashCode();
        }

        public static bool operator ==(OperationResultList<T>? left, OperationResultList<T>? right)
        {
            return EqualityComparer<OperationResultList<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(OperationResultList<T>? left, OperationResultList<T>? right)
        {
            return !(left == right);
        }
    }
}