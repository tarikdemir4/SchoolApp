using SchoolApp.Entities.DTOs;
using SchoolApp.Entities.Models;

namespace SchoolApp.Business.Services;
public interface IStudentService
{
    string Create(CreateStudentDto request);
    string Update(UpdateStudentDto request);
    string DeleteById(Guid id);
    List<Student> GetAll();
}
