namespace BusinessService.Data.DBModel
{
    public class School
    {

       
        public int Id { get; set; }
      //  public decimal Value { get; set; }
        public string Name { get; set; }

        //[ForeignKey("studentRefId")]
        //public Student student  { get; set; }
    }

    public sealed class UpdateSchoolCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}