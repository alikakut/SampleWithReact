
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleWithReact.Api.Contracts.Course;
using SampleWithReact.Api.Controllers.Common;
using SampleWithReact.Application.Courses.Commands.CreateCourse;
using SampleWithReact.Application.Courses.Queries.GetCourses;
using MapsterMapper;
using SampleWithReact.Api.Contracts.Lecturers;
using SampleWithReact.Application.CourseStudents.Commands.DeleteCourseStudents;
using SampleWithReact.Application.CourseStudents.Queries.GetByIdCourseStudent;
using SampleWithReact.Application.Courses.Queries.GetByIdCourses;
using SampleWithReact.Application.Courses.Commands.DeleteCourse;

namespace SampleWithReact.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class CoursesController : BaseController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CoursesController(ISender mediator, IMapper mapper)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var command = _mapper.Map<DeleteCourseCommand>(Id);

            var deleteResult = await _mediator.Send(command);

            return deleteResult.Match(
                result => Ok(_mapper.Map<CourseResponse>(result)),
                Problem);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long Id)
        {
            var query = _mapper.Map<CourseGetByIdQuery>(Id);

            ErrorOr<CourseGetByIdQueryResult> queryResult = await _mediator.Send(query);

            return queryResult.Match(
                result => Ok(_mapper.Map<LecturerPagedResponse>(result)),
                Problem);
        }

    }
}
