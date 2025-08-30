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
    public interface IPatientRepository
    {
        Task<List<PatientModel>> GetPatients();
        Task<PatientModel> CreatePatient(PatientModel patientModel);
        Task<PatientModel> GetPatient(int id);
        Task<bool> PatientModelExists(int id);
        Task UpdatePatient(PatientModel patientModel);
        Task DeletePatient(int id);
    }
    public class PatientRepository(AppDbContext dbContext) : IPatientRepository
    {
        public async Task<PatientModel> CreatePatient(PatientModel patientModel)
        {
            dbContext.Patients.Add(patientModel);
            await dbContext.SaveChangesAsync();
            return patientModel;
        }

        public async Task DeletePatient(int id)
        {
           var patient = dbContext.Patients.FirstOrDefault(n => n.ID == id);
            dbContext.Patients.Remove(patient);
            await dbContext.SaveChangesAsync();
        }

        public Task<PatientModel> GetPatient(int id)
        {
           return dbContext.Patients.FirstOrDefaultAsync(n => n.ID == id);
        }

        public Task<List<PatientModel>> GetPatients()
        {
            return dbContext.Patients.ToListAsync();
        }

        public Task<bool> PatientModelExists(int id)
        {
            return dbContext.Patients.AnyAsync(n => n.ID == id);
        }

        public async Task UpdatePatient(PatientModel patientModel)
        {
            dbContext.Entry(patientModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
