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

        /// <summary>
        /// Private for now, more actions can be performed
        /// with given interface's methods (IBasicInformation).
        /// </summary>
        /// <param name="name">Name of object</param>
        /// <param name="objectId">Object's identificator</param>
        /// <param name="desc">Description</param>
        private BaseInformation(string name, string objectId, string desc) : base(desc)
        {
            Name = name;
            ObjectId = objectId;
        }

        #region IBasicInformation interface implementation

        public IBasicInformation SetName(string name)
        {
            Name = name;
            return this;
        }

        public IBasicInformation SetObjectId(string id)
        {
            ObjectId = id;
            return this;
        }

        public IBasicInformation SetBasicInformation(string id, string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id))
            {
                throw new Exception("Error in given parameters - empty or null value.");
            }

            SetName(name);
            SetObjectId(id);

            return this;
        }

        public IBasicInformation SetDescription(string desc)
        {
            if (string.IsNullOrEmpty(this.Description))
            {
                Description = desc;
            }

            return this;
        }

        #endregion IBasicInformation interface implementation
    }
}