using HealthCarePortalApp.BL.Repositories;
using HealthCarePortalApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCarePortalApp.BL.Services
{
    public interface IProviderService
    {
        Task<List<ProviderModel>> GetProviders();
        Task<ProviderModel> CreateProvider(ProviderModel providerModel);
        Task<ProviderModel> GetProvider(int id);
        Task UpdateProvider(ProviderModel providerModel);
        Task<bool> ProviderModelExist(int id);
    }
    public class ProviderService(IProviderRepository providerRepository) : IProviderService
    {
        public async Task<ProviderModel> CreateProvider(ProviderModel providerModel)
        {
            var provider = await providerRepository.CreateProovider(providerModel);
            return provider;
        }

        public Task<ProviderModel> GetProvider(int id)
        {
            return providerRepository.GetProvider(id);
        }

        public Task<List<ProviderModel>> GetProviders()
        {
            return providerRepository.GetProviders();
        }

        public Task<bool> ProviderModelExist(int id)
        {
            return providerRepository.ProviderModelExists(id);
        }

        public Task UpdateProvider(ProviderModel providerModel)
        {
            return providerRepository.UpdateProvider(providerModel);
        }
    }
}
