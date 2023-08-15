/*
 * INPUT: txt file aka a list of strings or a massive single string
 * OUTPUT: Two integers, one indicating character count, and another indicating word count
 * 
 * DESCRIPTION: Given a txt file, retrieve all text in the file, and count the number of characters and words
 * in the text. Return character count and word count.
 * 
 * Character count includes all characters that move the cursor signifying position in text
 * Word count includes all groups of characters separated by spaces, enters, periods, exclamations, question marks.
 * 
 * BREAKDOWN: 
 * 1. Read from txt file
 *   1a. Verify txt file exists, if not, create one. Alert user that txt file was created and to input txt in it. 
 *   
 * 2. Retrieve all text in file
 *       
 * 3. Count each character in data (including spaces and enters) 
 * 
 * 4. Count each word in data
 * 
 * 5. Output character count and word count
 */
string currentDirectory = Directory.GetCurrentDirectory();
string textFileExtension = @"\input.txt";

string[]? textLines = null;
string? textSingleLine = null;
FileStream? file = null;

int charCount = 0;
int charCountNoSpaces = 0;
int wordCount = 0;

if (!File.Exists(currentDirectory + textFileExtension))
{
    file = File.Create(currentDirectory + textFileExtension);
    file.Close();

    Console.WriteLine("input.txt file not located, created fresh input.txt in folder");
    Console.WriteLine("Please input your text in the input.txt file and run the program again");
    Console.WriteLine("Press any key to close program...");
    Console.ReadLine();
}
else
{
    textSingleLine = File.ReadAllText(currentDirectory + textFileExtension); 
    textLines = File.ReadAllLines(currentDirectory + textFileExtension);

    charCount = CountCharacters(textLines);
    charCountNoSpaces = CountCharactersNoSpaces(textLines);
    wordCount = CountWords(textSingleLine);

    Console.WriteLine($"Character Number (including whitespace): {charCount}");
    Console.WriteLine($"Character Number (excluding whitespace): {charCountNoSpaces}");
    Console.WriteLine($"Word Number: {wordCount}");

    Console.WriteLine("Press any key to close program...");
    Console.ReadLine();
}

int CountCharacters(string[] s)
{
    //this is a string array because for whatever reason, FileReadAllText method translates the eneter key as several spaces
    //thus counting way more characters than neccessary
    int charCount = 0;
    
    for (int i = 0; i < s.Length; i++)
    {
        for (int j = 0; j < s[i].Length; j++)
        {
            charCount++;
        }
    }
    return charCount;
}
int CountCharactersNoSpaces(string[] s)
{
    int charCount = 0;

    for (int i = 0; i < s.Length; i++)
    {
        for (int j = 0; j < s[i].Length; j++)
        {
            if (!char.IsWhiteSpace(s[i][j]))
            {
                charCount++;
            }
        }
    }
    return charCount;

}
int CountWords(string s)
{
    int wordCount = 0;
    int i = 0;

    while (i < s.Length && char.IsWhiteSpace(s[i]))
    {
        i++;
    }
      
    while (i < s.Length)
    {
        while (i < s.Length && !char.IsWhiteSpace(s[i]))
        {
            i++;
        }

        wordCount++;

        while (i < s.Length && char.IsWhiteSpace(s[i]))
        {
            i++;
        }    
    }
    return wordCount;
}