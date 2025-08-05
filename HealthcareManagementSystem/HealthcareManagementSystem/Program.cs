

using System.Threading.Channels;

namespace HealthcareManagementSystem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("App started.");
            // instantiate the HealthySystemApp
            HealthySystemApp healthySystemApp = new HealthySystemApp();

            // Seed the data
            healthySystemApp.SeedData();

            // Build the prescription map
            healthySystemApp.BuildPrescriptionMap();

            // Prints all patients 
            Console.WriteLine("Patients:");
            healthySystemApp.PrintAllPatients();

            // Select a patient to view their prescriptions
            Console.WriteLine("Enter Patient ID to view prescriptions:");
            if (int.TryParse(Console.ReadLine(),out int patientId))
            {
                healthySystemApp.PrintPrescriptionsForPatient(patientId);
            }
            else
            {
                Console.WriteLine("Invalid Patient ID. Please enter a valid integer.");
            }

        }
    }
}