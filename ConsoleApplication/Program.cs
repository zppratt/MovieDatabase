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
            repo.Add(new Movie("The Godfather", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son. (175 mins.)", 1972));
            repo.Add(new Movie("The Shawshank Redemption", "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency. (142 mins.)", 1994));
            repo.Add(new Movie("Schindler's List", "In Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis. (195 mins.)", 1993));
            repo.Add(new Movie("Raging Bull", "An emotionally self-destructive boxer's journey through life, as the violence and temper that leads him to the top in the ring, destroys his life outside it. (129 mins.)", 1980));
            repo.Add(new Movie("Casablanca", "Set in Casablanca, Morocco during the early days of World War II: An American expatriate meets a former lover, with unforeseen complications. (102 mins.)", 1942));

            while (true)
            {
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
                try
                {
                    string title = repo.GetByID(i).Title;
                    repo.Remove(repo.GetByID(i));
                    Console.WriteLine("'" + title + "' removed.");
                }
                catch
                {
                    Console.WriteLine("Nothing removed.");
                }
                }
            else {
                try {
                    repo.Remove(repo.GetByTitle(input));
                    Console.WriteLine("'" + input + "' removed.");
                }
                catch
                {
                    Console.WriteLine("Could not find the movie.");
                }
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
            try {
                movie.Year = int.Parse(getInput());
            }
            catch
            {
                movie.Year = 0;
            }
            repo.Add(movie);
            Console.WriteLine();
            // Echos movie ID for reference and confirmation
            Console.WriteLine("'" + movie.Title + "' added. ID is: " + repo.GetByTitle(movie.Title).ID);
        }

        private static String getInput()
        {
            Console.WriteLine();
            Console.Write("Enter input (a,r,q): ");
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
            foreach (Movie movie in repo.GetAll().OrderByDescending(x=>x.Year))
            {
                Console.WriteLine(movie);
            }
        }
    }
}
