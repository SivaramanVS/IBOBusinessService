using System;

namespace BusinessService.Api.Data
{
    public sealed class BuildBoardNameValidator : IValidator<string, BoardName>
    {
        public Either<string, BoardName> Validate(string command) =>
            String.IsNullOrWhiteSpace(command) switch 
            {
                true => EitherModel.Left<string, BoardName>("Board Name can't be blank"),
                false => EitherModel.Right<string,BoardName>(BoardModel.BoardName(command)),
            };
    }
}