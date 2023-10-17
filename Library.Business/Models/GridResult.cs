namespace Library.Business.Models
{
    public class GridResult<T>
    {
        public int Total { get; set; } = 0;
        public List<T> Items { get; set; } = new();
    }
}
