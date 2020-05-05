using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessService.Api.Domain.DBModel;

namespace BusinessService.Api.Domain.Repository
{
    public interface ISchoolsRepository
    {
        Task<School> GetSchoolsAsync(int schoolsId);

        Task<IEnumerable<School>> GetAllSchoolsAsync();
        Task<IEnumerable<School>> FindSchoolsAsync(string schoolName);
        Task<School> AddSchoolsAsync(School schoolsId);
        Task<School> UpdateSchoolsAsync(int schoolsId, School schools);
        Task<School> DeleteSchoolsAsync(int schoolsId);
    }
}