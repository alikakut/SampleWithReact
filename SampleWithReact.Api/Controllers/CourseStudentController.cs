using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleWithReact.Api.Contracts.CourseStudents;
using SampleWithReact.Api.Contracts.Student;
using SampleWithReact.Api.Controllers.Common;
using SampleWithReact.Application.CourseStudents.Commands.CreateCourseStudent;
using SampleWithReact.Application.CourseStudents.Queries.GetCourseStudent;
using SampleWithReact.Application.Students.Commands.CreateStudents;

namespace SampleWithReact.Api.Controllers
{
    public class CourseStudentController : BaseController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CourseStudentController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] StudentPagedRequest request)
        {
            var query = _mapper.Map<CourseStudentQuery>(request);

            ErrorOr<CourseStudentQueryResult> queryResult = await _mediator.Send(query);

            return queryResult.Match(
                result => Ok(_mapper.Map<StudentPagedResponse>(result)),
                Problem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseStudentsRequest request)
        {

            var command = _mapper.Map<CreateCourseStudentCommand>(request);

            var createResult = await _mediator.Send(command);

            return createResult.Match(
                result => Ok(_mapper.Map<CourseStudentsResponse>(result)),
                Problem);
        }
    }
}
}
