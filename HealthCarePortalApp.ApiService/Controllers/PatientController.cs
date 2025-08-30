using HealthCarePortalApp.BL.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCarePortalApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IPatientService patientService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetPatients()
        {
            var patients = await patientService.GetPatients();
            return Ok(new BaseResponseModel { Success = true, Data = patients});
        }
        
        [HttpPost]
        public async Task<ActionResult<PatientModel>>CreatePatient(PatientModel patientModel)
        {
            await patientService.CreatePatient(patientModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetPatient(int id)
        {
            var patientModel = await patientService.GetPatient(id);
            if (patientModel == null)
            {
                return Ok(new BaseResponseModel { Success=false, ErrorMessage = "Not Found" });
            }
            return Ok(new BaseResponseModel {Success = true, Data =patientModel});
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientModel patientModel)
        {
            if (id != patientModel.ID || !await patientService.PatientModelExists(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Bad Request" });
            }
            await patientService.UpdatePatient(patientModel);
            return Ok(new BaseResponseModel {Success=true});
        }
    }
}
