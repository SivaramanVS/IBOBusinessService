namespace BusinessService.Api.Data
{
    public interface IQueryHandler<in TQuery, TResult>
    {
        Either<string, TResult> Handle(TQuery command);
    }
}