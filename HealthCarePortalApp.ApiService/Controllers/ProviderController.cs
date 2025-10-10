using HealthCarePortalApp.BL.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCarePortalApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController(IProviderService providerService, IPatientService patientService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetRpoviders()
        {
            var providers = await providerService.GetProviders();
            return Ok(new BaseResponseModel { Success = true, Data = providers });
        }
        [HttpPost]
        public async Task<ActionResult<ProviderModel>> CreateProvider(ProviderModel providerModel)
        {
            await providerService.CreateProvider(providerModel);
            return Ok(new BaseResponseModel { Success = true });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvider(int id, ProviderModel providerModel)
        {
            if (id != providerModel.ID || !await providerService.ProviderModelExist(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Bad Request" });
            }
            await providerService.UpdateProvider(providerModel);
            return Ok(new BaseResponseModel { Success = true });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetProvider(int id)
        {
            var patientModel = await providerService.GetProvider(id);
            if (patientModel == null)
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not Found" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = patientModel });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            if (!await providerService.ProviderModelExist(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not Found" });
            }
            await providerService.DeleteProvider(id);
            return Ok(new BaseResponseModel { Success = true });
        }
        [HttpPost("patientProvider")]
        public async Task<ActionResult<PatientProviderModel>> CreatePaitentProvider(PatientProviderModel patientProviderModel)
        {
            if (!await providerService.ProviderModelExist(patientProviderModel.ProviderID))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Medication Not Found" });
            }
            if (!await patientService.PatientModelExists(patientProviderModel.PatientID))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Patient Not Found" });
            }
            await providerService.CreatePatientProvider(patientProviderModel);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
