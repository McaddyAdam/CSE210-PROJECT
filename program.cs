using System;

class Program {
    static void Main() {
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        Console.WriteLine("Your name is {1}, {0} {1}.", firstName, lastName);
    }
}
