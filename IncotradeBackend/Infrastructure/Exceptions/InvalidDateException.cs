namespace IncotradeBackend.Infrastructure.Exceptions
{
    public class InvalidDateException : Exception
    {
        public string Error { get; }

        public InvalidDateException(string error) : base(error)
        {
            Error = error;
        }
    }
}
