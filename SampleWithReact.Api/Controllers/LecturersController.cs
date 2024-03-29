﻿
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using SampleWithReact.Api.Contracts.Course;
using SampleWithReact.Api.Contracts.Lecturers;
using SampleWithReact.Api.Controllers.Common;
using SampleWithReact.Application.Courses.Commands.CreateCourse;
using SampleWithReact.Application.Courses.Queries.GetCourses;
using SampleWithReact.Application.Lecturers.Commands.CreateLecturers;
using SampleWithReact.Application.Lecturers.Queries.GetLecturer;
using MapsterMapper;
using SampleWithReact.Api.Contracts.Student;
using SampleWithReact.Application.Students.Commands.DeleteStudents;
using SampleWithReact.Application.Lecturers.Commands.DeleteLecturers;
using SampleWithReact.Application.Lecturers.Queries.GetByIdLecturer;
using SampleWithReact.Application.Lecturers.Commands.UpdateLecturers;

namespace SampleWithReact.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class LecturersController : BaseController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public LecturersController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] LecturerPagedRequest request)
        {
            var query = _mapper.Map<LecturerQuery>(request);

            ErrorOr<LecturerQueryResult> queryResult = await _mediator.Send(query);

            return queryResult.Match(
                result => Ok(_mapper.Map<LecturerPagedResponse>(result)),
                Problem);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var query = _mapper.Map<LecturerGetByIdQuery>(new { Id = id });

            ErrorOr<LecturerQueryGetByIdResult> queryResult = await _mediator.Send(query);

            return queryResult.Match(
                result => Ok(_mapper.Map<LecturerResponse>(result)),
                Problem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLecturerRequest request)
        {

            var command = _mapper.Map<CreateLecturerCommand>(request);

            var createResult = await _mediator.Send(command);

            return createResult.Match(
                result => Ok(_mapper.Map<LecturerResponse>(result)),
                Problem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var command = _mapper.Map<DeleteLecturerCommand>(new { Id = id });

            var deleteResult = await _mediator.Send(command);

            return deleteResult.Match(
                result => Ok(_mapper.Map<LecturerResponse>(result)),
                Problem);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LecturerResponse request)
        {
            var command = _mapper.Map<UpdateLecturerCommand>(request);
            var updateResult = await _mediator.Send(command);
            return updateResult.Match(
                result => Ok(_mapper.Map<LecturerResponse>(result)),
                Problem);
        }


    }
}

