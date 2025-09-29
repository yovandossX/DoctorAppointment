using DoctorAppointmentScheduler.Domain.Data;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using System.Net.Http.Headers;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DoctorappointmentContext _context;

        public AuthRepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public List<object> getUsreDetailsByUsername(string userName, string password)
        {
            var user = _context.Users
                .Where(o => o.Username == userName)
                .Select(o => new
                {
                    id = o.Userid,
                    UserName = o.Username,
                    DoctorName = o.Doctorname,
                    Password = o.Password
                })
                .FirstOrDefault();

            if (user == null || user.Password != password)
            {
                //return Unauthorized(new List<object>());
                return new List<object>(); // return empty list if not found or wrong password
            }

            return new List<object>
    {
        new {
            user.id,
            user.UserName,
            user.DoctorName
        }
    };
        }

    }
}
