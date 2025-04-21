using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using static System.Windows.Forms.Design.AxImporter;

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

        public void ValidateEntity(T entity)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(entity);

            if (!Validator.TryValidateObject(entity, context, validationResults, true))
            {
                var errors = string.Join("\n", validationResults.Select(v => v.ErrorMessage));
                throw new ValidationException($"Помилка валідації:\n{errors}");
            }
        }

        public JsonStorage(string filePath)
        {
            _filePath = filePath;
            _entities = Load();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
            ValidateEntity(entity);
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
            var options = new JsonSerializerOptions
            {
                IncludeFields = true
            };
            return string.IsNullOrWhiteSpace(json)
                ? new List<T>()
                : JsonSerializer.Deserialize<List<T>>(json, _jsonOptions) ?? new List<T>();
        }
        public void SaveAll(List<T> items)
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(items, _jsonOptions));
        }
    }
}
