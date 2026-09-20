

namespace IncotradeBackend.Infrastructure.Database.Pagination
{
    public record PageableResult<T>
    {
        public List<T> Items { set; get; } = [];
        public Pageable Pagination { get; set; } = new Pageable();
    }
}