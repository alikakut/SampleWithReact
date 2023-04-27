namespace SampleWithReact.Api.Contracts.Course
{
    public record CourseResponse
    (
        long Id,
        string Name,
        string CourseName, 
        int Status,
        long LecturerId,
        bool IsActive,
        bool IsDeleted,
        bool CourseStudentId
    );
}
