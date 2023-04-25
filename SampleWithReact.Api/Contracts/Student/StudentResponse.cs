namespace SampleWithReact.Api.Contracts.Student
{
    public record StudentResponse
        (
        long Id,
        string FirstName,
        string MiddleName,
        string LastName,
        bool IsActive,
        bool IsDeleted );
}
