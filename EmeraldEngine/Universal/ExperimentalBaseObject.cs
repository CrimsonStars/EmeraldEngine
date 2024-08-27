namespace EmeraldEngine.Universal
{
    /// <summary>
    /// This one will change. For now I have only string for description.
    /// In the future a list/collection will be used for better end user experience.
    /// </summary>
    public abstract class ExperimentalBaseObject
    {
        public string Description { get; set; }

        public ExperimentalBaseObject()
        {
            Description = string.Empty;
        }

        public ExperimentalBaseObject(string description)
        {
            Description = description;
        }
    }
}