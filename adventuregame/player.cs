using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public class Player
    {
        public string Name { get; private set; }
        public Room CurrentRoom { get; private set; }
        private List<Item> inventory = new List<Item>();

        public Player(string name, Room startingRoom)
        {
            Name = name;
            CurrentRoom = startingRoom;
        }

        public void Look()
        {
            Console.WriteLine(CurrentRoom.GetDescription());
        }

        public void Move(string direction)
        {
            Room nextRoom = CurrentRoom.GetExit(direction);
            if (nextRoom != null)
            {
                CurrentRoom = nextRoom;
                Look();
            }
            else
            {
                Console.WriteLine("You can’t go that way.");
            }
        }

        public void Take(string itemName)
        {
            Item item = CurrentRoom.RemoveItem(itemName);
            if (item != null)
            {
                inventory.Add(item);
                Console.WriteLine($"You picked up the {item.Name}.");
            }
            else
            {
                Console.WriteLine($"There is no {itemName} here.");
            }
        }

        public void Drop(string itemName)
        {
            Item item = inventory.Find(i => i.Name.ToLower() == itemName);
            if (item != null)
            {
                inventory.Remove(item);
                CurrentRoom.AddItem(item);
                Console.WriteLine($"You dropped the {item.Name}.");
            }
            else
            {
                Console.WriteLine($"You don't have a {itemName}.");
            }
        }

        public void ShowInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("You are carrying nothing.");
            }
            else
            {
                Console.WriteLine("You are carrying:");
                foreach (Item item in inventory)
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }
        }

        public bool HasItem(string itemName)
        {
            return inventory.Exists(i => i.Name.ToLower() == itemName);
        }
    }
}
