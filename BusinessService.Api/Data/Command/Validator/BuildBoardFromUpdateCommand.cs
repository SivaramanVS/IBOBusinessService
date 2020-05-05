namespace BusinessService.Api.Data
{
    public sealed class BuildBoardFromUpdateCommand : IValidator<UpdateBoardCommand, Board>
    {
        private readonly IValidator<long, BoardId> _buildBoardIdValidator;
        private readonly IValidator<string, BoardName> _buildBoardNameValidator;
        public BuildBoardFromUpdateCommand(IValidator<long, BoardId> buildBoardIdValidator, IValidator<string, BoardName> buildBoardNameValidator)
        {
            _buildBoardIdValidator = buildBoardIdValidator;
            _buildBoardNameValidator = buildBoardNameValidator;
        }
        public Either<string, Board> Validate(UpdateBoardCommand command)
            => _buildBoardIdValidator.Validate(command.BoardId).MapEither<BoardId,Board>(id => 
                _buildBoardNameValidator.Validate(command.BoardName).Map(
                    name => new Board(id, name)
                )
            );
    }
}