/*
 * CSE 210 - Week 03 Scripture Memorizer
 *
 * Creativity and Exceeding Requirements:
 * I exceeded the core requirements by creating a small scripture library
 * with three different scriptures. The user can choose which scripture
 * they want to practice. I also implemented the stretch challenge by
 * selecting only words that have not already been hidden.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Console.WriteLine("=================================");
        Console.WriteLine("       SCRIPTURE MEMORIZER");
        Console.WriteLine("=================================");
        Console.WriteLine();
        Console.WriteLine("Choose a scripture:");
        Console.WriteLine("1. Proverbs 3:5-6");
        Console.WriteLine("2. John 3:16");
        Console.WriteLine("3. Philippians 4:13");
        Console.WriteLine();

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Scripture scripture;

        if (choice == "2")
        {
            Reference reference = new Reference("John", 3, 16);

            scripture = new Scripture(
                reference,
                "For God so loved the world that he gave his only begotten Son that whoever believes in him should not perish but have everlasting life."
            );
        }
        else if (choice == "3")
        {
            Reference reference = new Reference("Philippians", 4, 13);

            scripture = new Scripture(
                reference,
                "I can do all things through Christ which strengtheneth me."
            );
        }
        else
        {
            Reference reference = new Reference("Proverbs", 3, 5, 6);

            scripture = new Scripture(
                reference,
                "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths."
            );
        }

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press ENTER to hide three words.");
            Console.WriteLine("Type 'quit' to exit.");
            Console.WriteLine();

            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                Console.Clear();
                Console.WriteLine("Thank you for practicing the scripture!");
                return;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();

        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("=================================");
        Console.WriteLine("Great job!");
        Console.WriteLine("You hid the entire scripture.");
        Console.WriteLine("=================================");
    }
}