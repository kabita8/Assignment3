using Microsoft.EntityFrameworkCore;
public class VidhyalayaDbContext : DbContext
{
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Student> Students {get; set;}
    public DbSet<Guardian> GuardianDetails {get; set;}
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Grade>().HasKey(g => g.Label);
    // }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Vidhyalaya.db");
    }
}