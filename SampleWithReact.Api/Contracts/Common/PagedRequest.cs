namespace SampleWithReact.Api.Contracts.Common
{
    public record PagedRequest
    {
        public int Page { get; set; }   
        public int size { get; set; }  
    }
}
