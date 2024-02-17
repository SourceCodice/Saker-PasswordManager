using Newtonsoft.Json;
using PasswordManager.Manager.PasswordArchiveManager.Interfaces;
using PasswordManager.Models;

namespace PasswordManager.Manager.PasswordArchiveManager
{
    public class ArchiveManager : IArchiveManager
    {
        public void CreateNewArchive(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                StreamWriter file = File.CreateText(fullPath);

                var serializer = new JsonSerializer();
                serializer.Serialize(file, new ArchiveModel());

                file.Close();

                Console.WriteLine($"Password archive created successfully at: {fullPath}");

                string pathSettingsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PathSettings");
                Directory.CreateDirectory(pathSettingsFolder); // Crea la cartella PathSettings se non esiste
                string pathSettingsFile = Path.Combine(pathSettingsFolder, "ArchivePaths.txt");

                using (StreamWriter settingsWriter = new StreamWriter(pathSettingsFile, true))
                {
                    settingsWriter.WriteLine(fullPath);
                }
            }
            else
            {
                Console.WriteLine($"The password archive already exists at the specified path: {fullPath}");
            }
        }
    }
}