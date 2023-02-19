using MySql.Data.MySqlClient;
using System.Data;

namespace JulAPI.HelperClasses
{
    public static class HelperConnection
    {
        private static IConfiguration _configuration { get; set; }

        private static string? _connecitonString { get; set; }

        public static void SetConfiguration(IConfiguration config)
        {
            _configuration = config;
        }

        public static MySqlConnection getConnection(string username = "root", string password = "")
        {
            if (_connecitonString == null)
            {
                _connecitonString = _configuration.GetValue<string>("ConnectionStrings");
                _connecitonString = _connecitonString + "User ID = " + username + ";";

                if (password != null)
                {
                    _connecitonString = _connecitonString + "Password=" + password + ";";
                }
            }
            var connection = new MySqlConnection(_connecitonString);
            connection.Open();
            return connection;
        }

        public static List<T> ConvertSingleColumnList<T>(DataSet dataSet, string columnName)
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

        public static List<List<T>> ConvertDataSetToList<T>(DataSet dataSet, List<string> columnNames)
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

        public static List<T> ConvertRowToList<T>(DataSet dataSet, string columnName, int index)
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
