using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.API.Controllers.Patients
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ITitle _titleRepository;

        public PatientsController(ITitle titleRepository)
        {
            _titleRepository = titleRepository;
        }
        [HttpGet]
        public ActionResult<List<Occupationresponsedto>> GetAllPatients()
        {
            var result = _titleRepository.getallTitle();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<string> Add([FromBody] string titlenName)
        {
            var result = _titleRepository.addTitle(titlenName);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<string> Update(Guid id, [FromBody] string titlenName)
        {
            var result = _titleRepository.updateTitle(id, titlenName);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public ActionResult<string> Delete(Guid id)
        {
            var result = _titleRepository.deleteTitle(id);
            return Ok(result);
        }
    }
}
