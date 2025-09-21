using HealthCarePortalApp.BL.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCarePortalApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController(IMedicationService medicationService, IPatientService patientService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetMedications()
        {
            var medications = await medicationService.GetMedications();
            return Ok(new BaseResponseModel { Success = true, Data = medications });
        }
        [HttpPost]
        public async Task<ActionResult<MedicationModel>> CreateMedication(MedicationModel medicationtModel)
        {
            await medicationService.CreateMedication(medicationtModel);
            return Ok(new BaseResponseModel { Success = true });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedication(int id)
        {
            if (!await medicationService.MedicationModelExists(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not Found" });
            }
            await medicationService.DeleteMedication(id);
            return Ok(new BaseResponseModel { Success = true });
        }
       [HttpPost("patientMedication")]
        public async Task<ActionResult<PatientMedicationModel>> CreatePaitentMedication(PatientMedicationModel patientMedicationModel)
        {
            if (!await medicationService.MedicationModelExists(patientMedicationModel.MedicationID))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Medication Not Found" });
            }
            if(!await patientService.PatientModelExists(patientMedicationModel.PatientID))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Patient Not Found" });
            }
            await medicationService.CreatePatientMedication(patientMedicationModel);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
