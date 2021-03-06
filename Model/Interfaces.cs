﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        
        public Movie()
        {

        }

        public Movie(string title, string synopsis, int year)
        {
            this.ID = this.GetHashCode();
            this.Synopsis = synopsis;
            this.Title = title;
            this.Year = year;
        }

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

        public override string ToString()
        {
            return "Title: " + _title + "\n" +
            "Synopsis: " + _synopsis + "\n" +
            "Year: " + _year + "\n";
        }

    }

    public class MovieRepository : IMovieRepository
    {
        // Dictionary object to store all the movies in memory
        Dictionary<int, IMovie> _movies = new Dictionary<int, IMovie>();

        // Adds a movie, uses ID as key in the dictionary object
        public void Add(IMovie movie)
        {
            try {
                movie.ID = Size();
                _movies.Add(movie.ID, movie);
            }
            catch
            {
                movie.ID++;
                _movies.Add(movie.ID, movie);
            }
        }

        // Returns the movies in the Dictionary
        public IEnumerable<IMovie> GetAll()
        {
            return _movies.Values.OrderByDescending(x=>x.Year);
        }

        // Gets movies by id, throws exception if no movie is in the Dictionary
        public IMovie GetByID(int id)
        {
            try {
                return _movies[id];
            }
            catch
            {
                return null;
            }
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

        // Removes movie entry by ID
        public void Remove(IMovie movie)
        {
            _movies.Remove(movie.ID);            
        }

        public int Size()
        {
            return _movies.ToArray().Length;
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
