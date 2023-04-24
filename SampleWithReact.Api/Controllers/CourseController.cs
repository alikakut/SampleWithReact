using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleWithReact.Api.Contracts.Course;
using SampleWithReact.Api.Controllers.Common;
using SampleWithReact.Application.Courses.Commands.CreateCourse;
using SampleWithReact.Application.Courses.Queries.GetCourses;

namespace SampleWithReact.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class CourseController : BaseController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CourseController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CoursePagedRequest request)
        {
            var query = _mapper.Map<CourseQuery>(request);

            ErrorOr<CourseQueryResult> queryResult = await _mediator.Send(query);

            return queryResult.Match(
                result => Ok(_mapper.Map<CoursePagedResponse>(result)),
                Problem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseRequest request)
        {

            var command = _mapper.Map<CreateCourseCommand>(request);

            var createResult = await _mediator.Send(command);

            return createResult.Match(
                result => Ok(_mapper.Map<CourseResponse>(result)),
                Problem);
        }
    }
}
