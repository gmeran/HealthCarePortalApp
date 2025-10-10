using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCarePortalApp.Model.Entities
{
    public class PatientProviderModel
    {
        public int? ID { get; set; }
        public int ProviderID { get; set; }
        public int PatientID { get; set; }
    }
}
