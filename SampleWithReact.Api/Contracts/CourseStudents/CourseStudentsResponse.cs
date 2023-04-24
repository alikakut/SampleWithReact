namespace SampleWithReact.Api.Contracts.CourseStudents
{
    public record CourseStudentsResponse(
         int id,
        string FirstName,
        string MiddleName,
        string LastName,
        bool IsActive,
        bool IsDeleted);
}
