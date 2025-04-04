using System.Collections.Generic;

namespace Marketplace
{
    public interface IGeneralProps<T> where T : IIdentifiable
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T? GetById(int id);
        List<T> GetAll();
    }
}
