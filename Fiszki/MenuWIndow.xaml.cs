using System.Windows;

namespace Fiszki
{
    /// <summary>
    /// Interaction logic for MenuWIndow.xaml
    /// </summary>
    public partial class MenuWindow
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void LearnStartButton_OnClick(object sender, RoutedEventArgs e)
        {
            new LearnWindow().Show();
            Close();
        }
    }
}
