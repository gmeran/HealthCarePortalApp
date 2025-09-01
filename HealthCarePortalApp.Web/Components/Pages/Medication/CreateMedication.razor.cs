using Blazored.Toast.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCarePortalApp.Web.Components.Pages.Medication
{
    public partial class CreateMedication
    {
        public MedicationModel Model { get; set; } = new();
        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        public async Task Submit()
        {
            var res = await ApiClient.PostAsync<BaseResponseModel, MedicationModel>("/api/Medication", Model);
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Created Medication Successfully");
                NavigationManager.NavigateTo("/medication");
            }
        }
    }
}
