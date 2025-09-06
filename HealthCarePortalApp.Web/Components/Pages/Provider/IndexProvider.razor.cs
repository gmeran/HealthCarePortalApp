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
    }
}
