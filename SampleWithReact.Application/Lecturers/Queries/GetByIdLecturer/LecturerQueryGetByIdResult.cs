﻿using SampleWithReact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Lecturers.Queries.GetByIdLecturer
{
    public record LecturerQueryGetByIdResult
    ( 
      long Id ,string FirstName, string LastName, bool IsActive, bool IsDelete
    );
}
