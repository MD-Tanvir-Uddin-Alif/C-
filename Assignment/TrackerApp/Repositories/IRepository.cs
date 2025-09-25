using System;
using System.Collections.Generic;

namespace TrackerApp.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Add(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
