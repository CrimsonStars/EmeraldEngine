using EmeraldEngine.Interfaces;
using EmeraldEngine.Universal;

namespace EmeraldEngine.Models
{
    public class Room : BaseInformation, IRoom
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
        }

        public Room(string id, string name, string desc) : this()
        {
            ObjectId = id;
            Description = desc;
            Name = name;
        }

        public Room(string id, string name) : this(id, name, string.Empty)
        {
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

        #region Interface implementation

        public IRoom AddItem(string itemObjectId)
        {
            if (!string.IsNullOrEmpty(itemObjectId))
            {
                ItemsInTheRoom.Add(itemObjectId);
            }
            else
            {
                throw new Exception($"Item id '{itemObjectId}' already exists in items collection");
            }

            return this;
        }

        public IRoom AddRoom(string roomObjectId, string changeActivator, bool isActive)
        {
            if (!string.IsNullOrEmpty(roomObjectId) && !string.IsNullOrEmpty(changeActivator)
                && !DirectionsToGo.Any(dir => dir.id.Equals(roomObjectId)))
            {
                DirectionsToGo.Add((roomObjectId, changeActivator, isActive));
            }
            else
            {
                throw new Exception($"Direction id '{roomObjectId}' already exists in items collection or is empty");
            }

            return this;
        }

        public IRoom AddDirection(string id, string dest, bool active)
        {
            //if (!string.IsNullOrEmpty(itemObjectId) && !ItemsInTheRoom.Contains(itemObjectId))
            //{
            //    ItemsInTheRoom.Add(itemObjectId);
            //}
            //else
            //{
            //    throw new Exception($"Item id '{itemObjectId}' already exists in items collection");
            //}
            return this;
        }

        #endregion Interface implementation
    }
}