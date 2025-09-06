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
        Task<List<ProviderModel>> GetProviders();
    }
    public class ProviderRepository(AppDbContext dbContext): IProviderRepository
    {
        public Task<List<ProviderModel>> GetProviders()
        {
            return dbContext.Providers.ToListAsync();
        }
    }
}
