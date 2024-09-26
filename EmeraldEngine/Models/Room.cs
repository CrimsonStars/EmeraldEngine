using EmeraldEngine.Universal;

namespace EmeraldEngine.Models
{
    public class Room : BaseInformation
    {
        // Names will be changed in the future, for sure
        #region Properties and fields
        public List<string> DirectionsToGo;
        public List<string> ItemsInTheRoom;
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
    }
}