namespace SampleWithReact.Api.Contracts.Course
{
    public record CoursePagedResponse(
          int CurrentPage,
      int PageSize,
      int TotalPageCount,
      int TotalRowCount,
      List<CoursePagedResponse> Data);
}
