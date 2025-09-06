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
        Task<ProviderModel> GetProvider(int id);
        Task UpdateProvider(ProviderModel providerModel);
        Task<bool> ProviderModelExists(int id);
    }
    public class ProviderRepository(AppDbContext dbContext): IProviderRepository
    {
        public async Task <ProviderModel> CreateProovider(ProviderModel providerModel)
        {
            dbContext.Providers.Add(providerModel);
            await dbContext.SaveChangesAsync();
            return providerModel;
        }

        public Task<ProviderModel> GetProvider(int id)
        {
            return dbContext.Providers.FirstOrDefaultAsync(n => n.ID == id);
        }

        public Task<List<ProviderModel>> GetProviders()
        {
            return dbContext.Providers.ToListAsync();
        }

        public Task<bool> ProviderModelExists(int id)
        {
            return dbContext.Providers.AnyAsync(n => n.ID == id);
        }

        public async Task UpdateProvider(ProviderModel providerModel)
        {
            dbContext.Entry(providerModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
