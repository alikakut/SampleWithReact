namespace SampleWithReact.Api.Contracts.Lecturers
{
    public record LecturerResponse
         (
        long Id,
        string FirstName,
        string LastName,
        bool IsActive,
        bool IsDeleted);
}
