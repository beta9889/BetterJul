using System.Data;

namespace Shared
{
    public record Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GenreName { get; set; }
        public string PickedBy { get; set; }
        public float Imbd_rating { get; set; }
        public string JayOrNay { get; set; }
        public string IsMajor { get; set; }

        public static Movies RowToModel(DataRow dataRow)
        {
            Movies result = new()
            {
                Id = (int)dataRow["id"],
                Imbd_rating = (float)dataRow["imdb_rating"],
                IsMajor = (string)dataRow["is_major"]
            };
            result.JayOrNay = (string)dataRow["jayornay"];
            result.PickedBy = (string)dataRow["picked_by"];
            result.Name = (string)dataRow["name"];
            result.GenreName = (string)dataRow["genre_name"];
            return result;   
        }
    }
}
