namespace SampleWithReact.Api.Contracts.Student
{
    public record StudentResponse
        (
        long id,
        string FirstName,
        string MiddleName,
        string LastName,
        bool IsActive,
        bool IsDeleted );
}
