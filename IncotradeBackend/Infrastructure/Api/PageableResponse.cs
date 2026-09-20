
using IncotradeBackend.Infrastructure.Database.Pagination;

namespace IncotradeBackend.Infrastructure.Api
{
    public record PageableResponse<T>
    {
        public List<T> Items { set; get; } = [];
        public Pageable Pagination { get; set; } = new Pageable();
    }
}