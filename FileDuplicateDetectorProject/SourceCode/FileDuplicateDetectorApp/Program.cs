/*INPUT: string(directory name)    OUTPUT: A directory named "duplicates" within the input directory
 * 
 * DESCRIPTION:
 * Given a directory name, sort all duplicate files in the directory into a folder named "duplicates".
 * 
 * Given a directory name, 
 * get all files in directory name, create a new directory within the input directory named "duplicates",
 * for each file name check has digit surrounded by parenthesis or has "Copy", if yes then move 
 * duplicate file into the new sub directory.
 * 
 * NOTES: 
 * Validate input directory name 
 */
string? targetDirectory = "";
string[]? allFiles = null;
string? duplicateDirectory = null;


Console.WriteLine("Input valid directory to search for duplicates in: ");
targetDirectory = Console.ReadLine();
while (Directory.Exists(targetDirectory) == false)
{
    Console.WriteLine("Invalid directory, please input valid directory to search for duplicates in: ");
    targetDirectory = Console.ReadLine();
}

allFiles = Directory.GetFiles(targetDirectory, "*", SearchOption.AllDirectories);

duplicateDirectory = targetDirectory + @"\duplicates";
Directory.CreateDirectory(duplicateDirectory);

Console.WriteLine("\nProcessing files...");

for (int i = 0; i < allFiles.Length; i++)
{
    string fileName = Path.GetFileNameWithoutExtension(allFiles[i]);
    string extensionName = Path.GetExtension(allFiles[i]);
    if ((allFiles[i].Contains("(") && allFiles[i].Contains(")") && allFiles[i].Any(char.IsDigit)) || allFiles[i].Contains("Copy"))
    {
        if (File.Exists(duplicateDirectory + $"\\{fileName}{extensionName}") == false)
        {
            File.Move(allFiles[i], duplicateDirectory + $"\\{fileName}{extensionName}");
        }
        
    }
}
Console.WriteLine("\nCheck input directory for a duplicates folder, your duplicates have been moved there");
Console.Write("Press any key to exit...");
Console.ReadLine();
