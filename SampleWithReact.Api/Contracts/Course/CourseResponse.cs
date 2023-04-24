namespace SampleWithReact.Api.Contracts.Course
{
    public record CourseResponse
    (
        int id,
        string FirstName,
        string MiddleName,
        string LastName,
        bool IsActive,
        bool IsDeleted
    );
}
