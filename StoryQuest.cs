using System;

namespace AdventureGame
{
    public class StoryQuest
    {
        public static void Start()
        {
            // --- Rooms --- (the places)
            Room village = new Room("Village", "You are in a small village. A path leads into a dark forest.");
            Room forest = new Room("Forest", "Tall trees block the sunlight. You hear distant growling.");
            Room cave = new Room("Cave", "A dark, damp cave. Something dangerous lurks inside!");

            // --- Connect Rooms --- (rooms that they could go into)
            village.AddExit("north", forest);
            forest.AddExit("south", village);
            forest.AddExit("east", cave);
            cave.AddExit("west", forest);

            // --- Item ---
            Item sword = new Item("sword", "A sharp blade, perfect for defending yourself.");
            forest.AddItem(sword);

            // --- Player --- (the main player)
            Player player = new Player("Hero", village);

            // --- Win Condition --- (the person must have the sword and go into the cave)
            Func<Player, bool> winCondition = (p) =>
            {
                return p.CurrentRoom == cave && p.HasItem("sword");
            };

            // --- Game --- (this is a small game about a man entering a cave)
            Game game = new Game(player, winCondition);

            Console.WriteLine("Story Quest started. Find the sword and enter the cave to win!");
            game.Run();
        }
    }
}
