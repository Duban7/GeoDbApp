using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Geo.DAL.repositories.interfaces
{
    public interface IRepository<T> where T : class
    {
        public ICollection<T> GetAll();
        public T? GetOneById(int id);
        public void Create(T newModel);
        public void Update(T updatedModel);
        public void Remove(T deleteModel);
    }
}
