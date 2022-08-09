List<string> shoppingCart = new List<string>();


// Display at least 8 item names and prices
var shoppingList = new Dictionary<string, decimal>()
{
    {"milk", 7.29m },
    {"eggs", 6.97m },
    {"gouda", 9.63m },
    {"lettuce",3.29m },
    {"french bread",2.87m },
    {"strawberries",3.69m },
    {"turkey", 11.79m },
    {"kale", 3.97m }
};
Console.WriteLine();
Console.WriteLine("Welcome to CrunchyMart!");
Console.WriteLine("==============");

// Call method is display shopping list for user
displayShoppingList();

// Call method to ask user what item they would like to order
addItemToList();

//break
Console.WriteLine();

// Call method to ask user if they would like to order another item
addAnotherItem();




/*******************************************************************************************************
                                    // Shopping List Methods //
*******************************************************************************************************/



/******************************************
               // Method //
// Method for adding an item to the list //
********************************************/
void addItemToList()
{
    bool invalidItem = true;
    while(invalidItem)
    {
        Console.WriteLine();

        // Ask user to enter an item name
        Console.WriteLine("What item would you like to order?");
        string userItem = Console.ReadLine().ToLower();

        // If the item exists, display that item and price
        if (shoppingList.ContainsKey(userItem))
        {
            Console.WriteLine($"Adding {userItem} to cart for {shoppingList[userItem]}.");

            // Method for adding item to cart/shoppingCart list
            // If item exists, add that item and its price to the user's order
            addToShoppingCart(userItem);

            invalidItem = false;
        }
        else
        {
            // If the item doesn't exist, display an error and re-prompt the user
            // Display the menu again (optional)
            Console.WriteLine($"Sorry, we don't have that item. Please try again\n");
            invalidItem = true;
            displayShoppingList();
            Console.WriteLine();
        }
    }
     
}

/****************************************************************************
                               // Method //
// loop asking user if they would like to add anything else to their order //
****************************************************************************/
void addAnotherItem()
{
    bool moreGroceries = true;
    while(moreGroceries)
    {
        Console.WriteLine();

        // After adding an item to their order, ask if they want to add another
        // If so, repeat (user can entier an item more than once)
        // Don't keep track of quantity*
        Console.WriteLine("Would you like to order anything else? (y/n)");
        string anotherItem = Console.ReadLine().ToLower();
        if (anotherItem == "yes" || anotherItem == "y")
        {
            displayShoppingList();
            addItemToList();
        }
        else if (anotherItem == "no" || anotherItem == "n")
        {
            // Once done adding items, display a list of all items ordered with prices
            moreGroceries = false;
            // receipt method
            printShoppingReceipt();
        }
        else
        {
            Console.WriteLine("You have entered and invalid response. Please enter (y/n).");
            moreGroceries = true;
        }
    }
}
/******************************************
           // Method //
// Display shopping list as a menu //
********************************************/

 void displayShoppingList()
{
    int itemNumber = 1;
    foreach (var food in shoppingList)
    {
        Console.WriteLine($"{itemNumber++}. {food.Key}: ${food.Value}");
    }
}

/*************************************************************
                      // Method //
// Method to create shopping cart based on user input items //
*************************************************************/
void addToShoppingCart(string userInput)
{
    shoppingCart.Add(userInput);

}

/*************************************************
                    // Method //
// Method to display receipt for shopping order //
*************************************************/
void printShoppingReceipt()
{
   Console.WriteLine();
   Console.WriteLine("Thank you for your order!");
   Console.WriteLine("Here is your receipt.");
   Console.WriteLine();

    List<string> priceSort = shoppingCart.OrderBy(value => shoppingList[value]).ToList();
    decimal totalPrice = shoppingCart.Sum(value => shoppingList[value]);

   foreach (string item in priceSort)
    {
        Console.WriteLine($"{item}: ${shoppingList[item]}");
    }
    Console.WriteLine();
    Console.WriteLine($"The most expensive item you purchased was: {shoppingCart.Max()}");
    Console.WriteLine($"The most least expensive item you purchased was: {shoppingCart.Min()}");

    Console.WriteLine();

    // Display the sum of the items ordered
    Console.WriteLine($"Your order total is: ${totalPrice}.");
}









