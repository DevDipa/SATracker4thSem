using MySql.Data.MySqlClient;
using System.Data;

public static class Database
{
    public static MySqlConnection GetConnection()
    {
        string connectionString = "server=localhost;uid=root;pwd=;database=SATracker_db;";
        return new MySqlConnection(connectionString);
    }

}
