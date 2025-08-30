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

        public IBasicInformation SetName(string name)
        {
            Name = name; 
            return this;
        }

        public IBasicInformation SetObjectId(string objectId)
        {
            ObjectId = objectId;
            return this;
        }

        public IBasicInformation SetIdAndName(string objectId, string name)
        {
            SetName(name);
            SetObjectId(objectId);
            return this;
        }
    }
}