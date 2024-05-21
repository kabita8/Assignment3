using System.ComponentModel.DataAnnotations;
public class Grade
{
[Key]   
public int Id { get; set; }
public int Label { get; set; }
public string ClassTeacher { get; set; }
public Medium Medium { get; set; }
public string Subject {get; set; }
public DateTime SessionYear {get; set;}
}

public enum Medium
   {
    English,
    Nepali,
    Others
   }