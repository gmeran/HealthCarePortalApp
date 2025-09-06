using Blazored.Toast.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCarePortalApp.Web.Components.Pages.Provider
{
    public partial class CreateProvider
    {
        public ProviderModel Model { get; set; } = new();
        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        public async Task Submit()
        {
            var res = await ApiClient.PostAsync<BaseResponseModel, ProviderModel>("/api/Provider", Model);
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Created Provider Successfully");
                NavigationManager.NavigateTo("/provider");
            }
        }
    }
}
