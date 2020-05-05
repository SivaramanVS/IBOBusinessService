using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessService.Api.Domain.DBModel;
using BusinessService.Api.Domain.DomainModel;
using BusinessService.Api.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BusinessService.Api.Domain.Services
{
    public class SchoolsService : ISchoolsService
    {
        private readonly ISchoolsRepository _SchoolsRepository;

        public SchoolsService(ISchoolsRepository SchoolsRepository)
        {
            _SchoolsRepository = SchoolsRepository;
        }

        public async Task<IActionResult> AddSchoolsAsync(School schools)
        {
            try
            {
                School schoolList = await _SchoolsRepository.AddSchoolsAsync(schools);
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
                School school = await _SchoolsRepository.DeleteSchoolsAsync(schoolsId);

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
                IEnumerable<School> school = await _SchoolsRepository.FindSchoolsAsync(schoolName);

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
                IEnumerable<School> schools = await _SchoolsRepository.GetAllSchoolsAsync();

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
                School school = await _SchoolsRepository.GetSchoolsAsync(studentId);

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
                School schoolsList = await _SchoolsRepository.UpdateSchoolsAsync(schoolsId, schools);
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