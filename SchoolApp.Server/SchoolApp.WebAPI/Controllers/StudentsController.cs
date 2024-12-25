using Microsoft.AspNetCore.Mvc;
using SchoolApp.Business.Services;
using SchoolApp.Entities.DTOs;

namespace SchoolApp.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class StudentsController
    (IStudentService studentService) : ControllerBase
{
    [HttpPost]

    public IActionResult Create(CreateStudentDto request)
    {
        string message = studentService.Create(request);
        return Ok(new { Message = message });
    }
}
