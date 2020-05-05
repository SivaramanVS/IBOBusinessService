using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessService.Api.Database;
using BusinessService.Api.Domain.DBModel;
using Microsoft.EntityFrameworkCore;

namespace BusinessService.Api.Domain.Repository
{
    public class SchoolsRepository : ISchoolsRepository
    {
        private readonly DefaultContext _context;

        public SchoolsRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<School> GetSchoolsAsync(int schoolsId)
        {
            return await _context.Schools.Where(p => p.Id == schoolsId).FirstOrDefaultAsync();
        }

        public async Task<School> AddSchoolsAsync(School schools)
        {
            if (schools != null)
            {
                await _context.Schools.AddAsync(schools);

                await _context.SaveChangesAsync();
            }

            return schools;
        }

        public async Task<School> DeleteSchoolsAsync(int schoolsId)
        {
            var school = await GetSchoolsAsync(schoolsId);

            if (school != null)
            {
                _context.Schools.Remove(school);

                await _context.SaveChangesAsync();
            }

            return school;
        }

        public async Task<IEnumerable<School>> FindSchoolsAsync(string schoolName)
        {
            return await _context.Schools.Where(p => p.Name.Contains(schoolName)).ToListAsync();
        }

        public async Task<IEnumerable<School>> GetAllSchoolsAsync()
        {
            return await _context.Schools.ToListAsync();
        }


        public async Task<School> UpdateSchoolsAsync(int schoolsId, School schools)
        {
            var schId = await _context.Schools.FindAsync(schoolsId);
            if (schId != null)
            {
                schId.Name = schools.Name;

                await _context.SaveChangesAsync();
            }

            return schools;
        }
    }
}