using System.Collections;

namespace EmeraldEngine.Models
{
    internal class GameElementsCollection<T> : ICollection
    {
        private List<(string elementId, T element)> _entities;

        public GameElementsCollection()
        {
            _entities = new List<(string , T )>();
        }

        public T? this[string id]
        {
            get
            {
                foreach (var item in _entities)
                {
                    if (item.elementId.Equals(id))
                    {
                        return item.element;
                    }
                }

                return default;
            }
        }

        int ICollection.Count => _entities.Count;

        bool ICollection.IsSynchronized => throw new NotImplementedException("I don't care for this.");

        object ICollection.SyncRoot => throw new NotImplementedException("I don't care for this.");

        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotImplementedException("I don't care for this.");
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            if (_entities is not null)
            {
                return _entities.GetEnumerator();
            }

            return null;
        }
    }
}
