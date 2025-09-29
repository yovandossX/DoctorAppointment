using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes("u6V9YODDXlN5DjFDNeapdzJvIoVMMixAMl0YVIhrOjkZgEMmChuvw==");

            var result = _authRepository.getUsreDetailsByUsername(userName, password);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                        [
                            //new Claim('Name', result.UserName),
                            //new Claim(ClaimTypes.Role, resultArgs.ResultData.PrimaryRoleId.ToString()),
                            //new Claim(CustomClaimNames.USER_ID, AESHelper.EncryptData(resultArgs.ResultData.UserId.ToString(), false)),
                            //new Claim(CustomClaimNames.STAFF_ID, AESHelper.EncryptData(resultArgs.ResultData.StaffId.ToString(), false)),
                            //new Claim(CustomClaimNames.Staff_Name, resultArgs.ResultData.StaffName, string.Empty),
                        ]),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);

            string finaltoken = tokenhandler.WriteToken(token);

            return Ok(result);
        }
    }
}
