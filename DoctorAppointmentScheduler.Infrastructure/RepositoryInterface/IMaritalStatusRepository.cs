namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface IMaritalStatusRepository
    {
        string addMaritalStatus(string status);
        string deleteMaritalStatus(Guid statusId);
        List<object> GetAllMaritalStatus();
        string updateMaritalStatus(Guid statusId, string statusIdName);
    }
}
