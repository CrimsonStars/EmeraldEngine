using EmeraldEngine.Universal.Interfaces;

namespace EmeraldEngine.Universal
{
    public abstract class BasicInformation : ExperimentalBasicObject, IBasicInformation
    {
        public string Name { get; set; }
        public string ObjectId { get; set; }

        public BasicInformation() : base(string.Empty)
        {
            Name = string.Empty;
            ObjectId = string.Empty;
        }

        public BasicInformation(string name, string objectId, string desc) : base(desc)
        {
            Name = name;
            ObjectId = objectId;
        }

        IBasicInformation IBasicInformation.SetName()
        {
            throw new NotImplementedException();
        }

        IBasicInformation IBasicInformation.SetObjectId()
        {
            throw new NotImplementedException();
        }

        IBasicInformation IBasicInformation.SetIdAndName()
        {
            throw new NotImplementedException();
        }
    }
}
