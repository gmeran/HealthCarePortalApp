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
        Task<List<PatientMedicationInfoModel>> GetPatientMedications(int id);
        Task<List<PatientProviderInfoModel>> GetPatientProviders(int id);
        Task<PatientModel> CreatePatient(PatientModel patientModel);
        Task <PatientModel> GetPatient(int id);
        Task<bool> PatientModelExists(int id);
        Task UpdatePatient(PatientModel patientModel);
        Task DeletePatient(int id);

           
    }
    public class PatientService : IPatientService
    {

        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<List<PatientModel>> GetPatients() => _patientRepository.GetPatients();

        public Task<PatientModel> GetPatient(int id) => _patientRepository.GetPatient(id);

        public Task<PatientModel> CreatePatient(PatientModel patientModel) => _patientRepository.CreatePatient(patientModel);

        public Task UpdatePatient(PatientModel patientModel) => _patientRepository.UpdatePatient(patientModel);

        public Task DeletePatient(int id) => _patientRepository.DeletePatient(id);

        public Task<bool> PatientModelExists(int id) => _patientRepository.PatientModelExists(id);

        public Task<List<PatientMedicationInfoModel>> GetPatientMedications(int id) =>
            _patientRepository.GetPatientMedicationInfo(id);

        public Task<List<PatientProviderInfoModel>> GetPatientProviders(int id) => _patientRepository.GetPatientProviderInfo(id);
      
    }
}

