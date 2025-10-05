using System;

namespace AdventureGame
{
    public class Game
    {
        private Player player;
        private bool isRunning = true;
        private Func<Player, bool> winCondition;

        // Constructor allows passing a win condition (optional)
        public Game(Player player, Func<Player, bool> winCondition = null)
        {
            this.player = player;
            this.winCondition = winCondition;
        }

        // Main game loop
        public void Run()
        {
            Console.WriteLine("Game started! Type 'help' for commands.\n");
            player.Look();

            while (isRunning)
            {
                Console.Write("\n> ");
                string input = Console.ReadLine();
                ProcessCommand(input);

                // Check win condition if one was set
                if (winCondition != null && winCondition(player))
                {
                    Console.WriteLine("\n🎉 Congratulations! You completed the quest!");
                    isRunning = false;
                }
            }
        }

        private void ProcessCommand(string command)
        {
            string[] parts = command.Split(' ', 2);
            string action = parts[0].ToLower();
            string target = parts.Length > 1 ? parts[1].ToLower() : "";

            switch (action)
            {
                case "look":
                    player.Look();
                    break;
                case "go":
                    player.Move(target);
                    break;
                case "take":
                    player.Take(target);
                    break;
                case "drop":
                    player.Drop(target);
                    break;
                case "inventory":
                    player.ShowInventory();
                    break;
                case "help":
                    ShowHelp();
                    break;
                case "quit":
                    Console.WriteLine("Thanks for playing!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
                    break;
            }
        }

        private void ShowHelp()
        {
            Console.WriteLine("\nAvailable commands:");
            Console.WriteLine("look - Examine the current room");
            Console.WriteLine("go [direction] - Move in a direction (north, south, east, west)");
            Console.WriteLine("take [item] - Pick up an item");
            Console.WriteLine("drop [item] - Drop an item");
            Console.WriteLine("inventory - Show items you are carrying");
            Console.WriteLine("quit - Exit the game");
        }
    }
}
