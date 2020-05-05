using System.Threading.Tasks;
//using BusinessService..Domain.Services;
using BusinessService.Data.DBModel;
using BusinessService.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolsService _schoolsService;

        public SchoolsController(ISchoolsService schoolsService)
        {
            _schoolsService = schoolsService;
        }

        // GET /api/Schools
        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            return await _schoolsService.GetAllSchoolsAsync();
        }


        // GET /api/Schools/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchoolsAsync(int id)
        {
            return await _schoolsService.GetSchoolsAsync(id);
        }

        // GET /api/students/find
        [HttpGet]
        [Route("FindByName")]
        public async Task<IActionResult> FindStudentsAsync(string schoolName)
        {
            return await _schoolsService.FindSchoolsAsync(schoolName);
        }

        // DELETE /api/students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            return await _schoolsService.DeleteSchoolsAsync(id);
        }

        // POST /api/students
        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(School school)
        {
            return await _schoolsService.AddSchoolsAsync(school);
        }


        // PUT /api/students/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAsync(int id, School school)
        {
            return await _schoolsService.UpdateSchoolsAsync(id, school);
        }

    }
}