using DoctorAppointmentScheduler.Domain.Data;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class ReligionRepository : IReligionRepository
    {
        private readonly DoctorappointmentContext _context;

        public ReligionRepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public string addRelogion(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return "Religion cannot be empty";

            var exists = _context.Religions
                .Any(o => o.Religionname.ToLower() == status.ToLower() && !o.Isdeleted == false);

            if (exists)
                return "Religion already exists";

            var entity = new Religion
            {
                Religionname = status,
            };

            _context.Religions.Add(entity);
            _context.SaveChanges();
            return "Religion added successfully";
        }

        public string deleteReligion(Guid statusId)
        {
            var entity = _context.Religions.FirstOrDefault(o => o.Religionid == statusId);
            if (entity == null) return "Religion not found";

            entity.Isdeleted = true;
            _context.SaveChanges();
            return "Religion deleted successfully";
        }
        public List<object> GetAllReligion()
        {
            var data = _context.Religions
                .Where(o => o.Isdeleted == false)
                .Select(o => new
                {
                    id = o.Religionid,
                    name = o.Religionname,
                })
                .ToList<object>();

            return data;
        }

        public string updateReligion(Guid statusId, string statusIdName)
        {
            var entity = _context.Religions.FirstOrDefault(o => o.Religionid == statusId);
            if (entity == null) return "Religion not found";

            entity.Religionname = statusIdName;
            _context.SaveChanges();
            return "Religion updated successfully";
        }
    }
}
