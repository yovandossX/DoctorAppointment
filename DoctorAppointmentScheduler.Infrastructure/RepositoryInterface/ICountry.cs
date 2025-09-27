using DoctorAppointmentScheduler.Application.DTOclass;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface ICountry
    {
        string addCountry(string Countryname);
        List<object> getallCountry();
        string deleteCountry(Guid CountryId);
        string updateCountry(Guid CountryId, string Countryname);

    }
}
