namespace SampleWithReact.Api.Contracts.Common
{
    public record PagedRequest
    {
        public int Page { get; set; }   
        public int Size { get; set; }
        public long Id { get; set; }
    }
}
