namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface IAuthRepository
    {
        List<object> getUsreDetailsByUsername(string userName, string password);
    }
}
