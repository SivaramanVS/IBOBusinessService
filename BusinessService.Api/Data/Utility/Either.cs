using System.Threading.Tasks;

namespace BusinessService.Api.Data
{
   
    #region Either
    public abstract class Either<TLeft,TRight>
    {
    }

    #endregion


    #region Interface

    #endregion

    #region Board

    #endregion


    /*
     public Either<string, bool> Validate(UpdateBoardCommand command) // Service = Validator => Repository => Domain
        {
            if(command.BoardId <= 0) return Left<string, bool>("Invalid Board"); 
            if (IsNullOrWhiteSpace(command.BoardName)) return Left<string, bool>("Board Name can't be blank");
            var id = new BoardId(command.BoardId);
            var board = _boardRepository.GetById(id); // Valid
            return board switch
            { 
                Right<string,Board> val => (val.Value.Name.Value == command.BoardName)? Right<string,bool>(true) : _boardRepository.Update(new Board(id,new BoardName(command.BoardName))),
                Left<string,Board> val => Left<string,bool>(val.Value),
                _ => Left<string,bool>("Some thing went wrong")
            };
        }
     */
}
