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

namespace Fiszki
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

        private void Click_NewLearn(object sender, RoutedEventArgs e)
        {
            new LearnWindow().Show();
            this.Close();
        }
        private void Click_AddWord(object sender, RoutedEventArgs e)
        {
            new AddWordWindow().Show();
            this.Close();
        }
        private void Click_DeleteWord(object sender, RoutedEventArgs e)
        {
            new DeleteWordWindow().Show();
            this.Close();
        }
        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Click_ResetScore(object sender, RoutedEventArgs e)
        {
            new ResetScoreWindow().Show();
            this.Close();
        }
        private void Click_ShowScore(object sender, RoutedEventArgs e)
        {
            new ShowScoreWindow().Show();
            this.Close();
        }
    }
}
