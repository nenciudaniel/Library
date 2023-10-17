namespace Library.Business.Models
{
    public class FiltersDTO
    {
        private int? _pageSize;
        private const int DefaultPageSize = 10;

        public int CurrentPage { get; set; }
        public string? SortColumn { get; set; }
        public bool IsAscending { get; set; }
        public string? SearchText { get; set; }


        public int? PageSize
        {
            get => _pageSize.GetValueOrDefault() > 0 ? _pageSize : DefaultPageSize;
            set => _pageSize = value;
        }


        public int SkipRows => CurrentPage > 0 ? (CurrentPage - 1) * (PageSize.HasValue ? PageSize.Value : 0) : 0;
        public string IsSQLAscending => IsAscending ? "ASC" : "DESC";
    }
}
