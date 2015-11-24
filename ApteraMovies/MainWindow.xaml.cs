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

            repo.Add(new Movie("asdf", "asdf", 1987));
            repo.Add(new Movie("afsddfsa", "asdf", 1985));
            repo.Add(new Movie("afsdsfddfsadsafsdfa", "asdf", 1984));

            //listBox.DisplayMemberPath = "ToString";
            listBox.ItemsSource = repo.GetAll();

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

            listBox.Items.Refresh();

        }

        private void removeMovie(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null) {
                repo.Remove((IMovie)listBox.SelectedItem);
            }
            listBox.Items.Refresh();
        }
    }
}
