using Blazored.Toast.Services;
using HealthCarePortalApp.Model.Entities;
using HealthCarePortalApp.Model.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HealthCarePortalApp.Web.Components.Pages.Provider
{
    public partial class UpdateProvider
    {
        [Parameter]
        public int ID { get; set; }
        public ProviderModel Model { get; set; } = new();
        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Provider/{ID}");
            if (res != null && res.Success)
            {
                Model = JsonConvert.DeserializeObject<ProviderModel>(res.Data.ToString());
            }
        }

        public async Task Submit()
        {
            var res = await ApiClient.PuttAsync<BaseResponseModel, ProviderModel>($"/api/Provider/{ID}", Model);
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Update Provider Sucessfully");
                NavigationManager.NavigateTo("/provider");
            }
        }
    }
}
