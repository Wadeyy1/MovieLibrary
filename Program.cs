using System;

namespace MovieLibrary
{
    class Program
    {
        //Import Rankings into list
        //spit out ranking board

        static void Main(string[] args)
        {
            var filmlib = new Films();

            var done = false;

            while(!done)
            {       
                Console.WriteLine("Please enter a film Name:");
                var input = Console.ReadLine();
                filmlib.AddFilm(input);

                Console.WriteLine("Please enter a film rating 1 - 10:");
                input = Console.ReadLine();
                var rating = double.Parse(input);
                filmlib.AddFilmRating(rating);
                
                Console.WriteLine("Would you like to enter another film? y/n:");
                input = Console.ReadLine();

                if(input == "n")
                {
                    done = true;
                    continue;
                }
            }

            filmlib.Summerise();

            var filmcount = filmlib.count();      

            Console.WriteLine($"Thank you for entering your films, there are now {filmcount} entered.");  

        }

        
    }
}
