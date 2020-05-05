using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessService.Api.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        //public int? SchoolRefId { get; set; }

        [ForeignKey("SchoolRefId")]
        public int School { get; set; }

    }
}