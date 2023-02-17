namespace JobList.Entities.Models
{
    public class Pagination
    {
        public int? Skip { get; set; } = default!;
        public int? Take { get; set; } = default!;
    }
}
