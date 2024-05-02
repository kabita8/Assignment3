using System.ComponentModel.DataAnnotations;
public class Student
{
    public int Id{ get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Gender sex { get; set; }
    public DateTime Dob { get; set; }
    public byte[] Photo { get; set; }
    public Guardian GuardianDetails { get; set; }
}
public enum Gender
   {
    Male,
    Female,
    Others
   }

public class Guardian
{
    [Key]
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
}