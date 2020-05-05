namespace BusinessService.Api.Data
{
    public interface IValidator<in TCommand, TDomain>
    {
        Either<string, TDomain> Validate(TCommand command);
    }
}