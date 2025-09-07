using Blazored.Toast.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using HealthCarePortalApp.Web.Components.BaseComponents;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HealthCarePortalApp.Web.Components.Pages.Provider
{
    public partial class IndexProvider
    {
        public List<ProviderModel> ProviderModel { get; set; }
        public AppModal Modal { get; set; }
        [Inject]
        public ApiClient ApiClient { get; set; }
        public int DeleteID { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadPatient();
        }
        protected async Task LoadPatient()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Provider");
            if (res != null && res.Success)
            {
                ProviderModel = JsonConvert.DeserializeObject<List<ProviderModel>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }
        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteFromAsync<BaseResponseModel>($"/api/Provider/{DeleteID}");
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Delete provider successfully");
                await LoadPatient();
                Modal.Close();
            }
        }
    }
}
