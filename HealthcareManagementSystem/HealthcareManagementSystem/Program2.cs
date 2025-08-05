using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HealthcareManagementSystem
{
    class Program2
    {
        // Retrieve the list of prescriptions for the specified patient ID.
        // If patient ID is not found, return an empty list.
        public List<Prescription> GetPrescriptionsByPatientId(int PatientID)
        {
            if (patientPrescription.TryGetValue(PatientID, out var prescriptions))
            {
                return prescriptions;
            }
            else
            {
                return new List<Prescription>();
            }
        }

        // Dictionary to store prescriptions for each patient.
        // Key: Patient ID, Value: List of prescriptions issued to that patient.
        private Dictionary<int, List<Prescription>> patientPrescription = new Dictionary<int, List<Prescription>>();

        public void AddPrescription(Prescription prescription)
        {
            // Fix for CS1503: Convert prescription.PatientId from string to int
            if (int.TryParse(prescription.PatientId, out int patientId))
            {
                if (patientPrescription.ContainsKey(patientId))
                {
                    patientPrescription[patientId].Add(prescription);
                }
                else
                {
                    // Fix for IDE0028: Simplify collection initialization
                    patientPrescription[patientId] = new List<Prescription> { prescription };
                }
            }
            else
            {
                throw new ArgumentException("Invalid PatientId. It must be convertible to an integer.");
            }
        }
    }
}

