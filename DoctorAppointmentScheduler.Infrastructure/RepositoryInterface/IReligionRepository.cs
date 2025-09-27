namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface IReligionRepository
    {
        string addRelogion(string status);
        string deleteReligion(Guid statusId);
        List<object> GetAllReligion();
        string updateReligion(Guid statusId, string statusIdName);
    }
}
