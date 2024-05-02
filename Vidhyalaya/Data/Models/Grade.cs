using System.ComponentModel.DataAnnotations;
public class Grade
{
[Key]   
public int Label { get; set; }
public string ClassTeacher { get; set; }
public string Medium { get; set; }
public string Subjects {get; set; }
public DateTime SessionYear {get; set;}
}