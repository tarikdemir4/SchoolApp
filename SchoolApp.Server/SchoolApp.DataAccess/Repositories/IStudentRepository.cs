using SchoolApp.Entities.Models;

namespace SchoolApp.DataAccess.Repositories;
public interface IStudentRepository
{
    void Create(Student student);
    void Update(Student student);
    void DeleteById(Guid id);
    List<Student> GetAll();
    Student? GetStudentById(Guid studentId);
    bool IsIdentityNumberExists(string IdentityNumber);
}
