using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using System.Collections;

namespace ApteraMovies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MovieRepository repo;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            repo = new MovieRepository();

            repo.Add(new Movie("The Godfather", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son. (175 mins.)", 1972));
            repo.Add(new Movie("The Shawshank Redemption", "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency. (142 mins.)", 1994));
            repo.Add(new Movie("Schindler's List", "In Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis. (195 mins.)", 1993));
            repo.Add(new Movie("Raging Bull", "An emotionally self-destructive boxer's journey through life, as the violence and temper that leads him to the top in the ring, destroys his life outside it. (129 mins.)", 1980));
            repo.Add(new Movie("Casablanca", "Set in Casablanca, Morocco during the early days of World War II: An American expatriate meets a former lover, with unforeseen complications. (102 mins.)", 1942));

            refreshListBox();

        }

        private void refreshListBox()
        {
            listBox.Items.Clear();
            foreach (Movie m in repo.GetAll())
            {
                listBox.Items.Add(m);
            }
        }

        private void addMovie(object sender, RoutedEventArgs e)
        {
            Movie movie = new Movie();
            movie.Title = titleText.Text;
            movie.Synopsis = synopsisText.Text;
            int year;
            if (int.TryParse(yearText.Text, out year)) {
                movie.Year = year;
            } else
            {
                movie.Year = 0;
            }

            repo.Add(movie);

            refreshListBox();

        }

        /**
        * Removes the selected movie or last movie added if none are selected.
        */
        private void removeMovie(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null) {
                repo.Remove((IMovie)listBox.SelectedItem);
            }
            else
            {
                if (repo.Size() > 0)
                {
                    repo.Remove(repo.GetByID(repo.Size() - 1));
                }
            }

            refreshListBox();

        }

    }
}
