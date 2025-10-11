using System;

namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure Game!");
            Console.WriteLine("Type '1' for Test Adventure or '2' for Story Quest:");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                TestAdventure.Start();
            }
            else if (choice == "2")
            {
                StoryQuest.Start();
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting game.");
            }
        }
    }
}
