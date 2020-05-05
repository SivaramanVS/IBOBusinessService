using System;

namespace BusinessService.Api.Data
{
    public sealed class BoardDTOtoDbModel : IMapper<BoardDTO, BoardDbModel>
    {
        public BoardDTO MapTo(BoardDbModel dbModel)
        {
            return new BoardDTO
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                LastUpdated = dbModel.LastUpdated.ToString("dd/mm/yyyy")
            };
        }

        public BoardDbModel MapFrom(BoardDTO dbModel)
        {
            throw new NotImplementedException();
        }
    }
}