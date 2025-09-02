using Blazored.Toast.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using HealthCarePortalApp.Web.Components.BaseComponents;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HealthCarePortalApp.Web.Components.Pages.Medication
{
    public partial class IndexMedication
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<MedicationModel> MedicationModels { get; set; }
        public AppModal Modal { get; set; }
        public int DeleteID { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
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
        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteFromAsync<BaseResponseModel>($"/api/Medication/{DeleteID}");
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Delete medication successfully");
                await LoadMedication();
                Modal.Close();
            }
        }
    }
}
