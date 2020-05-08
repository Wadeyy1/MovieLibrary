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
            var FilmNameInput = "";
            var rating = 0.0;
                 
                Console.WriteLine("Welcome, Please select from the below options:");
                Console.WriteLine("1 - Enter a new film into the library");
                Console.WriteLine("2 - Update an existing film");
                Console.WriteLine("3 - Display all stored films");

                var MenuSelection = Console.ReadLine();

                if (MenuSelection == "1")
                {
                    while(!done)
                    {  
                    Console.WriteLine("Please enter a film Name:");
                    FilmNameInput = Console.ReadLine();
                    filmlib.AddFilm(FilmNameInput);

                    Console.WriteLine("Please enter a film rating 1 - 10:");
                    var RatingInput = Console.ReadLine();
                    rating = double.Parse(RatingInput);
                    filmlib.AddFilmRating(rating);

                    filmlib.writetodb(FilmNameInput, rating);
                
                    Console.WriteLine("Would you like to enter another film? y/n:");
                    FilmNameInput = Console.ReadLine();

                    if(FilmNameInput == "n")
                    {
                        done = true;
                        continue;
                    }
                    filmlib.Summerise();
                    var filmcount = filmlib.count();    
                    Console.WriteLine($"Thank you for entering your films, there are now {filmcount} entered."); 
                    }
                    
                }
                else if (MenuSelection == "2")
                {

                }
                else if (MenuSelection == "3")
                {
                    filmlib.AllFilms();
                    Console.ReadLine();
                }
                else
                {
                    
                }           

        }

        
    }
}
