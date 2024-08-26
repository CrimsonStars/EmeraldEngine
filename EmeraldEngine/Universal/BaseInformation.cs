namespace EmeraldEngine.Universal
{
    public abstract class BaseInformation : ExperimentalBaseObject
    {
        public string Name { get; set; }
        public string ObjectId { get; set; }

        public BaseInformation()
        {
            Name = string.Empty;
            ObjectId = string.Empty;
        }
    }
}
