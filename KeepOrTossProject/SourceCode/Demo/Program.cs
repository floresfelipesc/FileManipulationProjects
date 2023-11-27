using BusinessLogic;
public class Program
{
    //REMEMBER TO RID OF ANY USELESS USING STATEMENTS 
    //EX MAIN UI SHOUlD NOT HAVE USING STATEMENTS FOR INPUT/OUTPUT, CHECK GLOBAl USINGS AT THE BEGINNING
    //EVERYTIME
    private static void Main(string[] args)
    {
        string? rawUserInput = " ";
        KeepOrTossLogic logic = new KeepOrTossLogic();

        Console.WriteLine("Input existing directory to search for all images: ");

        rawUserInput = Console.ReadLine();

        while (rawUserInput == null || logic.VerifyDirectory(rawUserInput) == false)
        {
            Console.WriteLine("Directory does not exist, input existing directory to search for all images: ");
            rawUserInput = Console.ReadLine();
        }
        logic.inputDirectory = rawUserInput;

        logic.allImageFiles = logic.GetAllImageFiles(logic.inputDirectory);

        logic.deletionDirectory = logic.CreateDeletionDirectory("ToToss", logic.inputDirectory);

        //display each image and prompt user to keep or delete that image
        for (int i = 0; i < logic.allImageFiles.Count; i++)
        {
            Console.WriteLine(logic.allImageFiles[i]);
            Console.WriteLine("Keep or Delete? (O/P)");
            rawUserInput = Console.ReadLine();
            if(rawUserInput != null) rawUserInput = rawUserInput.ToUpper();

            while (rawUserInput == null || rawUserInput.Equals("O") == false && rawUserInput.Equals("P") == false)
            {
                Console.WriteLine("Invalid input, Keep Or Delete? (O/P)");
                if (rawUserInput != null) rawUserInput = rawUserInput.ToUpper();
            }

            if (rawUserInput.Equals("P"))
            {
                //delete
                logic.MoveFileIntoDirectory(logic.allImageFiles[i], logic.deletionDirectory);
            }

        }

        Console.WriteLine("You have gotten through all the files!");
        Console.WriteLine("Press any key to exit...");


    }
   
}