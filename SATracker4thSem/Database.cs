
using MySql.Data.MySqlClient;
using System.Data;

public static class Database
{
    private static string connectionString = "server=localhost;uid=root;pwd=;database=SATracker_db;";

    public static IDbConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}
