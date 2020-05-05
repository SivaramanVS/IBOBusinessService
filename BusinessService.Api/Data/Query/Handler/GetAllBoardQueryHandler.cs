using System.Collections.Generic;
using System.Linq;

namespace BusinessService.Api.Data
{
    public sealed class GetAllBoardQueryHandler : IQueryHandler<GetAllBoardQuery, IEnumerable<BoardDTO>>
    {
        private readonly IRepository<long, BoardDbModel> _boardRepository;
        private readonly IMapper<BoardDTO, BoardDbModel> _boardDbMapper;
        public GetAllBoardQueryHandler(IRepository<long, BoardDbModel> boardRepository, IMapper<BoardDTO, BoardDbModel> boardDbMapper)
        {
            _boardRepository = boardRepository;
            _boardDbMapper = boardDbMapper;
        }
        
        public Either<string, IEnumerable<BoardDTO>> Handle(GetAllBoardQuery command)
        {
            return _boardRepository.GetAll().Map(dbBoards => dbBoards.Select(dbBoard=> _boardDbMapper.MapTo(dbBoard)).AsEnumerable());
        }
    }
}