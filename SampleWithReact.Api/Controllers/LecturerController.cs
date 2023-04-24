using AutoMapper;
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

namespace SampleWithReact.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class LecturerController : BaseController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public LecturerController(ISender mediator, IMapper mapper)
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateLecturerRequest request)
        {

            var command = _mapper.Map<CreateLecturerCommand>(request);

            var createResult = await _mediator.Send(command);

            return createResult.Match(
                result => Ok(_mapper.Map<LecturerResponse>(result)),
                Problem);
        }
    }
}

