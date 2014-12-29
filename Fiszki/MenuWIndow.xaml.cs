using System;
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
            LearnWindow newWindow = new LearnWindow();
            newWindow.MaxWordLabel.Content = NumberOfWordsBox.Text;
            newWindow.Show();
            Close();
        }
    }
}
