using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.API.Controllers.PatientMaster
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReligionController : ControllerBase
    {
        private readonly IReligionRepository _religionRepository;

        public ReligionController(IReligionRepository  religionRepository)
        {
            _religionRepository = religionRepository;
        }
        [HttpGet]
        public ActionResult<List<object>> GetAllOccupations()
        {
            var result = _religionRepository.GetAllReligion();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<string> Add([FromBody] string status)
        {
            var result = _religionRepository.addRelogion(status);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<string> Update(Guid id, [FromBody] string statusIdName)
        {
            var result = _religionRepository.updateReligion(id, statusIdName);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public ActionResult<string> Delete(Guid id)
        {
            var result = _religionRepository.deleteReligion(id);
            return Ok(result);
        }
    }
}
