using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace JulAPI.HelperClasses
{
    public interface IHelperConnection
    {

        public void SetConfiguration(string connectionString);
        public MySqlConnection getConnection(string username = "root", string password = "");
        public List<T> ConvertRowToList<T>(DataSet dataSet, string columnName, int index);
        public SqliteConnection testMockDatabase();

    }

    public class HelperConnection : IHelperConnection
    {
        private IConfiguration? _configuration { get; set; }
        private string? _connecitonString { get; set; }
        private readonly bool _test;
        public HelperConnection(IConfiguration? config, bool test = false)
        {
            _test= test;
            _configuration = config;
        }

        public void SetConfiguration(string connectionString) {
            _connecitonString = connectionString;   
        }

        public MySqlConnection getConnection(string? username = "root", string? password = "")
        {
            if (_connecitonString == null)
            {
                _connecitonString = _configuration.GetValue<string>("ConnectionStrings");
                if (!String.IsNullOrEmpty(username))
                {
                    _connecitonString = _connecitonString + "User ID = " + username + ";";
                }

                if (!String.IsNullOrEmpty(password))
                {
                    _connecitonString = _connecitonString + "Password=" + password + ";";
                }
            }
            MySqlConnection connection = new (_connecitonString);
            connection.Open();
            return connection;
        }

        public SqliteConnection testMockDatabase()
        {
            SqliteConnection connection = new("Filename=:memory:");
            connection.Open();
            return connection;
        }

        public List<T> ConvertSingleColumnList<T>(DataSet dataSet, string columnName)
        {
            if (dataSet.Tables != null)
            {
                List<T> result = new();
                foreach (var bla in dataSet.Tables[0].AsEnumerable())
                {
                    result.Add((T)bla[columnName]);
                }
                return result;
            }
            else
            {
                return new List<T>();
            }
        }

        public List<List<T>> ConvertDataSetToList<T>(DataSet dataSet, List<string> columnNames)
        {
            if (dataSet.Tables != null)
            {
                List<List<T>> result = new();
                foreach (var bla in dataSet.Tables[0].AsEnumerable())
                {
                    List<T> temp = new();
                    foreach (var c in columnNames)
                    {
                        temp.Add((T)bla[c]);
                    }
                    result.Add(temp);
                }
                return result;
            }
            else
            {
                return new List<List<T>>();
            }
        }

        public List<T> ConvertRowToList<T>(DataSet dataSet, string columnName, int index)
        {
            if (dataSet.Tables != null)
            {
                List<T> result = new();
                foreach (var bla in dataSet.Tables[0].AsEnumerable())
                {
                    List<T> temp = new();
                    foreach (var c in columnName)
                    {
                        temp.Add((T)bla[c]);
                    }
                    result = temp;
                }
                return result;
            }
            else
            {
                return new List<T>();
            }
        }
    }
}
