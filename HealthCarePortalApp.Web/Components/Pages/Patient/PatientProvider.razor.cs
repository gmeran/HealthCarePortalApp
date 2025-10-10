using HealthCarePortalApp.BL.Services;
using HealthCarePortalApp.Model.Entities;
using Microsoft.AspNetCore.Components;

namespace HealthCarePortalApp.Web.Components.Pages.Patient
{
    public partial class PatientProvider
    {

        [Inject]
        public IPatientService PatientService { get; set; }
        [Parameter]
        public int PatientID { get; set; }
        [Parameter]
        public string FirstName { get; set; }
        [Parameter]
        public string LastName { get; set; }
        public List<PatientProviderInfoModel> providers { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (PatientService == null)
                throw new InvalidOperationException("Patient service not injected");

            providers = await PatientService.GetPatientProviders(PatientID)
                          ?? new List<PatientProviderInfoModel>();
        }
    }
}
