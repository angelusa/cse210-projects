using System;

class Program
{
    static void Main(string[] args)
    {
        ShowWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squareNum = SquareNum (userNumber);

        ShowResult(userName, squareNum);
    }
    static void ShowWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name:");
        string name = Console.ReadLine();

        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number:");
        int number = int.Parse (Console.ReadLine());

        return number;
    }
    static int SquareNum(int number)
    {
        int square = number * number;
        return square;
    }
    static void ShowResult (string name, int square)
    {
        Console.WriteLine ($"{name}, the square of your number is {square}");
    }
}