namespace EmeraldEngine.Universal.Interfaces
{
    public interface IBasicInformation
    {
        public IBasicInformation SetName(string name);
        public IBasicInformation SetObjectId(string objectId);
        public IBasicInformation SetIdAndName(string objectId, string name);
    }
}
