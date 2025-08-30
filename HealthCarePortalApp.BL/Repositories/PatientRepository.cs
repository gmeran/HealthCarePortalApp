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
    }
    public class PatientRepository(AppDbContext dbContext) : IPatientRepository
    {
        public async Task<PatientModel> CreatePatient(PatientModel patientModel)
        {
            dbContext.Patients.Add(patientModel);
            await dbContext.SaveChangesAsync();
            return patientModel;
        }

        public Task<List<PatientModel>> GetPatients()
        {
            return dbContext.Patients.ToListAsync();
        }
    }
}
