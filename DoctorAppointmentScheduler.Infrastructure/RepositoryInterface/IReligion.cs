using DoctorAppointmentScheduler.Application.DTOclass;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface IReligion
    {
        string addOccupation(string Occupationname);
        List<Occupationresponsedto> getallOccupation();
        string deleteOccupation(Guid Occupationid);
        string updateOccupation(Guid Occupationid, string Occupationname);
       
    }
}
