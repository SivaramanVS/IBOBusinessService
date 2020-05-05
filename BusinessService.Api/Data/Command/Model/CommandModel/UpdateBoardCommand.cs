namespace BusinessService.Api.Data
{
    public sealed class UpdateBoardCommand
    {
        public long BoardId { get; set; }
        public string BoardName { get; set; }
    }
}