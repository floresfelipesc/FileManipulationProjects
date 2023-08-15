/*Make a HollyWood Hacker Application
 * Given a txt file, display the text portions at a time sequentially in the same order at the
 * original if the users presses any keys on the keyboard. 
 * 
 * The console text must be green.
 * Once all of the text from the txt file has been displayed, display to the reader that the "hacking is complete".
 * The txt file must be verified, and if there is not text file, a default one with default text must be provided.
 * WAY BETTER^^
 * 1. The Application will run and set it's text color as green. It will also 
 * prep data for printing.
 *  1a. Set text color to green. Retrieve data from txt file in program structure
 * 
 * 2.Throughout runtime, the app reads for any and all key presses on the keyboard.
 * 
 * 3.When the user presses any key at anytime, a portion of fake hacker text will be displayed
 * 3a.When any key press, the program will display a portion of text from the txt file
 * located in the file structure of the program. 
 * 
 * 4. Display hacking complete message when all the text from the txt file has been displayed
 */

string defaultText = @"Commencing Hack...
12312.123.123.124.16574.34437.84.346.56547457.346
345.3.7.35323532.23523.523.432432.235.23634.7458.96.213.214437.
2342.523.5437.68.58.34643.659.65632.4326459.
Bypassing firewall...

while(leftPointer <= rightPointer){
    mid = (leftPointer + rightPointer) / 2;
    if(nums[mid] == target){
        return mid;
    }
    if(nums[mid] < target){
        leftPointer = mid + 1;
    }
    else{
        rightPointer = mid - 1;
    }
}
return -1;

Bypassing Firewall...
7932843.43634.745.82.52.524737547.4636436486524.3254236.
2425.346574.343.
3454353.34543.22.2365.24532.4.325.325.32.524.645.8.462435.32526437458745.753435.
Authorized...

for(int i = 0; i < nums.Length; i++){
    if(nums[i] == target){
        return i;
    }
}
Impressing bystanders...
2432.2352.4132468.23432
31678.1232.679
1678.2342.769
Encryption bypassed...

if(head == null || head.next == null){
    return head;
}

ListNode rest = ReverseList(head.next);
head.next.next = head;
head.next = null;
return rest;

Launching cybernuke...
142.198.144.115
198.126.160.110
219.149.72.171
Frying system...

Commiting crime...
234324.32643.23423.5.
232.432.5324.32.4
2342.758
Deleting homework...

Doing tomfoolery...
110.125.23.38
232.231.52.10
27.251.239.150
236.227.254.59
106.205.110.201
241.28.122.208
Stealing crypto...
";
string fileData = "";

string projectDirectory = Directory.GetCurrentDirectory();
string dataExtension = @"\hacker_text.txt";

int pointer1 = 0;
int pointer2 = 1;
int pointer3 = 2;

Console.ForegroundColor = ConsoleColor.Green;

//read data from txt file. if data does not exist, create data to read from

if (File.Exists(projectDirectory + dataExtension) == false)
{  
    File.WriteAllText(projectDirectory + dataExtension, defaultText);
    Console.WriteLine("No txt file to read from, txt file has been created with default text");
}

fileData = File.ReadAllText(projectDirectory + dataExtension);

//2. read all keyboard presses, if a key is pressed, print 3 chars of the retrived data

while (Console.ReadKey(true).Key != ConsoleKey.Escape && pointer3 < fileData.Length)
{
    Console.Write(fileData[pointer1]);
    Console.Write(fileData[pointer2]);
    Console.Write(fileData[pointer3]);
    pointer1 += 3;
    pointer2 += 3;
    pointer3 += 3;
}

Console.WriteLine("\nHACK COMPLETE");
Console.WriteLine("Press the enter key to finish hacking...");
Console.ReadLine();
