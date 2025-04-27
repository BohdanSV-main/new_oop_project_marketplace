using Marketplace;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

    public class MySqlProductRepository : IProductRepository, IGeneralProps<Product>
    {
        private readonly string _connectionString;
        private IDataStorage<Product> _storage;

    public MySqlProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Product product)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var sql = @"INSERT INTO products (name, price, description, imagePath, quantity) 
                    VALUES (@name, @price, @description, @imagePath, @quantity)";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@description", product.Description);
            cmd.Parameters.AddWithValue("@imagePath", product.ImagePath ?? "");
            cmd.Parameters.AddWithValue("@quantity", product.Quantity);
            cmd.ExecuteNonQuery();
    }

        public void Delete(int id)
        {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var sql = "DELETE FROM products WHERE id = @id";
        using var cmd = new MySqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

        public List<Product> GetAll()
        {
        var products = new List<Product>();
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var sql = "SELECT id, name, price, description, imagePath, quantity FROM products";
        using var cmd = new MySqlCommand(sql, connection);

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var product = new Product(
                reader.GetInt32("id"),
                reader.GetString("name"),
                reader.GetDecimal("price").ToString(),
                reader.GetString("description"),
                reader.GetString("imagePath"),
                reader.GetInt32("quantity")
            );
            products.Add(product);
        }
        return products;
    }

        public Product GetById(int id)
        {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var sql = "SELECT id, name, price, description, imagePath, quantity FROM products WHERE id = @id";
        using var cmd = new MySqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@id", id);

        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new Product(
                reader.GetInt32("id"),
                reader.GetString("name"),
                reader.GetDecimal("price").ToString(),
                reader.GetString("description"),
                reader.GetString("imagePath"),
                reader.GetInt32("quantity")
            );
        }
        return null;
    }

        public void Update(Product product)
        {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var sql = @"UPDATE products 
                    SET name = @name, price = @price, description = @description, imagePath = @imagePath, quantity = @quantity 
                    WHERE id = @id";
        using var cmd = new MySqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@name", product.Name);
        cmd.Parameters.AddWithValue("@price", product.Price);
        cmd.Parameters.AddWithValue("@description", product.Description);
        cmd.Parameters.AddWithValue("@imagePath", product.ImagePath ?? "");
        cmd.Parameters.AddWithValue("@quantity", product.Quantity);
        cmd.Parameters.AddWithValue("@id", product.Id);
        cmd.ExecuteNonQuery();
    }
    public List<Product> GetAllProducts()
    {
        return GetAll();
    }
    public IDataStorage<Product> GetStorage()
    {
        return _storage;
    }
}

