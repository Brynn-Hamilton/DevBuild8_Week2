
do
{
    // Request and take user input
    Console.WriteLine("Please enter a word or sentence.");
    string input = Console.ReadLine();
    Console.WriteLine(ReverseString(input));
    Console.WriteLine();
} while (GoAgain());


// Create a separate method for reversing your string
// Return type and parameter should be a string
string ReverseString(string stringToReverse)
{
    string reversedString = "";
    Stack<char> characters = new Stack<char>();

    for (int i = 0; i < stringToReverse.Length; ++i)
    {
        if (stringToReverse[i] != ' ')
        {
            characters.Push(stringToReverse[i]);
        }
        else
        {
            while (characters.Count > 0)
            {
                reversedString += (characters.Pop());
            }
            reversedString += (" ");
        }
    }
    while (characters.Count > 0)
    {
        reversedString += (characters.Pop());
    }
    return reversedString;
}

static bool GoAgain()
{
    while (true)
    {
        Console.WriteLine("Would you like to enter another word or sentence? (y/n)");
        string input = Console.ReadLine().ToLower();

        if (input == "y" || input == "yes")
        {
            return true;
        }
        else if (input == "n" || input == "no")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Please enter y or n");
        }

    }
}



