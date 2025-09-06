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
    }
    public class ProviderService(IProviderRepository providerRepository) : IProviderService
    {
        public Task<List<ProviderModel>> GetProviders()
        {
            return providerRepository.GetProviders();
        }
    }
}
