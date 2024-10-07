using EmeraldEngine.Universal;

namespace EmeraldEngine.Models
{
   public class Room : BaseInformation
   {
      /// <summary>
      /// First string = direction_id
      /// Second string = destination_room_id
      /// </summary>
      public Dictionary<string, string> Directions;
      public List<string> ItemsInRoom;

      public Room()
      {
         Name = string.Empty;
         ObjectId = string.Empty;
         ItemsInRoom = new List<string>();
         Directions = new Dictionary<string, string>();
      }
   }
}
