using HealthCarePortalApp.BL.Repositories;
using HealthCarePortalApp.Model.Entities;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HealthCarePortalApp.BL.Services
{
    public interface IPatientService
    {
        Task<List<PatientModel>> GetPatients();
        Task<PatientModel> CreatePatient(PatientModel patientModel);

    }
    public class PatientService(IPatientRepository patientRepository) : IPatientService
    {
        public async Task<PatientModel> CreatePatient(PatientModel patientModel)
        {
            var patient = await patientRepository.CreatePatient(patientModel);
            return patient;
        }

        public Task<List<PatientModel>> GetPatients()
        {
            return patientRepository.GetPatients();
        }
    }
}
