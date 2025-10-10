using Blazored.Toast.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HealthCarePortalApp.Web.Components.Pages.Provider
{
    public partial class AssignProviderToPatient
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Parameter]
        public int ProviderId { get; set; }
        public List<PatientModel> PatientModels { get; set; }
       
        public PatientProviderModel Model { get; set; } = new();
        public PatientModel PatientModel { get; set; }
        private bool hasProvider { get; set; }
        public int PatientID { get; set; }
        public ChangeEventArgs Args { get; set; }
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

        public async Task SubmitSelectedPatient()

        {
            var selectedPatientIds = PatientModels.Where(p => p.hasProvider)
                .Select(p => p.ID).ToList();

            if (hasProvider == false)
            {
                Model.PatientID = selectedPatientIds.First();
                Model.ProviderID = ProviderId;
                var res = await ApiClient.PostAsync<BaseResponseModel, PatientProviderModel>($"/api/Provider/patientProvider", Model);
                if (res != null && res.Success)
                {
                    ToastService.ShowSuccess("Successfully Assigned Provider to Patient");
                    NavigationManager.NavigateTo("/patient");
                }
            }

        }
    }
}

