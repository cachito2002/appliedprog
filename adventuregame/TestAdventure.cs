using System;

namespace AdventureGame
{
    public class TestAdventure
    {
        public static void Start()
        {
            // --- Rooms ---
            Room room1 = new Room("Room 1", "A plain test room with bare walls.");
            Room room2 = new Room("Room 2", "Another test room, just as boring.");

            // --- Connect Rooms ---
            room1.AddExit("east", room2);
            room2.AddExit("west", room1);

            // --- Item ---
            Item key = new Item("key", "A small shiny test key.");
            room1.AddItem(key);

            // --- Player ---
            Player player = new Player("Tester", room1);

            // --- Game ---
            Game game = new Game(player);

            Console.WriteLine("Test Adventure started. Try moving between rooms and picking up the key.");
            game.Run();
        }
    }
}
