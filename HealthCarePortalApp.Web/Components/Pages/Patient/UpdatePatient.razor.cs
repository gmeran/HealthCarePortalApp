using Blazored.Toast.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HealthCarePortalApp.Web.Components.Pages.Patient
{
    public partial class UpdatePatient: ComponentBase
    {
        [Parameter]
        public int ID { get; set; }
        public PatientModel Model { get; set; } = new();
        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Patient/{ID}");
            if (res != null && res.Success)
            {
                Model = JsonConvert.DeserializeObject<PatientModel>(res.Data.ToString());   
            }
        }

        public async Task Submit()
        {
            var res = await ApiClient.PuttAsync<BaseResponseModel, PatientModel>($"/api/Patient/{ID}", Model);
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Update Patient Sucessfully");
                NavigationManager.NavigateTo("/patient");
            }
        }
    }
}
