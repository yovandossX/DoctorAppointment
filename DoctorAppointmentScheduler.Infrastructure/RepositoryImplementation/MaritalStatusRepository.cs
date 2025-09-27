using DoctorAppointmentScheduler.Domain.Data;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class MaritalStatusRepository : IMaritalStatusRepository
    {
        private readonly DoctorappointmentContext _context;

        public MaritalStatusRepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public string addMaritalStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return "Occupation name cannot be empty";

            var exists = _context.Maritalstatuses
                .Any(o => o.Maritalstatus1.ToLower() == status.ToLower() && !o.Isdeleted == false);

            if (exists)
                return "Occupation already exists";

            var entity = new Maritalstatus
            {
                Maritalstatus1 = status,
            };

            _context.Maritalstatuses.Add(entity);
            _context.SaveChanges();
            return "Occupation added successfully";
        }

        public string deleteMaritalStatus(Guid statusId)
        {
            var entity = _context.Maritalstatuses.FirstOrDefault(o => o.Maritalstatusid == statusId);
            if (entity == null) return "Occupation not found";

            entity.Isdeleted = true;
            _context.SaveChanges();
            return "Occupation deleted successfully";
        }
        public List<object> GetAllMaritalStatus()
        {
            var data = _context.Maritalstatuses
                .Select(o => new
                {
                    id = o.Maritalstatusid,
                    Maritalstatus = o.Maritalstatus1,
                    isdeleted = o.Isdeleted
                }).ToList<object>();

            return data;
        }

        public string updateMaritalStatus(Guid statusId, string statusIdName)
        {
            var entity = _context.Maritalstatuses.FirstOrDefault(o => o.Maritalstatusid == statusId);
            if (entity == null) return "Occupation not found";

            entity.Maritalstatus1 = statusIdName;
            _context.SaveChanges();
            return "Occupation updated successfully";
        }
    }
}
