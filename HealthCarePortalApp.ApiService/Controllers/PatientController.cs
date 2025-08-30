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
    }
}
