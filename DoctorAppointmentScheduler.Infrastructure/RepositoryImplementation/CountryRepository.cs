using DoctorAppointmentScheduler.Domain.Data;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class CountryRepository : ICountry
    {
        private readonly DoctorappointmentContext _context;

        public CountryRepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public string addCountry(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return "Country name cannot be empty";

            var exists = _context.Countries
                .Any(o => o.Countryname.ToLower() == status.ToLower() && !o.Isdeleted == false);

            if (exists)
                return "Country already exists";

            var entity = new Country
            {
                Countryname = status,
            };

            _context.Countries.Add(entity);
            _context.SaveChanges();
            return "Country added successfully";
        }

        public string deleteCountry(Guid statusId)
        {
            var entity = _context.Countries.FirstOrDefault(o => o.Countryid == statusId);
            if (entity == null) return "Country not found";

            entity.Isdeleted = true;
            _context.SaveChanges();
            return "Country deleted successfully";
        }

        public List<object> getallCountry()
        {
            var data = _context.Countries
                .Select(o => new
                {
                    id = o.Countryid,
                    Maritalstatus = o.Countryname,
                    isdeleted = o.Isdeleted
                }).ToList<object>();

            return data;
        }

        public string updateCountry(Guid statusId, string statusIdName)
        {
            var entity = _context.Countries.FirstOrDefault(o => o.Countryid == statusId);
            if (entity == null) return "Country not found";

            entity.Countryname = statusIdName;
            _context.SaveChanges();
            return "Country updated successfully";
        }
    }
}
