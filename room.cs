using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public class Room
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        private Dictionary<string, Room> exits = new Dictionary<string, Room>();
        private List<Item> items = new List<Item>();

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void AddExit(string direction, Room room)
        {
            exits[direction] = room;
        }

        public Room GetExit(string direction)
        {
            exits.TryGetValue(direction, out Room room);
            return room;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public Item RemoveItem(string itemName)
        {
            Item item = items.Find(i => i.Name.ToLower() == itemName);
            if (item != null)
            {
                items.Remove(item);
            }
            return item;
        }

        public string GetDescription()
        {
            string desc = $"\n{Description}\n";

            if (items.Count > 0)
            {
                desc += "You see:\n";
                foreach (Item item in items)
                {
                    desc += $"- {item.Name}\n";
                }
            }

            if (exits.Count > 0)
            {
                desc += "Exits: " + string.Join(", ", exits.Keys) + "\n";
            }

            return desc;
        }
    }
}
