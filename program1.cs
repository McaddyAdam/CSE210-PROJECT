using System;

class Program {
    static void Main() {
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());
        string letter;
        string sign = "";

        if (grade >= 90) {
            letter = "A";
        }
        else if (grade >= 80) {
            letter = "B";
        }
        else if (grade >= 70) {
            letter = "C";
        }
        else if (grade >= 60) {
            letter = "D";
        }
        else {
            letter = "F";
        }

        int lastDigit = grade % 10;
        if (lastDigit >= 7 && letter != "F") {
            sign = "+";
        }
        else if (lastDigit < 3 && letter != "F") {
            sign = "-";
        }

        if (letter == "A" && sign == "+") {
            sign = "";  // A+ is not a valid grade
        }
        else if (letter == "F") {
            sign = "";  // F+ and F- are not valid grades
        }

        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        if (grade >= 70) {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else {
            Console.WriteLine("Sorry, you did not pass the course. Better luck next time!");
        }
    }
}
