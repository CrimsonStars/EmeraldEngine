n\\amespace EmeraldEngine.Universal
{
    public abstract class BaseInformation : ExperimentalBaseObject
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
    }
}
