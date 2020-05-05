namespace BusinessService.Api.Data
{
    public sealed class BuildBoardIdValidator : IValidator<long, BoardId>
    {
        public Either<string, BoardId> Validate(long command) => 
            (command <= 0) switch 
            {
                true => EitherModel.Left<string, BoardId>("Board Name can't be blank"),
                false => EitherModel.Right<string,BoardId>(BoardModel.BoardId(command)),
            };
    }
}