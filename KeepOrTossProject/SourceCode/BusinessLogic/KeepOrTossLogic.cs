using System;
using System.IO;
using System.Collections.Generic;


namespace BusinessLogic
{
    public class KeepOrTossLogic
    {
        public string inputDirectory;
        public List<string> allImageFiles;
        public string deletionDirectory;
        public KeepOrTossLogic() {
            inputDirectory = " ";
            allImageFiles = new List<string>();
            deletionDirectory = " ";
        }
        public bool VerifyDirectory(string directory)
        {
            return Directory.Exists(directory);
        }

        public List<string> GetAllImageFiles(string directory)
        {
            string[] imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".jfif", ".JPG", ".JPEG", ".PNG" };

            List<string> files = Directory
                .GetFiles(directory, "*", SearchOption.AllDirectories)
                .Where(file => imageExtensions.Any(file.ToLower().EndsWith))
                .ToList();

            return files;
        }

        //TODO: check if this works - it works
        public string CreateDeletionDirectory(string directoryName, string destinationDirectory)
        {
            Directory.CreateDirectory($"{destinationDirectory}\\{directoryName}");
            return $"{destinationDirectory}\\{directoryName}";
        }

        public void MoveFileIntoDirectory(string file, string destinationDirectory)
        {
            string fileName = Path.GetFileName(file);
            if (File.Exists($"{destinationDirectory}\\{fileName}") == false)
            {
                Directory.Move(file, $"{destinationDirectory}\\{fileName}");
            } 
            
        }

    }
}
