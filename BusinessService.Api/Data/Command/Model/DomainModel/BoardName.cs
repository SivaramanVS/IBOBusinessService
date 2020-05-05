namespace BusinessService.Api.Data
{
    public readonly struct BoardName
    {
        internal BoardName(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}