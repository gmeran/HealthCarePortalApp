using HealthCarePortalApp.Database.Data;
using HealthCarePortalApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCarePortalApp.BL.Repositories
{
    public interface IProviderRepository
    {
        Task<ProviderModel> CreateProovider(ProviderModel providerModel);
        Task<List<ProviderModel>> GetProviders();
    }
    public class ProviderRepository(AppDbContext dbContext): IProviderRepository
    {
        public async Task <ProviderModel> CreateProovider(ProviderModel providerModel)
        {
            dbContext.Providers.Add(providerModel);
            await dbContext.SaveChangesAsync();
            return providerModel;
        }

        public Task<List<ProviderModel>> GetProviders()
        {
            return dbContext.Providers.ToListAsync();
        }
    }
}
