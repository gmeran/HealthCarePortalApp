using HealthCarePortalApp.BL.Services;
using HealthCarePortalApp.Model.Entities;
using Microsoft.AspNetCore.Components;

namespace HealthCarePortalApp.Web.Components.Pages.Patient
{
    public partial class PatientMedication 
    {
        [Inject]
        public IPatientService PatientService{ get; set; }
        [Parameter]
        public int PatientID { get; set; }
        [Parameter]
        public string FirstName { get; set; }
        [Parameter]
        public string LastName { get; set; }

        public List<PatientMedicationInfoModel> medications { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (PatientService == null)
                throw new InvalidOperationException("Patient service not injected");

            medications = await PatientService.GetPatientMedications(PatientID)
                          ?? new List<PatientMedicationInfoModel>();
        }
    }
}
