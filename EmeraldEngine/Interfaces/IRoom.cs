namespace EmeraldEngine.Interfaces
{
    public interface IRoom
    {
        public IRoom AddItem(string itemName);

        public IRoom AddRoom(string roomName);

        public IRoom AddRoom(string roomName, bool isActive);

        public IRoom SetObjectId(string objectId);

        public IRoom SetDescription(string desc);

        public IRoom AddDirection(string id, string dest, bool active);

        public IRoom AddDirection(string id, string dest);
    }
}