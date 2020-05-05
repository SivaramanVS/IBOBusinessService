using System.Threading.Tasks;
using BusinessService.Api.Domain.DBModel;
using Microsoft.AspNetCore.Mvc;

namespace BusinessService.Api.Domain.Services
{
    public interface ISchoolsService
    {
        Task<IActionResult> GetSchoolsAsync(int schoolId);
        Task<IActionResult> GetAllSchoolsAsync();
        Task<IActionResult> FindSchoolsAsync(string schoolName);
        Task<IActionResult> AddSchoolsAsync(School schoolsId);
        Task<IActionResult> UpdateSchoolsAsync(int schoolsId, School schools);
        Task<IActionResult> DeleteSchoolsAsync(int schoolsId);
    }
}