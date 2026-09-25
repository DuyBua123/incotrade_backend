

namespace IncotradeBackend.Infrastructure.Exceptions
{
    public class ServerException : Exception
    {
        public string Error { get; }

        public ServerException(string error) : base("Xảy ra lỗi dưới Server.")
        {
            Error = error;
        }
    }
}