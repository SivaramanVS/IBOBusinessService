using BusinessService.Data.DBModel;
using BusinessService.Data.Repository;
using BusinessService.Domain.DomainModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Domain.Services
{
    public class SchoolsService : ISchoolsService
    {
        private readonly ISchoolsRepository _schoolsRepository;

        public SchoolsService(ISchoolsRepository schoolsRepository)
        {
            _schoolsRepository = schoolsRepository;
        }

        public async Task<IActionResult> AddSchoolsAsync(School schools)
        {
            try
            {
                School schoolList = await _schoolsRepository.AddSchoolsAsync(schools);
                if (schools != null)
                {
                    return new OkObjectResult(new SchoolViewModel()
                    {
                         
                        Name = schoolList.Name.Trim()

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

        public async Task<IActionResult> DeleteSchoolsAsync(int schoolsId)
        {
            try
            {
                School school = await _schoolsRepository.DeleteSchoolsAsync(schoolsId);

                if (school != null)
                {
                    return new OkObjectResult(new SchoolViewModel()
                    {
                        //Id = schoolsId,
                        
                        Name = school.Name.Trim()
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

        public async Task<IActionResult> FindSchoolsAsync(string schoolName)
        {
            try
            {
                IEnumerable<School> school = await _schoolsRepository.FindSchoolsAsync(schoolName);

                if (school != null)
                {
                    return new OkObjectResult(school.Select(p => new SchoolViewModel()
                        {
                            //Id = p.Id,

                            Name = p.Name.Trim(),
                            
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

        public async Task<IActionResult> GetAllSchoolsAsync()
        {
            try
            {
                IEnumerable<School> schools = await _schoolsRepository.GetAllSchoolsAsync();

                if (schools != null)
                {
                    return new OkObjectResult(schools.Select(p => new SchoolViewModel()
                        {
                           // Id = p.Id,
                            
                            Name = p.Name.Trim()
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

        public async Task<IActionResult> GetSchoolsAsync(int studentId)
        {
            try
            {
                School school = await _schoolsRepository.GetSchoolsAsync(studentId);

                if (school != null)
                {
                    return new OkObjectResult(new SchoolViewModel()
                            {
                                //School = p.Value,
                                Name = school.Name.Trim()
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

        public async Task<IActionResult> UpdateSchoolsAsync(int schoolsId, School schools)
        {
            try
            {
                School schoolsList = await _schoolsRepository.UpdateSchoolsAsync(schoolsId, schools);
                if (schools != null)
                {
                    return new OkObjectResult(new SchoolViewModel()
                    {
                        //Id = schoolsId,
                       
                        Name = schoolsList.Name.Trim()
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