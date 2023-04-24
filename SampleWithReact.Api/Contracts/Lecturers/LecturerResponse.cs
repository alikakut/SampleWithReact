namespace SampleWithReact.Api.Contracts.Lecturers
{
    public record LecturerResponse
         (
        int id,
        string FirstName,
        string MiddleName,
        string LastName,
        bool IsActive,
        bool IsDeleted);
}
