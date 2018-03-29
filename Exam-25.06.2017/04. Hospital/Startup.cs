namespace _04._Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, List<string>> departments = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "Output")
            {
                string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string department = inputParts[0];
                string doctor = $"{inputParts[1]} {inputParts[2]}";
                string patient = inputParts[3];

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<string>();
                }
                if (departments[department].Count < 60)
                {
                    departments[department].Add(patient);
                }

                if (!doctors.ContainsKey(doctor))
                {
                    doctors[doctor] = new List<string>();
                }
                doctors[doctor].Add(patient);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (inputParts.Length == 1)
                {
                    string searchedDepartment = inputParts[0];
                    foreach (KeyValuePair<string, List<string>> department in departments.Where(d => d.Key == searchedDepartment))
                    {
                        foreach (string patient in department.Value)
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else
                {
                    int room;
                    bool isParsed = int.TryParse(inputParts[1], out room);
                    if (isParsed)
                    {
                        string searchedDepartment = inputParts[0];
                        foreach (KeyValuePair<string, List<string>> department in departments.Where(d => d.Key == searchedDepartment))
                        {
                            List<string> patientInRoom = new List<string>();
                            int index = room * 3 - 3;
                            for (int i = index; i < index + 3; i++)
                            {
                                if (index < department.Value.Count)
                                {
                                    patientInRoom.Add(department.Value[i]);
                                }
                            }
                            foreach (string patient in patientInRoom.OrderBy(p => p))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                    else
                    {
                        string searchedDoctor = $"{inputParts[0]} {inputParts[1]}";
                        foreach (KeyValuePair<string, List<string>> doctor in doctors.Where(d => d.Key == searchedDoctor))
                        {
                            foreach (string patient in doctor.Value.OrderBy(p => p))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}