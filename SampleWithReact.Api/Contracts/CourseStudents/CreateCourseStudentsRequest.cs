namespace SampleWithReact.Api.Contracts.CourseStudents
{
    public record CreateCourseStudentsRequest(long CourseId, long StudentId, int Grade,String Name);
}
