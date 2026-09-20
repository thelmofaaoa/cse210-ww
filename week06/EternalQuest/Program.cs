using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    /*
     * Creativity and Exceeding Requirements:
     *
     * I exceeded the core requirements by adding a level system
     * based on the user's total score. The user receives a level-up
     * message when reaching higher score levels. I also added extra
     * information for eternal goals and a completion message when
     * checklist goals reach their target. These features make the
     * program feel more like an Eternal Quest game.
     */

    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("           ETERNAL QUEST");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine($"Score: {score}");
            Console.WriteLine($"Level: {GetLevel(score)}");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(goals);
                    break;

                case "2":
                    ListGoals(goals);
                    break;

                case "3":
                    SaveGoals(goals, score);
                    break;

                case "4":
                    score = LoadGoals(goals);
                    break;

                case "5":
                    score = RecordEvent(goals, score);
                    break;

                case "6":
                    running = false;
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using Eternal Quest!");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.Clear();

        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine();

        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            SimpleGoal goal = new SimpleGoal(
                name,
                description,
                points
            );

            goals.Add(goal);
        }
        else if (type == "2")
        {
            EternalGoal goal = new EternalGoal(
                name,
                description,
                points
            );

            goals.Add(goal);
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing it? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(
                name,
                description,
                points,
                target,
                bonus
            );

            goals.Add(goal);
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            Pause();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Goal created successfully!");
        Pause();
    }

    static void ListGoals(List<Goal> goals)
    {
        Console.Clear();

        Console.WriteLine("Your Goals:");
        Console.WriteLine();

        if (goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
        }
        else
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
            }
        }

        Console.WriteLine();
        Pause();
    }

    static int RecordEvent(List<Goal> goals, int score)
    {
        Console.Clear();

        if (goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals to record.");
            Pause();
            return score;
        }

        Console.WriteLine("Your Goals:");
        Console.WriteLine();

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }

        Console.WriteLine();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        if (choice < 1 || choice > goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            Pause();
            return score;
        }

        Goal selectedGoal = goals[choice - 1];

        if (selectedGoal is SimpleGoal && selectedGoal.IsComplete())
        {
            Console.WriteLine();
            Console.WriteLine("This goal has already been completed.");
            Pause();
            return score;
        }

        if (selectedGoal is ChecklistGoal && selectedGoal.IsComplete())
        {
            Console.WriteLine();
            Console.WriteLine("This checklist goal is already complete.");
            Pause();
            return score;
        }

        int earnedPoints = selectedGoal.RecordEvent();

        score += earnedPoints;

        Console.WriteLine();
        Console.WriteLine($"Congratulations! You earned {earnedPoints} points.");
        Console.WriteLine($"Your new score is {score}.");
        Console.WriteLine($"Your current level is {GetLevel(score)}.");

        if (selectedGoal is ChecklistGoal &&
            selectedGoal.IsComplete())
        {
            Console.WriteLine();
            Console.WriteLine("***** CHECKLIST GOAL COMPLETED! *****");
            Console.WriteLine("You earned your completion bonus!");
        }

        Console.WriteLine();
        Pause();

        return score;
    }

    static void SaveGoals(List<Goal> goals, int score)
    {
        Console.Clear();

        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(score);

            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine();
        Console.WriteLine("Goals saved successfully!");
        Pause();
    }

    static int LoadGoals(List<Goal> goals)
    {
        Console.Clear();

        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine();
            Console.WriteLine("File not found.");
            Pause();
            return 0;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            Pause();
            return 0;
        }

        int score = int.Parse(lines[0]);

        goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (goalType == "SimpleGoal")
            {
                bool isComplete = bool.Parse(parts[4]);

                SimpleGoal goal = new SimpleGoal(
                    name,
                    description,
                    points,
                    isComplete
                );

                goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                int timesCompleted = int.Parse(parts[4]);

                EternalGoal goal = new EternalGoal(
                    name,
                    description,
                    points,
                    timesCompleted
                );

                goals.Add(goal);
            }
            else if (goalType == "ChecklistGoal")
            {
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                ChecklistGoal goal = new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus,
                    amountCompleted
                );

                goals.Add(goal);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Goals loaded successfully!");
        Console.WriteLine($"Current score: {score}");
        Pause();

        return score;
    }

    static string GetLevel(int score)
    {
        if (score >= 5000)
        {
            return "Level 5 - Eternal Champion";
        }
        else if (score >= 3000)
        {
            return "Level 4 - Faithful Warrior";
        }
        else if (score >= 1500)
        {
            return "Level 3 - Quest Master";
        }
        else if (score >= 500)
        {
            return "Level 2 - Goal Seeker";
        }
        else
        {
            return "Level 1 - Quest Beginner";
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}