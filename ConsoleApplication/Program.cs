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
        static void Main(string[] args)
        {
            while (true)
            {
                listMovies();
                String input = getInput();
                if (input.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                {
                    Environment.Exit(0);
                }
                else if (input.Equals("a", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Movie added.");
                    Console.WriteLine("");
                    // addMovie();
                }
                else if (input.Equals("r", StringComparison.InvariantCultureIgnoreCase))
                    Console.WriteLine("");
                    Console.WriteLine("Movie removed.");
                    Console.WriteLine("");
                    // removeMovie();
                {

            }
        }
        }

        private static String getInput()
        {
            Console.Write("Enter input:");
            return Console.ReadLine();
        }

        private static void listMovies()
        {
            Console.WriteLine("Movies in database:");
            Console.WriteLine("How The West Was Won");
            Console.WriteLine("Star Wars: A New Hope");
            Console.WriteLine("The Dark Knight");
            Console.WriteLine("");
        }
    }
}
