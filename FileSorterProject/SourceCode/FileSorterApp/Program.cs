/*INPUT:string (desired filepath)      OUTPUT: string (telling user what happened)
 * 
 * DESCRIPTION:
 * Given a filepath of a folder, categorize each file type into cooresponding subfolders.
 * 
 * Validate input filepath of folder. 
 * Within the input filepath of folder, create subfolders for each distinct type of file, 
 * and move each file into their coresponding subfolder. 
 * 
 * NOTES: 
 * Filepath should be validated as a valid directory
 * Subfolders within the input folder should have the name of the type of file they contain 
 * How to create directory?
 * How to move files? 
 * 
 */
string? folderPath = "";
List<string> filePaths = new List<string>();
//file extension and subfolder path
Dictionary<string, string> existingFileExtensions = new Dictionary<string, string>();

//VALIDATION
Console.WriteLine("Please paste filepath of existing folder within your system: ");
folderPath = Console.ReadLine();
while (Directory.Exists(folderPath) == false)
{ 
    Console.WriteLine("Invalid folder path, please input valid path of desired folder");
    folderPath = Console.ReadLine();
}

//get each distinct type of file and create cooresponding subfolder paths
filePaths = Directory.GetFiles(folderPath).ToList();
Console.Write("\nFiles Detected: 0");
for (int i = 0; i < filePaths.Count; i++)
{
    string fileExtension = Path.GetExtension(filePaths[i]);

    if (existingFileExtensions.ContainsKey(fileExtension) == false)
    {
        existingFileExtensions.Add(fileExtension, folderPath + @"\" + fileExtension);
    }
    //show live progress of files
    UpdateLiveProgress("Files Detected: ", i+1);
}

//create subfolders for each file extension
foreach (KeyValuePair<string, string> entry in existingFileExtensions)
{
    if (Directory.Exists(entry.Value) == false)
    {
        Directory.CreateDirectory(entry.Value);
    }
}

Console.Write("\nFiles Moved: 0");
//move all files into their respective subfolder 
for (int i = 0; i < filePaths.Count; i++) 
{
    string fileExtension = Path.GetExtension(filePaths[i]);
    string fileName = Path.GetFileNameWithoutExtension(filePaths[i]);
    string destinationPath = existingFileExtensions[fileExtension] + "\\" + fileName + fileExtension;

    if(File.Exists(destinationPath) == false)
    {
        Directory.Move(filePaths[i], destinationPath);
    }
    //show live progress of files 
    UpdateLiveProgress("Files Moved: ", i+1);
}

Console.WriteLine("\n\nOperation complete!");
Console.Write("Press any key to close the application...");
Console.ReadLine();
//=============================================================================
void UpdateLiveProgress(string message, int fileNum)
{
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write($"{message}{fileNum}");
}


