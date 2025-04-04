using System.Collections.Generic;

namespace Marketplace
{
    public abstract class GeneralProps<T> : IGeneralProps<T> where T : class, IIdentifiable
    {
        protected readonly IDataStorage<T> _storage;

        protected GeneralProps(IDataStorage<T> storage)
        {
            _storage = storage;
        }

        public void Add(T entity)
        {
            _storage.Add(entity);
            _storage.Save();
        }

        public void Update(T entity)
        {
            _storage.Update(entity);
            _storage.Save();
        }

        public void Delete(int id)
        {
            _storage.Delete(id);
            _storage.Save();
        }

        public T? GetById(int id)
        {
            return _storage.GetById(id);
        }

        public List<T> GetAll()
        {
            return _storage.GetAll();
        }
    }
}
