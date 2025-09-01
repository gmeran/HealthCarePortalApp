using HealthCarePortalApp.BL.Repositories;
using HealthCarePortalApp.Model.Entities;
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
        Task<List<MedicationModel>> GetMedications();
    }
    public class MedicationService(IMedicationRepository medicationRepository) : IMedicationService
    {
        public async Task<MedicationModel> CreateMedication(MedicationModel medicationtModel)
        {
            var medication = await medicationRepository.CreateMedication(medicationtModel);
            return medication;
        }

        public Task<List<MedicationModel>> GetMedications()
        {
            return medicationRepository.GetMedications();
        }
    }
}
