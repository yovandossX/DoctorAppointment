using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.API.Controllers.Patients
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpGet]
        public ActionResult<List<object>> AuthenticateAsync(string userName, string password)
        {
            var result = _authRepository.getUsreDetailsByUsername(userName, password);
            return Ok(result);
        }
    }
}
