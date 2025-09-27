using DoctorAppointmentScheduler.Application.DTOclass;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface ITitle
    {
        string addTitle(string TitleName);
        List<object> getallTitle();
        string deleteTitle(Guid TitleId);
        string updateTitle(Guid TitleId, string TitleName);

    }
}
