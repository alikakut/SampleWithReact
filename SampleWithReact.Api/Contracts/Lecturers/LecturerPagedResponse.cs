namespace SampleWithReact.Api.Contracts.Lecturers
{
    public record LecturerPagedResponse(
        int CurrentPage,
      int PageSize,
      int TotalPageCount,
      int TotalRowCount,
      List<LecturerResponse> Data);
}
