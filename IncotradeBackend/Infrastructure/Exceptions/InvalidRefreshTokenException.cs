namespace IncotradeBackend.Infrastructure.Exceptions
{
    public class InvalidRefreshTokenException : Exception
    {
        public string Error { get; }

        public InvalidRefreshTokenException(string error) : base("Refresh token không hợp lệ.")
        {
            Error = error;
        }
    }
}
