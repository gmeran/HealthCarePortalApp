using HealthCarePortalApp.BL.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCarePortalApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController(IMedicationService medicationService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetMedications()
        {
            var medications = await medicationService.GetMedications();
            return Ok(new BaseResponseModel { Success = true, Data = medications });
        }
        [HttpPost]
        public async Task<ActionResult<PatientModel>> CreateMedication(MedicationModel medicationtModel)
        {
            await medicationService.CreateMedication(medicationtModel);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
