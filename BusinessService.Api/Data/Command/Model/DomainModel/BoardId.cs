namespace BusinessService.Api.Data
{
    public readonly struct BoardId
    {
        internal BoardId(long value)
        {
            Value = value;
        }

        public long Value { get; }
    }
}