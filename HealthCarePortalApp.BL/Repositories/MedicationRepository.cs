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
        Task DeleteMedication(int id);
        Task<bool> MedicationModelExists(int id);
    }
    public class MedicationRepository(AppDbContext dbContext) : IMedicationRepository
    {
        public async Task<MedicationModel> CreateMedication(MedicationModel medicationModel)
        {
            dbContext.Medications.Add(medicationModel);
            await dbContext.SaveChangesAsync();
            return medicationModel;

        }

        public async Task DeleteMedication(int id)
        {
            var medication = dbContext.Medications.FirstOrDefault(n => n.ID == id);
            dbContext.Medications.Remove(medication);
            await dbContext.SaveChangesAsync();
        }

        public Task<List<MedicationModel>> GetMedications()
        {
            return dbContext.Medications.ToListAsync();
        }

        public Task<bool> MedicationModelExists(int id)
        {
            return dbContext.Medications.AnyAsync(n => n.ID == id);
        }
    }
}
