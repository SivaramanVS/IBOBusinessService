using System.Collections.Generic;

namespace BusinessService.Api.Data
{
    public interface IRepository<in TKey, TDomain>
    {
        Either<string, IEnumerable<TDomain>> GetAll();
        Either<string, TDomain> GetById(TKey key);
        Either<string, bool> Update(TDomain value);
        Either<string, bool> Create(TDomain value);
    }
}