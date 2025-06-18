using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FarmManagementSystem
{
    internal class Admin : Person, IAccount, IManagement
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "animals.txt");
       
        public Admin(string Name, int Age, string ID) : base(Name, Age, ID) { }

        public bool Login(string username, string password)
        {
            if (username == "admin" && password == "admin123")
                return true;
            else
                throw new InvalidLoginException("Invalid login details.");
        }
      
        
        public string SearchByID(string id)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string findID = line.Substring(0, line.IndexOf(" "));
                if (findID == id.ToString())
                    return line;
            }
            return "";
        }
        public void AddAnimal(string AnimalID, string AnimalName, int AnimalAge, string Species)
        {
            if (SearchByID(AnimalID) == "")
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    Animal animal = new Animal(AnimalID, AnimalName, AnimalAge, Species);
                    string addLine = AnimalID.ToString() + " " + AnimalName +" " + AnimalAge.ToString() + " " +  Species.ToString();
                    writer.WriteLine(addLine);

                    Console.WriteLine($"Animal of ID {AnimalID} has been added to the repository.");

                }
            }

            else
                Console.WriteLine($"Animal of ID {AnimalID} already exists.");
        }

        public void RemoveAnimal(string AnimalID)
        {
            if (SearchByID(AnimalID) != "")
            {
                List<string> animals = new List<string>(); // A list to store animals
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (line.Substring(0, line.IndexOf(" ")) != AnimalID)
                        animals.Add(line);
                }
                if (File.Exists(filePath))            
                    File.WriteAllLines(filePath, animals);
                Console.WriteLine($"{AnimalID} has been removed from the repository.");
            }
            else
                Console.WriteLine($"Animal of ID {AnimalID} does not exist.");
        }

        public void UpdateName(string AnimalID, string UpdatedName)
        {
            if (SearchByID(AnimalID) != "")
            {
                List<string> animals = new List<string>(); // A list to store animals
                
                string[] lines = File.ReadAllLines(filePath);
                string updatedLine = "";
                foreach (string line in lines)
                {
                    if (line.Substring(0, line.IndexOf(" ")) != AnimalID)
                        animals.Add(line);
                    else
                    {
                        string[] words = line.Split(' ');
                        updatedLine = words[0] + " " + UpdatedName + " " + words[2] + " " + words[3];   
                    }
                }
                animals.Add(updatedLine);

                if (File.Exists(filePath))
                    File.WriteAllLines(filePath, animals);
                Console.WriteLine($"{AnimalID}'s name has been updated.");

            }
            else
                Console.WriteLine($"Animal of ID {AnimalID} does not exist.");
        }

        public void UpdateAge(string AnimalID, int UpdatedAge)
        {
            if (SearchByID(AnimalID) != "")
            {
                List<string> animals = new List<string>(); // A list to store animals
                string[] lines = File.ReadAllLines(filePath);
                string updatedLine = "";
                foreach (string line in lines)
                {
                    if (line.Substring(0, line.IndexOf(" ")) != AnimalID)
                        animals.Add(line);
                    else
                    {
                        string[] words = line.Split(' ');
                        updatedLine = words[0] + " " + words[1] + UpdatedAge + " " + words[3];
                    }
                }
                animals.Add(updatedLine);

                if (File.Exists(filePath))
                    File.WriteAllLines(filePath, animals);
                Console.WriteLine($"{AnimalID}'s age has been updated.");
            }
            else
                Console.WriteLine($"Animal of ID {AnimalID} does not exist.");
        }

        public void UpdateSpecies(string AnimalID, string UpdatedSpecies)
        {
            if (SearchByID(AnimalID) != "")
            {
                List<string> animals = new List<string>(); // A list to store animals
                string[] lines = File.ReadAllLines(filePath);
                string updatedLine = "";
                foreach (string line in lines)
                {
                    if (line.Substring(0, line.IndexOf(" ")) != AnimalID)
                        animals.Add(line);
                    else
                    {
                        string[] words = line.Split(' ');
                        updatedLine = words[0] + " " + words[1] + " " + words[2] + " " + UpdatedSpecies;
                    }
                }
                animals.Add(updatedLine);

                if (File.Exists(filePath))
                    File.WriteAllLines(filePath, animals);
                Console.WriteLine($"{AnimalID}'s species has been updated.");
            }
            else
                Console.WriteLine($"Animal of ID {AnimalID} does not exist.");
        }

        public void ListAnimals()
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] words = line.Split(' ');
                    if (words.Length == 4)
                    {
                        Console.WriteLine($"ID: {words[0]}\tName: {words[1]}\tAge: {words[2]}\tSpecies: {words[3]}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid line format: " + line);
                    }
                }
            }
        }

    }
}