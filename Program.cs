using System;
using System.Collections.Generic;
namespace FarmManagementSystem
{
    internal class Program 
    {
        static string ReadInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }

            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        static void Main(string[] args)
        {
            bool running = true;
            bool adminRunning = false;
            bool farmerRunning = false;
            bool updateRunning = false;
            int type, menuChoice, updateChoice;
            
            while (running)
            {  
                bool validType = false;
                type = 0;
                while (!validType)
                {
                    Console.WriteLine("What type of user are you? (Choose):\n  1: Admin \n  2: Farmer\n  3: Exit main menu");
                    try
                    {
                        type = Convert.ToInt32(Console.ReadLine());
                        validType = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a number (1-3).");
                    }
                }

                string username, password, id;
                int age = 0;
                switch (type)
                {
                    case 1:
                        
                        username = ReadInput("Enter your username: ");
                        password = ReadInput("Enter your password: ");
                        bool isValidAge = false;
                        Admin admin = new Admin(username, 0, "");

                        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                            throw new ArgumentException("username or password must not be null or empty.");

                        else
                        {
                            try
                            {
                                if (admin.Login(username, password))
                                {
                                    Console.WriteLine("You have successfully logged in as admin.");

                                    while (!isValidAge)
                                    {
                                        Console.Write("Enter your age: ");
                                        try
                                        {
                                            age = Convert.ToInt32(Console.ReadLine());
                                            if (age <= 0)
                                            {
                                                throw new InvalidNumberException("Age must be a positive number greater than 0.");
                                            }
                                            isValidAge = true; // Success! Exit loop
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Invalid input. Please type only numbers (e.g., 25).");
                                        }
                                        catch (InvalidNumberException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("An unexpected error occurred: " + ex.Message);
                                        }
                                    }

                                    id = ReadInput("Enter your id: ");
                                    admin = new Admin(username, age, id);
                                    adminRunning = true;
                                    string animalId;
                                    int animalAge;
                                    string animalName = "";
                                    string species = "";
                                    while (adminRunning)
                                    {
                                        bool validAdminMenuChoice = false;
                                        menuChoice = 0;
                                        while (!validAdminMenuChoice)
                                        {
                                            Console.WriteLine("Admin Menu:\n  1: Add new animal\n  2: Remove animal\n  3: View list of animals\n  4: Update animal details\n  5: Exit admin menu");
                                            try
                                            {
                                                menuChoice = Convert.ToInt32(Console.ReadLine());
                                                validAdminMenuChoice = true;
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Invalid input. Please enter a number (1-5).");
                                            }
                                        }
                                        switch (menuChoice)
                                        {
                                            case 1:
                                                animalId = ReadInput("Enter animal ID: ");
                                                animalName = ReadInput("Enter animal name: ");
                                                animalAge = 0;
                                                isValidAge = false;
                                                while (!isValidAge)
                                                {
                                                    Console.Write("Enter animal age: ");
                                                    try
                                                    {
                                                       animalAge = Convert.ToInt32(Console.ReadLine());
                                                        if (animalAge <= 0)
                                                        {
                                                            throw new InvalidNumberException("Age must be a positive number greater than 0.");
                                                        }
                                                        isValidAge = true; // Success! Exit loop
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Invalid input. Please type only numbers (e.g., 25).");
                                                    }
                                                    catch (InvalidNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine("An unexpected error occurred: " + ex.Message);
                                                    }
                                                }
                                                species = ReadInput("Enter animal species: ");
                                               
                                                admin.AddAnimal(animalId, animalName, animalAge, species);
                                                break;
                                            case 2:
                                                animalId = ReadInput("Enter animal ID to remove animal: ");
                                                admin.RemoveAnimal(animalId);
                                                break;
                                            case 3:
                                                admin.ListAnimals();
                                                break;
                                            case 4:
                                                updateRunning = true;
                                                while (updateRunning)
                                                {
                                                    bool validUpdateChoice = false;
                                                    updateChoice = 0;
                                                    while (!validUpdateChoice)
                                                    {
                                                        Console.WriteLine("Update:\n  1: Name\n  2: Age\n  3: Species\n  4: Exit");
                                                        try
                                                        {
                                                            updateChoice = Convert.ToInt32(Console.ReadLine());
                                                            validUpdateChoice = true;
                                                        }
                                                        catch (FormatException)
                                                        {
                                                            Console.WriteLine("Invalid input. Please enter a number (1-4).");
                                                        }
                                                    }
                                                    switch (updateChoice)
                                                    {
                                                        case 1:
                                                            animalId = ReadInput("Enter animal id: ");
                                                            
                                                            string updatedName = ReadInput("Enter updated name: ");
                                                            admin.UpdateName(animalId, updatedName);
                                                            break;
                                                        case 2:
                                                            animalId = ReadInput("Enter animal id: ");
                                                            isValidAge = false;
                                                            int updatedAge = 0;
                                                            while (!isValidAge)
                                                            {
                                                                Console.Write("Enter updated age: ");
                                                                try
                                                                {
                                                                    updatedAge = Convert.ToInt32(Console.ReadLine());
                                                                    if (updatedAge <= 0)
                                                                    {
                                                                        throw new InvalidNumberException("Age must be a positive number greater than 0.");
                                                                    }
                                                                    isValidAge = true; // Success! Exit loop
                                                                }
                                                                catch (FormatException)
                                                                {
                                                                    Console.WriteLine("Invalid input. Please type only numbers (e.g., 25).");
                                                                }
                                                                catch (InvalidNumberException ex)
                                                                {
                                                                    Console.WriteLine(ex.Message);
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                                                                }
                                                            }
                                                            admin.UpdateAge(animalId, updatedAge);
                                                            break;
                                                        case 3:
                                                            animalId = ReadInput("Enter animal id: ");
                                                            
                                                            string updateSpecies = ReadInput("Enter updated species: ");
                                                            admin.UpdateSpecies(animalId, updateSpecies);
                                                            break;
                                                        case 4:
                                                            updateRunning = false;
                                                            Console.WriteLine("Exiting update menu...");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case 5:
                                                adminRunning = false;
                                                Console.WriteLine("Exiting admin menu...");
                                                break;
                                            default:
                                                Console.WriteLine("Invalid menu option selected.");
                                                break;
                                        }
                                    }
                                }
                            }
                            catch(InvalidLoginException ex)
                            {
                                Console.WriteLine(ex.Message);

                            }

                        }
                        break;
                    case 2:

                        username = ReadInput("Enter your username: ");
                        password = ReadInput("Enter your password: ");
                        isValidAge = false;
                        Farmer farmer = new Farmer(username, 0, "");
                        
                        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                        
                            throw new Exception("username or password must not be null or empty.");
                        
                        else
                        {
                            try
                            {
                                if (farmer.Login(username, password))
                                {
                                    Console.WriteLine("You are successfully logged in as a farmer.");

                                    while (!isValidAge)
                                    {
                                        Console.Write("Enter your age: ");
                                        try
                                        {
                                            age = Convert.ToInt32(Console.ReadLine());
                                            if (age <= 0)
                                            {
                                                throw new InvalidNumberException("Age must be a positive number greater than 0.");
                                            }
                                            isValidAge = true; // Success! Exit loop
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Invalid input. Please type only numbers (e.g., 25).");
                                        }
                                        catch (InvalidNumberException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("An unexpected error occurred: " + ex.Message);
                                        }
                                    }

                                    id = ReadInput("Enter your id: ");

                                    farmer = new Farmer(username, age, id);
                                    farmerRunning = true;
                                    string animalId;
                                    while (farmerRunning)
                                    {
                                        bool validFarmerMenuChoice = false;
                                        menuChoice = 0;
                                        while (!validFarmerMenuChoice)
                                        {
                                            Console.WriteLine("Farmer Menu:\n  1: View details on animal (specified) by ID\n  2: View details of all animals\n  3: Exit farmer menu");
                                            try
                                            {
                                                menuChoice = Convert.ToInt32(Console.ReadLine());
                                                validFarmerMenuChoice = true;
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Invalid input. Please enter a number (1-5).");
                                            }
                                        }
                                        switch (menuChoice)
                                        {
                                            case 1:
                                                animalId = ReadInput("Enter animal id: ");
                                                farmer.viewAnimalDetails(animalId);
                                                break;
                                            case 2:
                                                farmer.viewAllAnimalsDetails();
                                                break;
                                            case 3:
                                                farmerRunning = false;
                                                Console.WriteLine("Exiting farmer menu...");
                                                break;
                                            default:
                                                Console.WriteLine("Invalid menu option selected.");
                                                break;
                                        }
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 3:
                        running = false;
                        Console.WriteLine("Exiting main menu...");
                        break;
                    case 4:
                        Console.WriteLine("Invalid menu option selected.");
                        break;


                }
            }
        }
    }
}
