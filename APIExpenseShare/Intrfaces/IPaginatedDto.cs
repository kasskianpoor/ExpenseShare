namespace APIExpenseShare.Interfaces;
public interface IPaginatedDto<T>
{
    public int PageNumber { get; set; }
    public int TotalNumOfPages { get; set; }
    public List<T>? Data { get; set; }
}

public class PaginatedDto<T> : IPaginatedDto<T>
{
    public int PageNumber { get; set; }
    public int TotalNumOfPages { get; set; }
    public List<T>? Data { get; set; }
}