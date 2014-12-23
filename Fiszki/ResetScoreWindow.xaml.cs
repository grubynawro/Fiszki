using System.Windows;


namespace Fiszki
{
    /// <summary>
    /// Interaction logic for ResetScoreWindow.xaml
    /// </summary>
    public partial class ResetScoreWindow
    {
        public ResetScoreWindow()
        {
            InitializeComponent();
        }
        private void Click_GoBack(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
    }
}
