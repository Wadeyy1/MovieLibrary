using System;
using System.Collections.Generic;
using System.Linq;

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