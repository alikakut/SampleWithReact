namespace SampleWithReact.Api.Contracts.CourseStudents
{
    public record CourseStudentsResponse(
        long Id,
        string Name,
         long CourseId,
         long StudentId,
         int Grade,
        bool IsActive,
        bool IsDeleted);
}
