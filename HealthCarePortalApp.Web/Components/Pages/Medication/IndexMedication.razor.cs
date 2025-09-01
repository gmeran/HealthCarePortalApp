using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HealthCarePortalApp.Web.Components.Pages.Medication
{
    public partial class IndexMedication
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<MedicationModel> MedicationModels { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadMedication();
        }
        protected async Task LoadMedication()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Medication");
            if (res != null && res.Success)
            {
                MedicationModels = JsonConvert.DeserializeObject<List<MedicationModel>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }
    }
}
