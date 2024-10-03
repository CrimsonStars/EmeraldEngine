namespace RoomEditor.Prototype.MVVM.Models
{
    using EmeraldEngine.Models;
    using System.Collections.Generic;

    internal class RoomModel
    {
        private List<Room> _roomsCollection;

        public RoomModel()
        {
            _roomsCollection = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            _roomsCollection.Add(room);
            
        }
    }
}
