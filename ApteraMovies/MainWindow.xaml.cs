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

namespace ApteraMovies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource movieViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("movieViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // movieViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource movieRepositoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("movieRepositoryViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // movieRepositoryViewSource.Source = [generic data source]
        }

        private void addMovie()
        {
            
        }

        private void removeMovie()
        {

        }

    }
}
