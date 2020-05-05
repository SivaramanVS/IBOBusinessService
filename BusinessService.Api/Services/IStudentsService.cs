using System.Threading.Tasks;
using BusinessService.Api.Domain.DBModel;
using Microsoft.AspNetCore.Mvc;

namespace BusinessService.Api.Domain.Services
{
    public interface IStudentsService
    {
        Task<IActionResult> GetAllStudentsAsync();
        Task<IActionResult> GetStudentAsync(int studentId);
        Task<IActionResult> FindStudentsAsync(string sku);
        Task<IActionResult> AddStudentAsync(Student student);
        Task<IActionResult> UpdateStudentAsync(int studentId,Student student);
        Task<IActionResult> DeleteStudentAsync(int studentId);
    }
}