using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagementSystem
{
    internal class Farmer: Person, IAccount
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "animals.txt");
        public Farmer(string Name, int Age, string ID) : base(Name, Age, ID) { }
        
        public bool Login(string username, string password)
        {
            if (username == "farmer1" && password == "farmer123")
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
        public void viewAnimalDetails(string AnimalID)
        {
            Console.WriteLine("ID  Name  Age  Species:");
            Console.WriteLine(SearchByID(AnimalID) != "" ? SearchByID(AnimalID) : $"Error: {AnimalID} does not exist.");
        }
        public void viewAllAnimalsDetails()
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
