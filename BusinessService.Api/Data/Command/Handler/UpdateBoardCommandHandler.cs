using System;

namespace BusinessService.Api.Data
{
    public sealed class UpdateBoardCommandHandler : ICommandHandler<UpdateBoardCommand, bool>
    {
        private readonly IRepository<long, BoardDbModel> _boardRepository;
        private readonly IMapper<Board, BoardDbModel> _boardDbMapper;
        private readonly IValidator<UpdateBoardCommand, Board> _buildBoardValidator;
        public UpdateBoardCommandHandler(IRepository<long, BoardDbModel> boardRepository, IValidator<UpdateBoardCommand, Board> buildBoardValidator, IMapper<Board, BoardDbModel> boardDbMapper)
        {
            _boardRepository = boardRepository;
            _buildBoardValidator = buildBoardValidator;
            _boardDbMapper = boardDbMapper;
        }

        public Either<string, bool> Handle(UpdateBoardCommand command)
        {
            Func<BoardDbModel, string, BoardDbModel> func = (a, b) => { a.Name = b; return a; };
            return _buildBoardValidator.Validate(command).MapEither(board =>
                _boardRepository.GetById(board.Id.Value).MapEither(dbBoard =>
                   _boardDbMapper.MapTo(dbBoard).IsBoardNameSame(board.Name) switch {
                        true => EitherModel.Right<string, bool>(true),
                        false => _boardRepository.Update(func(dbBoard,board.Name.Value))
                    }
                )
            );
        }
    }
}