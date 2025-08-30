using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HealthCarePortalApp.Web.Components.Pages.Patient
{
    public partial class IndexPatient
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<PatientModel> PatientModels { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Patient");
            if (res != null && res.Success) 
            {
                PatientModels = JsonConvert.DeserializeObject<List<PatientModel>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }
    }
}
