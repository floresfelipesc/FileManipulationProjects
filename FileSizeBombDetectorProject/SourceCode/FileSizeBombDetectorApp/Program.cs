/*INPUT: Integer (number of bytes), String (directory name)    OUTPUT: List of Strings (filepaths)
 * 
 * DESCRIPTION: Given a threshold of bytes and a directory name, return all the directory names that
 *  have a larger size than the threshold of bytes 
 *  
 *  Given an integer of bytes and a string of directory name filepath,
 *  get all the filepaths within the desired directory, 
 *  get file size for each filepath.
 *  For each file size, if it's greater than the given int, 
 *  add to a list. 
 *  Return list of filepaths whose size is greater than the given int.
 *  
 *  NOTES:
 *  Verify if input directory name exists
 *  Perhaps put returning filepaths in a txt file within the same directory
 *  as the output
 * 
 */

int minBytes = 0;
string? rawInput = "";
string? targetDirectory = "";
string[] filePaths;
List<string> result = new List<string>();
string currentDirectory = Directory.GetCurrentDirectory();

//get input of bytes
Console.WriteLine("Please input integer number of bytes to search for: ");
rawInput = Console.ReadLine();

while (int.TryParse(rawInput, out minBytes) == false)
{   //validate input
    Console.WriteLine("INVALID INPUT, please input integer number of bytes to search for: ");
    rawInput = Console.ReadLine();
}


//get input of desired directory name
Console.WriteLine("Please input desired directory path to search for: ");
targetDirectory = Console.ReadLine();

while (Directory.Exists(targetDirectory) == false)
{
    Console.WriteLine("Directory path does not exist, please input valid directory path to search in");
    targetDirectory = Console.ReadLine();
}


//get all file paths 
filePaths = Directory.GetFiles(targetDirectory, "*", SearchOption.AllDirectories);

//compare each filepath size to target
for (int i = 0; i < filePaths.Length; i++)
{
    //get file sizes
    FileInfo fileInfo = new FileInfo(filePaths[i]);
    if (fileInfo.Length >= minBytes)
    {
        result.Add(filePaths[i]);
    }
}

//write results to txt file in directory
File.WriteAllLines(currentDirectory + @"\output.txt", result);
Console.WriteLine("\nCheck in project files for output.txt for your filepaths whose size exceed the target bytes");
Console.WriteLine("Press any key to exit...");

Console.ReadLine();