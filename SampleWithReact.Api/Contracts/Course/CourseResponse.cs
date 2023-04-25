namespace SampleWithReact.Api.Contracts.Course
{
    public record CourseResponse
    (
        long Id,
        string Name,
        int Status,
        long LecturerId,
        bool IsActive,
        bool IsDeleted
    );
}
