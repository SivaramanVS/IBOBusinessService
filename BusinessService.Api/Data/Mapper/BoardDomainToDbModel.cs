namespace BusinessService.Api.Data
{
    public sealed class BoardDomainToDbModel : IMapper<Board, BoardDbModel>
    {
        public Board MapTo(BoardDbModel dbModel)
        {
            return BoardModel.Board(BoardModel.BoardId(dbModel.Id), BoardModel.BoardName(dbModel.Name));
        }

        public BoardDbModel MapFrom(Board dbModel)
        {
            return new BoardDbModel
            {
                Id = dbModel.Id.Value,
                Name = dbModel.Name.Value
            };
        }
    }
}