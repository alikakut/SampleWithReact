﻿using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using SampleWithReact.Api.Contracts.Student;
using SampleWithReact.Api.Controllers.Common;
using SampleWithReact.Application.Students.Commands.CreateStudents;
using SampleWithReact.Application.Students.Queries.GetByIdStudents;
using MapsterMapper;

namespace SampleWithReact.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class StudentController : BaseController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public StudentController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] StudentPagedRequest request)
        {
            var query = _mapper.Map<StudentQuery>(request);

            ErrorOr<StudentQueryResult> queryResult = await _mediator.Send(query);

            return queryResult.Match(
                result => Ok(_mapper.Map<StudentPagedResponse>(result)),
                Problem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentRequest request)
        {

            var command = _mapper.Map<CreateStudentCommand>(request);

            var createResult = await _mediator.Send(command);

            return createResult.Match(
                result => Ok(_mapper.Map<StudentResponse>(result)),
                Problem);
        }
    }
}

