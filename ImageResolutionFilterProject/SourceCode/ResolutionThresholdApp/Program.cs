/*INPUT: Directory containing various types of image files 
 * OUTPUT: Directory within input directory that contains files
 * INPUT: string 
 * OUTPUT: Created Directory with files
 * 
 * Given the path of a directory, check each image file within the directory to see if its dimensions
 * exceeds 1920 x 1080. If it does not, then move the image file into a new subfolder.
 * 
 * Given the path of a directory, 
 * get all files within the target directory with image file extensions,
 * check each file if its resolution exceeds 1920 by 1080. 
 * Create a new subfolder within the target directory.
 * If the file does not exceed, then move the file into the new subfolder within the target directory,
 * if yes then do nothing.
 * 
 * 
 * 
 * NOTES:
 * Verify input path of directory
 * 
 */
using System.Drawing;


string? rawInput = "";
string? targetDirectory = "";
string subfolder = "excluded";
List<string> imageFiles = new List<string>();
int desiredWidth = 0;
int desiredHeight = 0;

Console.WriteLine("Please input an existing directory on your machine: ");
rawInput = Console.ReadLine();
//verify directory
while (Directory.Exists(rawInput) == false)
{
    Console.WriteLine("\nInvalid directory, try again: ");
    rawInput = Console.ReadLine();
}
targetDirectory = rawInput;


Console.WriteLine("\nPlease input desired width minimum for the filter: ");
rawInput = Console.ReadLine();

while (Int32.TryParse(rawInput, out desiredWidth) == false)
{
    Console.WriteLine("\nInput invalid, please input an integer for width minimum: ");
    rawInput = Console.ReadLine();
}

Console.WriteLine("\nPlease input desired height minimum for the filter: ");
rawInput = Console.ReadLine();

while (Int32.TryParse(rawInput, out desiredHeight) == false)
{
    Console.WriteLine("\nInput invalid, please input an integer for height minimum: ");
    rawInput = Console.ReadLine();
}


//get all image files in target directory
imageFiles = GetImageFiles(targetDirectory);


//create subfolder in target directory named "excluded"
if (Directory.Exists(targetDirectory + @"\" + subfolder) == false)
{
    Directory.CreateDirectory(targetDirectory + @"\" + subfolder);
}
Console.WriteLine($"\nSorting images below {desiredWidth} by {desiredHeight} into \"excluded\" subfolder within input existing directory...");
//check each resolution
for (int i = 0; i < imageFiles.Count; i++)
{
    Bitmap bitmap = new Bitmap(imageFiles[i]);
    string fileName = Path.GetFileName(imageFiles[i]);

    
    if (bitmap.Width < desiredWidth || bitmap.Height < desiredHeight)
    {
        //TO DO
        bitmap.Dispose();
        File.Move(imageFiles[i], targetDirectory + "\\" + subfolder + "\\" + fileName);
    }
    
}
Console.WriteLine("\nSorting complete, check the \"excluded\" subfolder within the input existing directory!");
Console.Write("Press any key to exit the application...");
Console.ReadKey();
//TO DO: General output to console to indicate various processes

static List<string> GetImageFiles(string targetDirectory)
{
    List<string> allImageFiles = new List<string>();
    List<string> allFiles = new List<string>();
    
    allFiles = Directory.GetFiles(targetDirectory, "." , SearchOption.TopDirectoryOnly).ToList();
    foreach (string entry in allFiles )
    {
        string extension = Path.GetExtension(entry);
        if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".jfif")
        {
            allImageFiles.Add(entry);
        }
    }

    return allImageFiles;
}


