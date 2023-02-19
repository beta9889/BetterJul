using JulAPI.HelperClasses;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace APITest
{
    public class MockDatabase 
    {
        private readonly string connectionString = "Host=localhost;Port=3306;Database=jul;Pooling=false;SslMode=none;convert zero datetime=True;";
        protected IHelperConnection _helperConnection {get; set;}
        protected DbConnection _connection;

        public void SetupVariables()
        {
            _helperConnection= new HelperConnection(null,true);
            _helperConnection.SetConfiguration(connectionString);
        }

        public void SetupDatabase() 
        {
            _connection = _helperConnection.testMockDatabase();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Create Database Jul;";
                command.ExecuteNonQuery();
            }
            CreateTableMovies();
        }

        public void RemoveDatabase()
        {
            _connection.Close();
        }
        private void CreateTableMovies()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE movie(id int auto_increment, name varchar(255) NOT NULL,genre_name varchar(255),imdb_rating float,jayornay varchar(255),picked_by varchar(255),participants varchar(255),is_major char(1),PRIMARY KEY (id), ) Engine = InnoDB;";
                command.CommandType = System.Data.CommandType.Text;
                command.ExecuteNonQuery();
            }
            InsertIntoMovies();
        }

        private void InsertIntoMovies()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO movie(name, genre_name, imdb_rating, jayornay, picked_by, participants, is_major) Values " +
                    "(\"Beauty and the beast (live-action)\", \"Romance\", 7.1, \"Jay\", \"Gabbe\", \"Micke, Gabbe, Crippe\", 1), " +
                    "(\"Catch me if you can\", \"Biography\", 8.1, \"Jay\", \"Gabbe\", \"Micke, Gabbe, Crippe, Behrad\", 1), " +
                    "(\"1917\", \"War\", 8.2, \"Jay\", \"Micke\", \"Micke, Gabbe\", 0); ";
                command.CommandType = System.Data.CommandType.Text;
                command.ExecuteNonQuery();
            }
        }
    }
}
