using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleApplication
{
    class Program
    {

        static MovieRepository repo = new MovieRepository();

        static void Main(string[] args)
        {
            Movie mov1 = new Movie("The greatest movie ever.", "Just sooo great.", 1934);
            Movie mov2 = new Movie("Ooo its a movie", "Also a great movie.", 1950);
            Movie mov3 = new Movie("Movie3", "Just an okay movie", 1980);

            repo.Add(mov1);
            repo.Add(mov2);
            repo.Add(mov3);
            
            while (true)
            {
                Console.WriteLine();
                listMovies();
                String input = getInput();
                if (input.Equals("a", StringComparison.InvariantCultureIgnoreCase))
                {
                    addMovie();
                }
                else if (input.Equals("r", StringComparison.InvariantCultureIgnoreCase))
                    removeMovie();
                {
            }
        }
        }

        // Removes a movie by the given identifier. If the user enters a number this function looks for a movie
        // by ID, if the user enters a string the function looks for a movie by title.
        private static void removeMovie()
        {
            Console.WriteLine();
            Console.WriteLine("Remove what? (ID or Title)");
            string input = getInput();
            int i;
            Console.WriteLine();
            if (int.TryParse(input, out i))
            {
                Console.WriteLine("You entered a number.");
            } else {
                Console.WriteLine("You entered a string.");
            }
        }

        private static void addMovie()
        {
            Console.WriteLine();
            Movie movie = new Movie();
            Console.WriteLine();
            Console.WriteLine("Add what movie? (Title)");
            movie.Title = getInput();
            Console.WriteLine();
            Console.WriteLine("Enter movie synopsis:");
            movie.Synopsis = getInput();
            Console.WriteLine();
            Console.WriteLine("What year was the movie made?");
            movie.Year = int.Parse(getInput());
            repo.Add(movie);
            Console.WriteLine();
            Console.WriteLine("Movie entered. ID is: " + repo.GetByTitle(movie.Title).ID); // echos movie ID for reference and confirmation
        }

        private static String getInput()
        {
            Console.WriteLine();
            Console.Write("Enter input:");
            string input = Console.ReadLine();
            if (input.Equals("q", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine();
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            }
            return input;
        }

        private static void listMovies()
        {
            Console.WriteLine();
            foreach (Movie movie in repo.GetAll())
            {
                Console.WriteLine(movie.Title);
            }
        }
    }
}
