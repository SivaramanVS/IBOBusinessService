using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessService.Api.Domain.DBModel;
using BusinessService.Api.Domain.DomainModel;
using BusinessService.Api.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BusinessService.Api.Domain.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public async Task<IActionResult> FindStudentsAsync(string name)
        {
            try
            {
                IEnumerable<Student> students = await _studentsRepository.FindStudentsAsync(name);

                if (students != null)
                {
                    return new OkObjectResult(students.Select(p => new StudentViewModel()
                        {
                            //Id = p.StudentId,
                            
                            Name = p.Name.Trim(),
                            Gender = p.Gender.Trim(),
                        SchoolId = p.School
                    }
                    ));
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> GetAllStudentsAsync()
        {
            try
            {
                IEnumerable<Student> students = await _studentsRepository.GetAllStudentsAsync();

                if (students != null)
                {
                    return new OkObjectResult(students.Select(p => new StudentViewModel()
                        {
                           // Id = p.StudentId,
                            Gender = p.Gender.Trim(),
                            Name = p.Name.Trim(),
                        SchoolId = p.School
                    }
                    ));
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> GetStudentAsync(int studentId)
        {
            try
            {
                Student student = await _studentsRepository.GetStudentAsync(studentId);

                if (student != null)
                {
                    return new OkObjectResult(new StudentViewModel()
                    {
                       // Id = student.StudentId,
                        Gender = student.Gender.Trim(),
                        Name = student.Name.Trim(),
                        SchoolId = student.School
                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> DeleteStudentAsync(int studentId)
        {
            try
            {
                Student student = await _studentsRepository.DeleteStudentAsync(studentId);

                if (student != null)
                {
                    return new OkObjectResult(new StudentViewModel()
                    {
                       // Id = student.StudentId,
                        Gender = student.Gender.Trim(),
                        Name = student.Name.Trim(),
                        SchoolId = student.School
                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> AddStudentAsync(Student student)
        {

            try
            {
               
                Student studentList = await _studentsRepository.AddStudentAsync(student);
                if (student != null)
                {
                    return new OkObjectResult(new StudentViewModel()
                    {
                       // Id = studentList.StudentId,
                        Gender = studentList.Gender.Trim(),
                        Name = studentList.Name.Trim(),
                        SchoolId = studentList.School

                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> UpdateStudentAsync(int studentId, Student student)
        {
            try
            {
                Student studentList = await _studentsRepository.UpdateStudentAsync(studentId, student);
                if (studentList != null)
                {
                    return new OkObjectResult(new StudentViewModel()
                    {
                       // Id = studentId,
                        Gender = studentList.Gender.Trim(),
                        Name = studentList.Name.Trim(),
                        SchoolId = studentList.School
                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }
    }

}