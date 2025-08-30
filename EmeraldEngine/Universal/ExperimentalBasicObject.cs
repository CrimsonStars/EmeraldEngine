using EmeraldEngine.Universal.Interfaces;

namespace EmeraldEngine.Universal
{
    /// <summary>
    /// This one will change. For now I have only string for description.
    /// In the future a list/collection will be used for better end user experience.
    /// </summary>
    public abstract class ExperimentalBasicObject : IExperimentalBasicInformation
    {
        public string Description { get; set; }

        public ExperimentalBasicObject()
        {
            Description = string.Empty;
        }

        public ExperimentalBasicObject(string description)
        {
            Description = description;
        }

        // test
        public IExperimentalBasicInformation SetDescription(string description)
        {
            Description = description;
            return this;
        }
    }
}