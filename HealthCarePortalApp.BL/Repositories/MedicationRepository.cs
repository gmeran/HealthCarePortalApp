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
    public interface IMedicationRepository
    {
        Task<List<MedicationModel>> GetMedications();
    }
    public class MedicationRepository(AppDbContext dbContext) : IMedicationRepository
    {
        public Task<List<MedicationModel>> GetMedications()
        {
            return dbContext.Medications.ToListAsync();
        }
    }
}
