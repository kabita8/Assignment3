
public class Student
{
    public int Id{ get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Gender sex { get; set; }
    public DateTime Dob { get; set; }
    public string? Photo { get; set; }
    
}
public enum Gender
   {
    Male,
    Female,
    Others
}

