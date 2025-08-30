using Blazored.Toast.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using HealthCarePortalApp.Web.Components.BaseComponents;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HealthCarePortalApp.Web.Components.Pages.Patient
{
    public partial class IndexPatient
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<PatientModel> PatientModels { get; set; }
        public AppModal Modal {  get; set; }
        public int DeleteID {  get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        protected override async Task OnInitializedAsync()
        {
           await base.OnInitializedAsync();
           await LoadPatient();
        }
        protected async Task LoadPatient()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Patient");
            if (res != null && res.Success)
            {
                PatientModels = JsonConvert.DeserializeObject<List<PatientModel>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }
        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteFromAsync<BaseResponseModel>($"/api/Patient/{DeleteID}");
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Delete patient successfully");
                await LoadPatient();
                Modal.Close();
            }
        }
    }
}
