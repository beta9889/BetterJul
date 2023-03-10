using JulAPI.HelperClasses;
using MySql.Data.MySqlClient;
using Shared;
using System.Collections.Generic;
using System.Data;

namespace JulAPI.Service
{
    public interface IMovieService
    {
        public List<Movies> Get();
    }
    public class MoviesService: IMovieService
    {
        private readonly IHelperConnection _connectionHelper;
        public MoviesService(IHelperConnection connectionHelper) 
        {
            _connectionHelper = connectionHelper;            
        }

        public List<Movies> Get()
        {
            MySqlDataAdapter adapter = new();
            DataSet dataSet = new();
            using(var connection = _connectionHelper.getConnection())
            using (var command = connection.CreateCommand())
            {
                {
                    command.CommandText = "select * from movie;";
                    command.CommandType= CommandType.Text;
                    adapter.SelectCommand= command;
                    adapter.Fill(dataSet);

                }
            }
            List<Movies> result = new();
            foreach (DataRow row in dataSet.Tables[0].AsEnumerable())
            {
                result.Add(Movies.RowToModel(row));
            }
            return result;
        }
    }
}
