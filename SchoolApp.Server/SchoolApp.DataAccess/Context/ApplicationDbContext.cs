using Microsoft.EntityFrameworkCore;
using SchoolApp.Entities.Models;

namespace SchoolApp.DataAccess.Context;
public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student>Students { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }

}
