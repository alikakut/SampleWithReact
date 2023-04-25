using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using SampleWithReact.Api.Contracts.Student;
using SampleWithReact.Api.Controllers.Common;
using SampleWithReact.Application.Students.Commands.CreateStudents;
using SampleWithReact.Application.Students.Queries.GetByIdStudents;
using MapsterMapper;
using SampleWithReact.Application.Students.Commands.DeleteStudents;

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

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] CreateStudentRequest request)
        {
            var command = _mapper.Map<UpdateStudentCommand>(request);

            var updateResult = await _mediator.Send(command);

            return updateResult.Match(
                result => Ok(_mapper.Map<StudentResponse>(result)),
                Problem);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete (long Id)
        {
            var command = _mapper.Map<DeleteStudentCommand>(Id);

            var deleteResult = await _mediator.Send(command);

            return deleteResult.Match(
                result => Ok(_mapper.Map<StudentResponse>(result)),
                Problem);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long Id)
        {
            var query = _mapper.Map<StudentQuery>(Id);

            ErrorOr<StudentQueryResult> queryResult = await _mediator.Send(query);

            return queryResult.Match(
                result => Ok(_mapper.Map<StudentPagedResponse>(result)),
                Problem);
        }

    }
}

