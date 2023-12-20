namespace MovieApi.Models;

public class QueryParameters
{
    const int maxPageSize = 100;
    private int pageSize = 50;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get => pageSize;
        set
        {
            pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }

    // public MovieParameters(int pageNumber, int pageSize)
    // {
    //     PageNumber = pageNumber < 1 ? 1 : pageNumber;
    //     PageSize = pageSize > maxPageSize ? maxPageSize : pageSize;
    // }
}