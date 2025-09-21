using HealthCarePortalApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCarePortalApp.Database.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<MedicationModel> Medications { get; set; } 
        public DbSet<ProviderModel> Providers { get; set; }
        public DbSet<PatientMedicationModel> PatientMedications { get; set; }
        
    }
}
 