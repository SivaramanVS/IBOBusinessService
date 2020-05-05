namespace BusinessService.Api.Data
{
    public interface ICommandHandler<in TCommand, TResult>
    {
        Either<string, TResult> Handle(TCommand command);
    }
}