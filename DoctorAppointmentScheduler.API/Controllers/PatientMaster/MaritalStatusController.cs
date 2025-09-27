using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.API.Controllers.PatientMaster
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaritalStatusController : ControllerBase
    {
        private readonly IMaritalStatusRepository _maritalStatusRepository;

        public MaritalStatusController(IMaritalStatusRepository maritalStatusRepository)
        {
            _maritalStatusRepository = maritalStatusRepository;
        }
        [HttpGet]
        public ActionResult<List<object>> GetAllMaritalStatus()
        {
            var result = _maritalStatusRepository.GetAllMaritalStatus();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<string> Add([FromBody] string status)
        {
            var result = _maritalStatusRepository.addMaritalStatus(status);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<string> Update(Guid statusId,[FromBody] string statusName)
        {
            var result = _maritalStatusRepository.updateMaritalStatus(statusId, statusName);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public ActionResult<string> Delete(Guid statusId)
        {
            var result = _maritalStatusRepository.deleteMaritalStatus(statusId);
            return Ok(result);
        }
    }
}
