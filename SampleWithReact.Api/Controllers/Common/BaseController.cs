using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

namespace SampleWithReact.Api.Controllers.Common
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.IsNullOrEmpty())
            {
                return Problem();
            }

            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }

            return Problem(errors[0]);
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            // If it is about credential just show that error and make status code 401
            //if (error == Errors.Authentication.InvalidCredentials)
            //{
            //    HttpContext.Items[HttpContextItemKeys.Errors] = new List<Error>() {error};
            //    statusCode = StatusCodes.Status401Unauthorized;
            //}
            //else
            //{
            // HttpContext.Items[HttpContextItemKeys.Errors] = error;
            //}

            return Problem(statusCode: statusCode, title: error.Description);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.ToString(),error.ToString());
            }

            return ValidationProblem(modelStateDictionary);
        }
    }
}
