namespace SampleWithReact.Api.Contracts.CourseStudents
{
    public record CourseStudentsPagedResponse(
          int CurrentPage,
      int PageSize,
      int TotalPageCount,
      int TotalRowCount,
      List<CourseStudentsPagedResponse> Data);
}
