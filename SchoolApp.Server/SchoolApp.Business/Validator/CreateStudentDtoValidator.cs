﻿using FluentValidation;
using SchoolApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Business.Validator;
public sealed class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
{
    public CreateStudentDtoValidator()
    {
        RuleFor(p => p.FirstName).NotEmpty().MinimumLength(3);
        RuleFor(p => p.LastName).NotEmpty().MinimumLength(3);
        RuleFor(p => p.StudentNumber).NotEmpty().GreaterThan(0);
        RuleFor(p => p.IdentityNumber)
            .NotEmpty()
            .MinimumLength(11)
            .MaximumLength(11)
            .Matches("[0-9]");

    }
}
