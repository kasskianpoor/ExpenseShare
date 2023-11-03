namespace APIExpenseShare.Interfaces;
public interface IPaginatedDto
{
    public int PageNumber { get; set; }
    public int TotalNumOfPages { get; set; }
}
