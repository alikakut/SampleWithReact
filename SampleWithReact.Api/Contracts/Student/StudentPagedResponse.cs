namespace SampleWithReact.Api.Contracts.Student
{
    public record StudentPagedResponse(
    int CurrentPage,
    int PageSize,
    int TotalPageCount,
    int TotalRowCount,
    List<StudentPagedResponse> Data);
}
