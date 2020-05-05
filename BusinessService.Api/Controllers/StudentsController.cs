using System.Threading.Tasks;
using BusinessService.Domain.Services;
using BusinessService.Data.DBModel;
using Microsoft.AspNetCore.Mvc;

namespace BusinessService.Api.Controllers
{

    [Route("api/[controller]")]
        [ApiController]
        public class StudentsController : Controller
        {
            private readonly IStudentsService _studentsService;

            public StudentsController(IStudentsService studentsService)
            {
                _studentsService = studentsService;
            }

            // GET /api/students
            [HttpGet]
            public async Task<IActionResult> GetAllStudentsAsync()
            {
             
                    return await _studentsService.GetAllStudentsAsync();
                
            }

               

            

            // GET /api/students/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetStudentAsync(int id)
            {
                return await _studentsService.GetStudentAsync(id);
            }

            // GET /api/students/find
            [HttpGet]
            [Route("FindByName")]
            public async Task<IActionResult> FindStudentsAsync(string studentName)
            {
                return await _studentsService.FindStudentsAsync(studentName);
            }

            // DELETE /api/students/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteStudentAsync(int id)
            {
                return await _studentsService.DeleteStudentAsync(id);
            }

            // POST /api/students
            [HttpPost]
            public async Task<IActionResult> AddStudentAsync(Student student)
            {
               
                        return await _studentsService.AddStudentAsync(student);
                  
            }


            // PUT /api/students/1
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateStudentAsync(int id, Student student)
            {

              
                    return await _studentsService.UpdateStudentAsync(id, student);
               
            }
        }
    }
