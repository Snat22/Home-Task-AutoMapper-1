using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options ) :base(options)
    {
        Database.EnsureCreated();
        Database.EnsureDeleted();
    }

    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Mentor> Mentors { get; set; } = null!;
    public DbSet<StudentGroup> StudentGroups { get; set; } = null!;
    public DbSet<MentorGroup> MentorGroups { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Course>().HasMany(e=>e.Groups).WithOne(e=>e.Course).HasForeignKey(e=>e.CourseID).OnDelete(DeleteBehavior.Cascade);
        base.OnModelCreating(builder);
    }
    
    }


