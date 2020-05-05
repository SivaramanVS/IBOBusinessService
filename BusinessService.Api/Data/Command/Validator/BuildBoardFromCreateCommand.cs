namespace BusinessService.Api.Data
{
    public sealed class BuildBoardFromCreateCommand : IValidator<CreateBoardCommand, Board>
    {
        private readonly IValidator<string, BoardName> _buildBoardNameValidator;
        public BuildBoardFromCreateCommand(IValidator<string, BoardName> buildBoardNameValidator)
        {
            _buildBoardNameValidator = buildBoardNameValidator;
        }
        public Either<string, Board> Validate(CreateBoardCommand command)
            => _buildBoardNameValidator.Validate(command.BoardName).Map(name => BoardModel.Board(name));
    }
}