using Blazored.Toast.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using HealthCarePortalApp.Web.Components.Pages.Patient;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Reflection;

namespace HealthCarePortalApp.Web.Components.Pages.Medication
{
   

    public partial class AssignMedicationToPatient
    {

        [Inject]
        public ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Parameter]
        public int MedicationID {  get; set; }
        public List<PatientModel> PatientModels { get; set; }
        public  MedicationModel MedicationModel { get; set; }
        public PatientMedicationModel Model { get; set; } = new();
        public PatientModel PatientModel { get; set; }
        private bool hasMedication { get; set; }
        public int PatientID {  get; set; }
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
            var selectedPatientIds = PatientModels.Where(p => p.hasMedication)
                .Select(p => p.ID).ToList();

            if (hasMedication == false)
            {
                Model.PatientID =  selectedPatientIds.First() ;
                Model.MedicationID = MedicationID;
                var res = await ApiClient.PostAsync<BaseResponseModel, PatientMedicationModel>($"/api/Medication/patientMedication", Model);
                if(res != null && res.Success) 
                {
                    ToastService.ShowSuccess("Successfully Assigned Medication to Patient");
                    NavigationManager.NavigateTo("/patient");
                }
            }

        }
    }
}
