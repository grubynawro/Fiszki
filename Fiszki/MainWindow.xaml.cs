using System.Windows;
using MahApps.Metro.Controls;
namespace Fiszki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
             InitializeComponent();
        }

        private void Click_NewLearn(object sender, RoutedEventArgs e)
        {
            new LearnWindow().Show();
            Close();
        }
        private void Click_AddWord(object sender, RoutedEventArgs e)
        {
            new AddWordWindow().Show();
            Close();
        }
        private void Click_DeleteWord(object sender, RoutedEventArgs e)
        {
            new DeleteWordWindow().Show();
            Close();
        }
        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Click_ResetScore(object sender, RoutedEventArgs e)
        {
            new ResetScoreWindow().Show();
  }
        private void Click_ShowScore(object sender, RoutedEventArgs e)
        {
            new ShowScoreWindow().Show();
            Close();
        }
    }
}
