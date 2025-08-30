using EmeraldEngine.Universal;

namespace EmeraldEngine.Models
{
    public class Room : BasicInformation
    {
        // Names will be changed in the future, for sure
        #region Properties and fields
        private List<string> DirectionsToGo;
        private List<string> ItemsInTheRoom;
        #endregion

        #region Constructors
        public Room() : base()
        {
            DirectionsToGo = new List<string>();
            ItemsInTheRoom = new List<string>();
            ObjectId = $"ROOM.{Guid.NewGuid()}";
        }

        public Room(string id, string name, string desc) : this()
        {
            ObjectId = id;
            Description = desc;
            Name = name;
        }
        #endregion

        public void AddItemsInRoom(params  string[] items)
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
            if(ItemsInTheRoom.Any(id => id == itemId))
            {
                // do domething
            }
        }
    }
}