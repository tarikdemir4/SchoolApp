using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Entities.DTOs;
public sealed record CreateStudentDto(
    string FirstName,
    string LastName,
    int StudentNumber,
    string IdentityNumber,
    Guid ClassRoomId);
