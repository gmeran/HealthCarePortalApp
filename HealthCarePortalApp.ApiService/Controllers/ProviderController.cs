using HealthCarePortalApp.BL.Services;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCarePortalApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController(IProviderService providerService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetRpoviders()
        {
            var providers = await providerService.GetProviders();
            return Ok(new BaseResponseModel { Success = true, Data = providers });
        }
    }
}
