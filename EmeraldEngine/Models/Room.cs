using EmeraldEngine.Universal;
using System.Collections;

namespace EmeraldEngine.Models
{
    public class Room : BaseInformation
    {
        // Names will be changed in the future, for sure

        #region Properties and fields

        public List<(string id, string dest, bool active)> DirectionsToGo { get; set; }
        public List<string> ItemsInTheRoom { get; set; }

        #endregion Properties and fields

        #region Constructors

        public Room() : base()
        {
            DirectionsToGo = new List<(string id, string dest, bool active)>();
            ItemsInTheRoom = new List<string>();
            ObjectId = $"ROOM.{Guid.NewGuid()}";
            Description = string.Empty;
        }

        public Room(string id, string name, string desc) : this()
        {
            ObjectId = id;
            Description = desc;
            Name = name;
        }

        #endregion Constructors

        public void AddItemsInRoom(params string[] items)
        {
            foreach (var item in items)
            {
                if (!ItemsInTheRoom.Any(itemz => itemz == item))
                {
                    ItemsInTheRoom.Add(item);
                }
                else
                {
                    throw new Exception($"Room already has item with id: '{item}'");
                }
            }
        }

        public void GetItem(string itemId)
        {
            throw new NotImplementedException("GetItem method for Room is not implemented, yet.");
        }

        public string ListAvailiableDirections(bool debugMode)
        {
            var result = $"AVAILIABLE DIRS: {DirectionsToGo.Count}\n";

            foreach (var dir in DirectionsToGo)
            {
                result += $"{dir.id} => {dir.dest}";

                if (debugMode && !dir.active)
                {
                    result += $" ({dir.active})\n";
                }

                result += Environment.NewLine;
            }

            return result;
        }

        public string ListAvailiableDirections() => ListAvailiableDirections(false);
    }
}