using System;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Creativity and Exceeding Requirements:
         *
         * I exceeded the core requirements by adding extra prompts
         * and questions to the Reflection and Listing activities.
         * I also included random selection so the activities can
         * provide different prompts and questions each time.
         */

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for using the Mindfulness Program!");
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please choose 1, 2, 3, or 4.");
                System.Threading.Thread.Sleep(2000);
            }

            if (choice == "1" || choice == "2" || choice == "3")
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}