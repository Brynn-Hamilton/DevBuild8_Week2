while (true)
{
    Console.WriteLine("Please enter an integer.");
    string entry = Console.ReadLine();

    int num;

    bool result = int.TryParse(entry, out num);
    Console.WriteLine(result);
    Console.WriteLine(num);
}