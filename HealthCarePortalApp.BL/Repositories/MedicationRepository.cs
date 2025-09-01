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
        Task<MedicationModel> CreateMedication(MedicationModel medicationModel);
        Task<List<MedicationModel>> GetMedications();
    }
    public class MedicationRepository(AppDbContext dbContext) : IMedicationRepository
    {
        public async Task<MedicationModel> CreateMedication(MedicationModel medicationModel)
        {
            dbContext.Medications.Add(medicationModel);
            await dbContext.SaveChangesAsync();
            return medicationModel;

        }

        public Task<List<MedicationModel>> GetMedications()
        {
            return dbContext.Medications.ToListAsync();
        }
    }
}
