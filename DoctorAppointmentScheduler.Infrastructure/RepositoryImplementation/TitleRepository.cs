using DoctorAppointmentScheduler.Domain.Data;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class TitleRepository : ITitle
    {
        private readonly DoctorappointmentContext _context;

        public TitleRepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public string addTitle(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return "Title cannot be empty";

            var exists = _context.Titles
                .Any(o => o.Titlename.ToLower() == status.ToLower() && !o.Isdeleted == false);

            if (exists)
                return "Title already exists";

            var entity = new Title
            {
                Titlename = status,
            };

            _context.Titles.Add(entity);
            _context.SaveChanges();
            return "Title added successfully";
        }

        public string deleteTitle(Guid statusId)
        {
            var entity = _context.Titles.FirstOrDefault(o => o.Titleid == statusId);
            if (entity == null) return "Title not found";

            entity.Isdeleted = true;
            _context.SaveChanges();
            return "Title deleted successfully";
        }
        public List<object> getallTitle()
        {
            var data = _context.Titles
                .Where(o => o.Isdeleted == false)
                .Select(o => new
                {
                    id = o.Titleid,
                    name = o.Titlename,
                })
                .ToList<object>();

            return data;
        }

        public string updateTitle(Guid statusId, string statusIdName)
        {
            var entity = _context.Titles.FirstOrDefault(o => o.Titleid == statusId);
            if (entity == null) return "Title not found";

            entity.Titlename = statusIdName;
            _context.SaveChanges();
            return "Title updated successfully";
        }
    }
}
