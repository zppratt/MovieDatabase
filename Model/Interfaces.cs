using System;
using System.Collections.Generic;
using System.Collections.Hashtable;
using System.Linq;
using System.Text;

namespace Model
{
    public class Movie : IMovie
    {
        int _id;
        string _synopsis;
        string _title;
        int _year;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Synopsis
        {
            get { return _synopsis; }
            set { _synopsis = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
    }

    public class MovieRepository : IMovieRepository
    {
        // Dictionary object to store all the movies in memory
        public Dictionary<int, IMovie> _movies = new Dictionary<int, IMovie>();

        // Adds a movie, uses ID as key in the dictionary object
        public void Add(IMovie movie)
        {
            _movies.Add(movie.ID, movie);
        }

        // Returns the movies in the Dictionary
        public IEnumerable<IMovie> GetAll()
        {
            return _movies.Values;
        }

        // Gets movies by id, throws exception if no movie is in the Dictionary
        public IMovie GetByID(int id)
        {
            return _movies[id];
        }

        // Loop through movies and return the first match
        public IMovie GetByTitle(string title)
        {
            foreach (IMovie movie in _movies.Values)
            {
                if (movie.Title.Equals(title))
                {
                    return movie;
                }
            }
            return null; // no movie found
        }

        public void Remove(IMovie movie)
        {
            _movies.Remove(movie.ID); // removes movie entry by ID
        }
    }

    public interface IMovie
    {
        int ID { get; set; }
        string Title { get; set; }
        string Synopsis { get; set; }
        int Year { get; set; }
    }

    public interface IMovieRepository
    {
        IEnumerable<IMovie> GetAll();
        IMovie GetByID(int id);
        IMovie GetByTitle(string title);
        void Add(IMovie movie);
        void Remove(IMovie movie);
    }

}
