using FluentValidation.Results;
using SchoolApp.Business.Validator;
using SchoolApp.DataAccess.Repositories;
using SchoolApp.Entities.DTOs;
using SchoolApp.Entities.Models;

namespace SchoolApp.Business.Services;

public sealed class StudentService(IStudentRepository studentRepository) : IStudentService
{
    public string Create(CreateStudentDto request)
    {
        CreateStudentDtoValidator validator = new();
        ValidationResult result = validator.Validate(request);

        if (!result.IsValid)
        {
            throw new ArgumentException(string.Join(" ", result.Errors));
        }


        bool isIdentityNumberExists = studentRepository.IsIdentityNumberExists(request.IdentityNumber);

        if (isIdentityNumberExists)
        {
            throw new ArgumentException("Bu TC numarası daha önce kaydedilmiştir.");
        }

        Student student = new()
        {
            IdentityNumber = request.IdentityNumber,
            ClassRoomId = request.ClassRoomId,
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now,
            FirstName = request.FirstName,
            LastName = request.LastName,
            StudentNumber = request.StudentNumber,
        };
        studentRepository.Create(student);
        return "Kayıt işlemi başarıyla tamamlandı";
    }

    public string DeleteById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetAll()
    {
        throw new NotImplementedException();
    }

    public string Update(UpdateStudentDto request)
    {
        throw new NotImplementedException();
    }
}
