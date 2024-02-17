using PasswordManager.Manager.PasswordArchiveManager;
using PasswordManager.Manager.PasswordArchiveManager.Interfaces;
using System;

class Program
{
    static void Main()
    {
        IArchiveManager archiveManager = new ArchiveManager();
        Console.WriteLine("Welcome to Saker!");
        Console.WriteLine("Choose an Option:");
        Console.WriteLine("1. Setup your new Password Arrchive!");
        Console.WriteLine("2. Add Path of your archive!");
        Console.WriteLine("3. Upload your archive on Cloud");

        string scelta = Console.ReadLine();

        switch (scelta)
        {
            case "1":
                Console.WriteLine("Your choice: Setup your new Password Arrchive!");
                Console.WriteLine("Please input the full path where you want to create the new archive:");
                string path = Console.ReadLine();
                string fileName = "SakerPassword - Archive.json";
                string fullPath = Path.Combine(path, fileName);
                archiveManager.CreateNewArchive(fullPath);
                break;
            case "2":
                Console.WriteLine("Your choice: Add Path of your archive!");
                break;
            case "3":
                Console.WriteLine("Your choice: Upload your archive on Cloud");
                break;
            default:
                Console.WriteLine("Wrong choice! Select a valid number!");
                break;
        }
    }
}