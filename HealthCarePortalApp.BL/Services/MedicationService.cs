using HealthCarePortalApp.BL.Repositories;
using HealthCarePortalApp.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCarePortalApp.BL.Services
{
    public interface IMedicationService
    {
        Task <MedicationModel>CreateMedication(MedicationModel medicationtModel);
        Task<PatientMedicationModel> CreatePatientMedication(PatientMedicationModel patientMedicationtModel);
        Task<List<MedicationModel>> GetMedications();
        Task DeleteMedication(int id);
        Task<bool> MedicationModelExists(int id);
    }
    public class MedicationService(IMedicationRepository medicationRepository) : IMedicationService
    {
        public async Task<MedicationModel> CreateMedication(MedicationModel medicationtModel)
        {
            var medication = await medicationRepository.CreateMedication(medicationtModel);
            return medication;
        }

        public async Task<PatientMedicationModel> CreatePatientMedication(PatientMedicationModel patientMedicationtModel)
        {
            var patientMedication = await medicationRepository.CreateMedicationAssignment(patientMedicationtModel);
            return patientMedication;
        }

        public Task DeleteMedication(int id)
        {
            return medicationRepository.DeleteMedication(id);
        }

        public Task<List<MedicationModel>> GetMedications()
        {
            return medicationRepository.GetMedications();
        }

        public Task<bool> MedicationModelExists(int id)
        {
            return medicationRepository.MedicationModelExists(id);
        }
    }
}
