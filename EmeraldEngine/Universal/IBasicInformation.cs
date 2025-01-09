namespace EmeraldEngine.Universal
{
    public interface IBasicInformation
    {
        public IBasicInformation SetName(string name);

        public IBasicInformation SetDescription(string desc);

        public IBasicInformation SetObjectId(string id);
    }
}