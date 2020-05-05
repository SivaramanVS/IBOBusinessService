namespace BusinessService.Api.Data
{
    /// <summary>
    /// Success Data
    /// </summary>
    /// <typeparam name="TLeft"></typeparam>
    /// <typeparam name="TRight"></typeparam>
    public sealed class Right<TLeft, TRight> : Either<TLeft,TRight>
    {
        public Right(TRight value)
        {
            Value = value;
        }

        public TRight Value { get; }
    }
}