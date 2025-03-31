namespace EmeraldEngine.Interfaces
{
    public interface IRoom
    {
        public IRoom AddItem(string itemObjectId);

        public IRoom AddRoom(string roomObjectId, string changeActivator, bool isActive);

        public IRoom AddRoom(string roomObjectId, string changeActivator)
            => AddRoom(roomObjectId, changeActivator, true);

        public IRoom AddDirection(string id, string dest, bool active);

        public IRoom AddDirection(string id, string dest) => AddDirection(id, dest, true);
    }
}