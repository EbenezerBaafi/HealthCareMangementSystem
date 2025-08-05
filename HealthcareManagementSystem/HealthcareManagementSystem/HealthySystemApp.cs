using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareManagementSystem
{
    public class HealthySystemApp
    {
        // Generic Repositories to manage patient records
        public Repository<Patient> _patientRepo;

        // Generic Repositories to manage Prescription records
        public Repository<Prescription> _prescriptionRepo;

        // Dictionary to map Patient Ids to their list of prescription
        public Dictionary<int, List<Prescription>> _prescriptionMap;

        // Constructor to initialize the repositories and prescription map
        public HealthySystemApp()
        {
            _patientRepo = new Repository<Patient>();
            _prescriptionRepo = new Repository<Prescription>();
            _prescriptionMap = new Dictionary<int, List<Prescription>>();
        }

        // Method to add a new patient

        public void SeedData()
        {
            // Add patients object to the repository
            _patientRepo.Add(new Patient(1, "Afia", 21, "Male"));
            _patientRepo.Add(new Patient(2, "Akua", 24, "Female"));
            _patientRepo.Add(new Patient(3, "Kwaku", 22, "Male"));

            // Add prescriptions object to the repository
            _prescriptionRepo.Add(new Prescription( 1, "patient1", "Paracetamol",new  DateTime(2025, 09, 12)));
            _prescriptionRepo.Add(new Prescription( 2, "patient2", "Taabea", new DateTime(2025, 11,8)));
            _prescriptionRepo.Add(new Prescription( 3, "patient3", "Blood Tonic", new DateTime(2025, 12, 09)));
            _prescriptionRepo.Add(new Prescription( 4, "patient4", "Ginseng bitters", new DateTime(2025, 05, 21)));
            _prescriptionRepo.Add(new Prescription(4, "patient5", "Adonko Atadwe Ginger", new DateTime(2025, 03, 18)));

        }

        public void BuildPrescriptionMap()
        {
            // Clear existing map in case method is called multiple times
            _prescriptionMap.Clear();

            // Fetch all prescriptions from the repository
            List<Prescription> prescriptions = _prescriptionRepo.GetAll();

            // Iterate through each prescription
            foreach (var prescription in prescriptions)
            {
                string patientId = prescription.PatientId;

                // Check if the patient ID already exists in the map
                if (_prescriptionMap.ContainsKey(prescription.Id))
                {
                    // Add existing prescription to the patient's list
                    _prescriptionMap[prescription.Id].Add(prescription);
                }
                else
                {
                    // Create a new list for the patient and add the prescription
                    _prescriptionMap[prescription.Id] = new List<Prescription> { prescription };
                }
            }
        }

        //Print all patients in the system
        public void PrintAllPatients()
        {
            Console.WriteLine("All Patients.");

            foreach (var patient in _patientRepo.GetAll())
            {
                Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}");
            }
        } 
        
        public void PrintAllPrescriptionsForPatient(int patientId)
        {
            if (_prescriptionMap.TryGetValue(patientId, out var prescriptions))
            {               
                Console.WriteLine($"Prescriptions for Patient ID {patientId}:");
                foreach (var prescription in prescriptions)
                {
                    Console.WriteLine($"Id: {prescription.Id}, Medication: {prescription.MedicationName}, Date Issued: {prescription.DateIssued}");
                }
            }
            else
            {
                Console.WriteLine($"No prescriptions found for Patient ID {patientId}.");
            }
        }
    }
}
