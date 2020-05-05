using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessService.Api.Data
{
    public sealed class BoardRepository : IRepository<long, BoardDbModel>
    {
        private readonly BoardDbContext _dbContext;

        public BoardRepository(BoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Either<string, bool> Create(BoardDbModel value)
        {
            try
            {
                _dbContext.BoardDbModels.Add(value);
                _dbContext.SaveChanges();
                return EitherModel.Right<string, bool>(true);
            }
            catch (Exception e)
            {
                return EitherModel.Left<string, bool>(e.Message);
            }
        }

        public Either<string, IEnumerable<BoardDbModel>> GetAll()
        {
            try
            {
                var ret = _dbContext.BoardDbModels.ToList();
                return EitherModel.Right<string, IEnumerable<BoardDbModel>>(ret);
            }
            catch (Exception e)
            {
                return EitherModel.Left<string, IEnumerable<BoardDbModel>>(e.Message);
            };
        }

        public Either<string, BoardDbModel> GetById(long key)
        {
            try
            {
                return EitherModel.Right<string, BoardDbModel>(_dbContext.BoardDbModels.FirstOrDefault(dbBoard => dbBoard.Id == key));
            }
            catch (Exception e)
            {
                return EitherModel.Left<string, BoardDbModel>(e.Message);
            }
        }

        public Either<string, bool> Update(BoardDbModel value)
        {
            try
            {;
                _dbContext.BoardDbModels.Update(value);

                _dbContext.SaveChanges();
                return EitherModel.Right<string, bool>(true);
            }
            catch (Exception e)
            {
                return EitherModel.Left<string, bool>(e.Message);
            }
        }
    }
}