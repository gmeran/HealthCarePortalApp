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
        Task<List<PatientMedicationInfoModel>> GetPatientMedicationInfo(int id);
        Task<List<PatientProviderInfoModel>> GetPatientProviderInfo(int id);
        Task<bool> PatientModelExists(int id);
        Task UpdatePatient(PatientModel patientModel);
        Task DeletePatient(int id);
    }
    public class PatientRepository: IPatientRepository
    {
        private readonly AppDbContext _dbContext;

        public PatientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PatientModel>> GetPatients()
        {
            return await _dbContext.Patients.ToListAsync();
        }

        public async Task<PatientModel> GetPatient(int id)
        {
            return await _dbContext.Patients.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<PatientModel> CreatePatient(PatientModel patientModel)
        {
            _dbContext.Patients.Add(patientModel);
            await _dbContext.SaveChangesAsync();
            return patientModel;
        }

        public async Task UpdatePatient(PatientModel patientModel)
        {
            _dbContext.Entry(patientModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePatient(int id)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.ID == id);
            if (patient != null)
            {
                _dbContext.Patients.Remove(patient);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> PatientModelExists(int id)
        {
            return await _dbContext.Patients.AnyAsync(p => p.ID == id);
        }

        public async Task<List<PatientMedicationInfoModel>> GetPatientMedicationInfo(int id)
        {
            return await (
                from n in _dbContext.PatientMedications
                join p in _dbContext.Patients on n.PatientID equals p.ID
                join m in _dbContext.Medications on n.MedicationID equals m.ID
                where p.ID == id
                select new PatientMedicationInfoModel
                {
                    MedicationName = m.Name,
                    Description = m.Description
                }
            ).ToListAsync();
        }

        public async Task<List<PatientProviderInfoModel>> GetPatientProviderInfo(int id)
        {
            return await (
                 from n in _dbContext.PatientProviders
                 join p in _dbContext.Patients on n.PatientID equals p.ID
                 join m in _dbContext.Providers on n.ProviderID equals m.ID
                 where p.ID == id
                 select new PatientProviderInfoModel
                 {
                     FirstName = m.FirstName,
                     LastName = m.LastName,
                     Specialization = m.Specialization,
                 }
               ).ToListAsync();
        }
    }
}
