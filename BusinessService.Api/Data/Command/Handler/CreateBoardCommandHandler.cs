namespace BusinessService.Api.Data
{
    public sealed class CreateBoardCommandHandler : ICommandHandler<CreateBoardCommand, bool>
    {
        private readonly IRepository<long, BoardDbModel> _boardRepository;
        private readonly IMapper<Board, BoardDbModel> _boardDbMapper;
        private readonly IValidator<CreateBoardCommand, Board> _buildBoardValidator;
        public CreateBoardCommandHandler(IRepository<long, BoardDbModel> boardRepository, IValidator<CreateBoardCommand, Board> buildBoardValidator, IMapper<Board, BoardDbModel> boardDbMapper)
        {
            _boardRepository = boardRepository;
            _buildBoardValidator = buildBoardValidator;
            _boardDbMapper = boardDbMapper;
        }

        public Either<string, bool> Handle(CreateBoardCommand command)
        {
            return _buildBoardValidator.Validate(command).MapEither(
                board => _boardRepository.Create(_boardDbMapper.MapFrom(board))
            );
        }
    }
}