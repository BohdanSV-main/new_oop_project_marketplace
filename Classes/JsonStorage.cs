using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Marketplace
{
    public class JsonStorage<T> : IDataStorage<T> where T : class, IIdentifiable
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // btw fix deserialization
        };

        private List<T> _entities;

        public JsonStorage(string filePath)
        {
            _filePath = filePath;
            _entities = Load();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            var index = _entities.FindIndex(e => e.Id == entity.Id);
            if (index >= 0)
            {
                _entities[index] = entity;
                Save();
            }
        }

        public void Delete(int id)
        {
            _entities.RemoveAll(e => e.Id == id);
            Save();
        }

        public T? GetById(int id) => _entities.Find(e => e.Id == id);

        public List<T> GetAll() => new List<T>(_entities);

        public void Save()
        {
            var json = JsonSerializer.Serialize(_entities, _jsonOptions);
            File.WriteAllText(_filePath, json);
        }

        private List<T> Load()
        {
            if (!File.Exists(_filePath))
                return new List<T>();

            var json = File.ReadAllText(_filePath);
            return string.IsNullOrWhiteSpace(json)
                ? new List<T>()
                : JsonSerializer.Deserialize<List<T>>(json, _jsonOptions) ?? new List<T>();
        }
    }
}
