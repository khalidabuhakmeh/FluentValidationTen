using Microsoft.AspNetCore.Mvc;

namespace FluentValidationTen.Controllers
{
    [ApiController]
    public class UserRegistrationController : Controller
    {
        [HttpPost, Route("fluent-validation")]
        public IActionResult FluentValidation(
            Models.FluentValidationModels.UserRegistrationRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(request);
            }

            return BadRequest(ModelState);
        }

        [HttpPost, Route("data-annotations")]
        public IActionResult DataAnnotations(
            Models.DataAnnotationsModels.DataAnnotationsUserRegistrationRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(request);
            }

            return BadRequest(ModelState);
        }
    }
}