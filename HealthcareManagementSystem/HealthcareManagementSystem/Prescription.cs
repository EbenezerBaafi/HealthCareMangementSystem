using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareManagementSystem
{
    public class Prescription
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string MedicationName { get; set; }
        public DateTime DateIssued { get; set; }

        // Constructor to initialize a new prescription
        public Prescription(int id, string patientId, string medicationName, DateTime dateIssued)
        {
            Id = id;
            PatientId = patientId;
            MedicationName = medicationName;
            DateIssued = dateIssued;
        }
    }
}
