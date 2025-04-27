using Marketplace;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Marketplace;
public class MySqlUserRepository : IUserRepository, IGeneralProps<User>
{
    private readonly string _connectionString;

    public MySqlUserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Add(User user)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var sql = "INSERT INTO users (login, pass, isAdmin) VALUES (@login, @pass, @isAdmin)";
        using var cmd = new MySqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@login", user.Login);
        cmd.Parameters.AddWithValue("@pass", user.Password);
        cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin ? 1 : 0);
        cmd.ExecuteNonQuery();
    }

    public User GetUserByLogin(string login)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var sql = "SELECT id, login, pass, isAdmin FROM users WHERE login = @login";
        using var cmd = new MySqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@login", login);

        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new User(
                reader.GetInt32("id"),
                reader.GetString("login"),
                reader.GetString("pass"),
                reader.GetBoolean("isAdmin")
            );
        }
        return null;
    }

    public int GetNextUserId()
    {
        // Якщо id автогенерується в базі, то можна залишити 0
        return 0;
    }

    // -------------------------
    // Методи для IGeneralProps:
    // -------------------------

    public void Delete(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var sql = "DELETE FROM users WHERE id = @id";
        using var cmd = new MySqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public List<User> GetAll()
    {
        var users = new List<User>();
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var sql = "SELECT id, login, pass, isAdmin FROM users";
        using var cmd = new MySqlCommand(sql, connection);

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var user = new User(
                reader.GetInt32("id"),
                reader.GetString("login"),
                reader.GetString("pass"),
                reader.GetBoolean("isAdmin")
            );
            users.Add(user);
        }
        return users;
    }

    public User GetById(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var sql = "SELECT id, login, pass, isAdmin FROM users WHERE id = @id";
        using var cmd = new MySqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@id", id);

        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new User(
                reader.GetInt32("id"),
                reader.GetString("login"),
                reader.GetString("pass"),
                reader.GetBoolean("isAdmin")
            );
        }
        return null;
    }

    public void Update(User user)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var sql = "UPDATE users SET login = @login, pass = @pass, isAdmin = @isAdmin WHERE id = @id";
        using var cmd = new MySqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@login", user.Login);
        cmd.Parameters.AddWithValue("@pass", user.Password);
        cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin ? 1 : 0);
        cmd.Parameters.AddWithValue("@id", user.Id);
        cmd.ExecuteNonQuery();
    }
}
