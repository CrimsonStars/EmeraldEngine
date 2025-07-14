namespace EmeraldEngine.Universal
{
    public interface IBasicInformation
    {
        public IBasicInformation SetName(string name);

        public IBasicInformation SetObjectId(string id);

        public IBasicInformation SetBasicInformation(string id, string name);

        /// <summary>
        /// Warning! Method should not override current value if present.
        /// </summary>
        /// <returns></returns>
        public IBasicInformation SetDescription(string desc);
    }
}