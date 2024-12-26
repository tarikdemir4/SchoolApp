using SchoolApp.DataAccess.Context;
using SchoolApp.Entities.Models;

namespace SchoolApp.DataAccess.Repositories;

public sealed class StudentRepository(ApplicationDbContext context) : IStudentRepository
{
    public void Create(Student student)
    {
        context.Add(student);
        context.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        Student? student = GetStudentById(id);
        if (student is not null)
        {
            context.Remove(student);
            context.SaveChanges();
        }
    }

    public List<Student> GetAll()
    {
        return context.Students.ToList();
    }

    public Student? GetStudentById(Guid studentId)
    {
        return context.Students.Where(p => p.Id == studentId).FirstOrDefault();
    }

    public bool IsIdentityNumberExists(string IdentityNumber)
    {
        return context.Students.Any(p => p.IdentityNumber == IdentityNumber);
    }

    public void Update(Student student)
    {
        context.Update(student);
        context.SaveChanges();
    }
}
