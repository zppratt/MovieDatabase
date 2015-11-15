using System;
using System.Collections.Generic;
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
        public void Add(IMovie movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMovie> GetAll()
        {
            throw new NotImplementedException();
        }

        public IMovie GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IMovie GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void Remove(IMovie movie)
        {
            throw new NotImplementedException();
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
