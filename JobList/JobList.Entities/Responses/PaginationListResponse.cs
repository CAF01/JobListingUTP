namespace JobList.Entities.Responses
{
    public class PaginationListResponse<T>
    {
        public PaginationListResponse(IEnumerable<T> dataList, int totalRows, int pageSize)
        {
            this.Data = dataList;
            this.TotalRows = totalRows;
            this.PageSize = pageSize;
            this.TotalPages = totalRows == 0 ? 0 : (int)Math.Ceiling((double)totalRows / pageSize);
        }

        public IEnumerable<T> Data { get; set; }

        public int TotalRows { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }
    }
}
