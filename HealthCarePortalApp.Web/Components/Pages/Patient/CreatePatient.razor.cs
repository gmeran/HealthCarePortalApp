using Blazored.Toast.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices;

namespace HealthCarePortalApp.Web.Components.Pages.Patient
{
    public partial class CreatePatient
    {
        public PatientModel Model { get; set; } = new();
        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        public async Task Submit()
        {
            var res = await ApiClient.PostAsync<BaseResponseModel, PatientModel>("/api/Patient", Model);
            if (res != null && res.Success) 
            {
                ToastService.ShowSuccess("Created Patient Successfully");
                NavigationManager.NavigateTo("/patient");
            }
        }
    }
}
