

namespace IncotradeBackend.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Error { get; }

        public NotFoundException(string error) : base(error)
        {
            Error = error;
        }
    }
}