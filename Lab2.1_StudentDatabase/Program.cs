// Student Database

// Create 3 arrays and fill them with student information: name, hometown, favorite food

string[] name = { "Baby Murloc", "Master Chief", "God-tier Garen", "Jawa Jawa", "Lich King" };
string[] hometown = { "Northshire", "Eridanus II", "Demacia", "Tatooine", "Menethil" };
string[] favoriteFood = { "Clams", "Hawaiian Pizza", "Justice", "Jawa Juice", "Souls" };

Console.WriteLine("Welcome to the student database!");

bool moreStudents = true;
while (moreStudents)
{
    // Provide an option where the user can see a list of all students
    Console.WriteLine($"\nIf you would like to see a list of all the students, please enter 'y' or 'yes'. \nTo resume exploring the database, hit any other key.");
    string viewList = Console.ReadLine();
    if (viewList == "y" || viewList == "yes")
    {
        for (int index = 0; index < name.Length; index++)
        {
            Console.WriteLine($"{name[index]}");
        }
    }

    // Prompt the user to ask about a particular student by number
    // Allow the user to search by student name
    bool invalidInput = true;
    while (invalidInput)
    {
        Console.WriteLine("\nDo you want to search for a student by their name or number?");
        string searchType = Console.ReadLine().ToLower();
        if (searchType == "name")
        {

            string inputName = Console.ReadLine().ToLower();
            int selectedIndex = -1;

            for (int index = 0; index < hometown.Length; index++)
            {
                if (inputName == name[index].ToLower())
                {
                    selectedIndex = index;
                }
            }
            if (selectedIndex >= 0)
            {
                StudentDatabaseCheck(selectedIndex + 1);
            }
            else
            {
                // Error message for an incorrect student name (name not in list)
                Console.WriteLine($"\nYou have entered {inputName}. Sorry, that student doesn't correspond with our database. Please try again.");
                moreStudents = true;
                invalidInput = false;

            }
        }
        else if (searchType == "number")
        {
            // Prompt the user to ask about a particular student by number
            Console.WriteLine($"\nPlease select a student by number (1-5)");
            string studentEntry = Console.ReadLine();
            if (int.TryParse(studentEntry, out int validStudent))
            {
                StudentDatabaseCheck(validStudent);
            }
            else
            {
                // Error message for an incorrect value (non-integer)
                Console.WriteLine($"\nYou have entered {studentEntry}. Sorry, that value doesn't correspond with our database. Please try again.");
                invalidInput = false;
                moreStudents = true;
            }
        }
        else
        {
            // Error message for an incorrect search type (anything other than name or number)
            Console.WriteLine($"\nYou have entered {searchType}. Please enter a valid method to look for a student.");
            invalidInput = true;
            moreStudents = false;
        }
    }

}

// Method for student details (hometown, favorite food)
void StudentDatabaseCheck(int validEntry)
{
    // Use an if statement to check if the number is out of range
    if ((validEntry >= 1 && validEntry <= 5))
    {
        validEntry--;

        // Ask the user what information category to display: "Hometown" or "Favorite Food"
        // need to add another while loop for incorrect category selection **********

        bool invalidCategoryInput = true;
        while (invalidCategoryInput)
        {
            Console.WriteLine($"Student {validEntry + 1} is {name[validEntry]}. What would you like to know? Enter 'hometown' or 'favorite food'");
            string studentDetail = Console.ReadLine().ToLower();

            if (studentDetail == "hometown" || studentDetail == "home" || studentDetail == "town")
            {
                Console.WriteLine($"\n{name[validEntry]} is from {hometown[validEntry]}!");
            }
            else if (studentDetail == "favorite food" || studentDetail == "food")
            {
                Console.WriteLine($"\n{name[validEntry]}'s favorite food is/are {favoriteFood[validEntry]}!");
            }
            else
            {
                // Error message for an incorrect category
                Console.WriteLine("\nThat category does not exist. Please try again. Enter 'hometown' or 'favorite food'.");
                invalidCategoryInput = true;
            }
        }
        // Ask the user if they would like to learn about another student
        Console.WriteLine($"\nWould you like to learn more about another student? \nPlease enter 'y' or 'yes' to continue, or any other key to exit the student database.");
        string anotherStudent = Console.ReadLine().ToLower();
        if (anotherStudent == "y" || anotherStudent == "yes")
        {
            moreStudents = true;
        }
        else
        {

            // Exit message if user wants to exit the database
            Console.WriteLine("\nThank you for taking the time to learn more about our students!");
            Console.WriteLine("Goodbye!");
            moreStudents = false;
        }
    }
    else
    {
        // Error message if integer is not in array
        Console.WriteLine($"\nYou have entered {validEntry}. Sorry, that student doesn't exist. Please try again.");
        moreStudents = true;
    }
}


