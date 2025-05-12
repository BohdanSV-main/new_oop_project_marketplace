using System.Collections.Generic;
using System.Linq;

public class LocalStorage<T> : IDataStorage<T> where T : class, IIdentifiable
{
    private List<T> _items = new List<T>();

    public List<T> GetAll() => _items;

    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Update(T item)
    {
        var index = _items.FindIndex(i => i.Id == item.Id);
        if (index != -1)
        {
            _items[index] = item;
        }
    }

    public void Delete(int id)
    {
        _items.RemoveAll(i => i.Id == id);
    }

    public T GetById(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }

    public void Save()
    {
        //nothing
    }

    public void SaveAll(List<T> items)
    {
        _items = items;
    }
}
