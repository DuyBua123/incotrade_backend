
namespace IncotradeBackend.Infrastructure.Database.Pagination
{
    public record Pageable
    {
        public int CurrentPage { set; get; }
        public int PageSize { set; get; }
        public long TotalItems { set; get; }
        public int TotalPages { set; get; }
        public bool HasNext { set; get; }
        public bool HasPrevious { set; get; }
    }
}