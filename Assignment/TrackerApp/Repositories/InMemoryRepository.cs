using System;
using System.Collections.Generic;
using System.Linq;
using TrackerApp.Models;

namespace TrackerApp.Repositories
{
    // Generic in-memory repository for quick demo & testing
    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        protected readonly List<T> _items = new List<T>();

        public virtual void Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        public virtual void Delete(Guid id)
        {
            var prop = typeof(T).GetProperty("Id");
            var found = _items.FirstOrDefault(x => prop.GetValue(x).Equals(id));
            if (found != null) _items.Remove(found);
        }

        public virtual T Get(Guid id)
        {
            var prop = typeof(T).GetProperty("Id");
            return _items.FirstOrDefault(x => prop.GetValue(x).Equals(id));
        }

        public virtual IEnumerable<T> GetAll() => _items.ToList();

        public virtual void Update(T item)
        {
            var prop = typeof(T).GetProperty("Id");
            var id = prop.GetValue(item);
            var existing = _items.FirstOrDefault(x => prop.GetValue(x).Equals(id));
            if (existing != null)
            {
                _items.Remove(existing);
                _items.Add(item);
            }
            else
            {
                throw new KeyNotFoundException("Item not found for update");
            }
        }
    }
}
