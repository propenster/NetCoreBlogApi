using System;
using MySqlConnector;

namespace BlogPostApi{

    public class AppDb : IDisposable
    {
        //Declare a Mysql connection instance property
        public MySqlConnection Connection { get; }
        //Constructor...
        public AppDb(string connectionString){
                Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}