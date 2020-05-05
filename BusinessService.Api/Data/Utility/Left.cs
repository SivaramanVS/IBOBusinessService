namespace BusinessService.Api.Data
{
    /// <summary>
    /// Fail data
    /// </summary>
    /// <typeparam name="TLeft"></typeparam>
    /// <typeparam name="TRight"></typeparam>
    public sealed class Left<TLeft, TRight> : Either<TLeft,TRight>
    {
        public Left(TLeft value)
        {
            Value = value;
        }

        public TLeft Value { get; }
    }
}