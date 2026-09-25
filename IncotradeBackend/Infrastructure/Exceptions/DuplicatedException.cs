namespace IncotradeBackend.Infrastructure.Exceptions
{
    public class DuplicatedException : Exception
    {
        public string Error { get; }

        public DuplicatedException(string error) : base(error)
        {
            Error = error;
        }
    }
}
