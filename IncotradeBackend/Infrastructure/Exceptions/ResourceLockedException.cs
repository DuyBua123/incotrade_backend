namespace IncotradeBackend.Infrastructure.Exceptions
{
    public class ResourceLockedException : Exception
    {
        public string Error { get; }

        public ResourceLockedException(string error) : base(error)
        {
            Error = error;
        }
    }
}
