﻿using AutoMapper;
using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;

using SampleWithReact.Domain.Errors;

namespace SampleWithReact.Application.Students.Queries.GetByIdStudents
{
    public class StudentQueryGetByIdHandler : IRequestHandler<StudentGetByIdQuery, ErrorOr<StudentQueryGetByIdResult>>
    {
        IStudentRepository _studentRepository;
     
        public StudentQueryGetByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            
        }
        public async Task<ErrorOr<StudentQueryGetByIdResult>> Handle(StudentGetByIdQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (query.Id <= 0)
            {
                return Errors.NotFound;
            }

            var student = _studentRepository.GetById(query.Id);

            if (_studentRepository.Get(query.Page, query.Size) is not { } studentList)
            {
                return Errors.NotFound;
            }
            return new StudentQueryGetByIdResult();
               
        }
    }
}
