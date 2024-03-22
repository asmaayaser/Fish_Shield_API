namespace CORE.Shared
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaInfo { get; set; }

        public PagedList(List<T> source,int totalCount,int pageSize,int pageNumber)
        {
            MetaInfo = new MetaData()
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (decimal)pageSize),
            };

            AddRange(source);
        }

        public static PagedList<T> ToPagedList(List<T> source,int pageNmber,int pageSize)
        {
            var count=source.Count;
            var items=source
                .Skip((pageNmber-1)*pageSize)
                .Take(pageSize).ToList();
            return new PagedList<T>(items,count, pageSize, pageNmber);
        }
    }
}
