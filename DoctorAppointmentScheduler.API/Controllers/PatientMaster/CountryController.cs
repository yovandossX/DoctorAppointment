using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.API.Controllers.PatientMaster
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountry _countryRepository;

        public CountryController(ICountry countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        public ActionResult<List<Occupationresponsedto>> GetAllCountry()
        {
            var result = _countryRepository.getallCountry();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<string> Add([FromBody] string occupationName)
        {
            var result = _countryRepository.addCountry(occupationName);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<string> Update(Guid id, [FromBody] string occupationName)
        {
            var result = _countryRepository.updateCountry(id, occupationName);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public ActionResult<string> Delete(Guid id)
        {
            var result = _countryRepository.deleteCountry(id);
            return Ok(result);
        }
    }
}
