namespace SampleWithReact.Api.Contracts.Student
{
    public record CreateStudentRequest(
        string FirstName,
        string MiddleName,
        string LastName);
}
