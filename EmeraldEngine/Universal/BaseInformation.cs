namespace EmeraldEngine.Universal
{
    public abstract class BaseInformation : ExperimentalBaseObject, IBasicInformation
    {
        public string Name { get; set; }
        public string ObjectId { get; set; }

        public BaseInformation() : base(string.Empty)
        {
            Name = string.Empty;
            ObjectId = string.Empty;
        }

        public BaseInformation(string name, string objectId, string desc) : base(desc)
        {
            Name = name;
            ObjectId = objectId;
        }

        public void SetName(string name)
        {
            throw new NotImplementedException();
        }

        public void SetDescription(string desc)
        {
            throw new NotImplementedException();
        }

        public void SetObjectId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
