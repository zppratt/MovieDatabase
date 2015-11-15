using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
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
