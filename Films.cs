using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace MovieLibrary
{
    internal class Films
    {
        public Films()
        {
            filmnames = new List<string>();
            filmrating = new List<double>();
        }

        List<string> filmnames;
        List<double> filmrating;
        

        public void AddFilm(string film)
        {
            filmnames.Add(film);
        }

        public void writetodb(string input, double rating)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =  "Data Source=DESKTOP-VPT1VQI\\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=true";

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter(); 
            String sql="";
            
            sql = $"INSERT INTO Movies_DB (Film_Name,Rating) values('{input}',{rating})";
            
            conn.Open();
            command = new SqlCommand(sql,conn);
            adapter.InsertCommand = new SqlCommand(sql,conn); 
            adapter.InsertCommand.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();

            // The below code allows you to select * from table

            /*sql = "SELECT * FROM dbo.Movies_DB";
            command = new SqlCommand(sql,conn);        
            using (SqlDataReader reader = command.ExecuteReader())
            while (reader.Read())
            {
                // write the data on to the screen
                Console.WriteLine(String.Format("{0} \t | {1} \t | {2}",
                // call the objects from their index
                reader[0], reader[1], reader[2]));
            }*/
        }

        public int count()
        {
            return filmnames.Count;
        }

        public void AddFilmRating(double rating)
        {
            filmrating.Add(rating);
        }

        public void Summerise()
        {
            var namesandratings = filmnames.Zip(filmrating, (w, n) => new { Number = n, Word = w });

            foreach(var nw in namesandratings)
            {
                Console.WriteLine($"Film Name: {nw.Word} and it has a rating of: {nw.Number}/10");
            }
        }
    }
}