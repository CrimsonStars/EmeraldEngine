using EmeraldEngine.Universal;

namespace EmeraldEngine.Models
{
    public class Room : BaseInformation
    {
        /// <summary>
        /// First string = direction_id
        /// Second string = destination_room_id
        /// </summary>

        // Names will be changed in the future, for sure
        public List<string> DirectionsToGo;

        public List<string> ItemsInTheRoom;

        #region Constructors
        public Room()
        {
            Description = string.Empty;
            DirectionsToGo = new List<string>();
            ItemsInTheRoom = new List<string>();
            ObjectId = $"ROOM.{Guid.NewGuid()}";
            Description = string.Empty;
        }
        #endregion
    }
}