namespace SampleWithReact.Api.Contracts.Student
{
    public record StudentResponse
        (
        int id,
        string FirstName,
        string MiddleName,
        string LastName,
        bool IsActive,
        bool IsDeleted );
}
