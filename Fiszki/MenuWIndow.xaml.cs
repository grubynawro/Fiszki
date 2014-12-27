using System;
using System.Windows;
using MahApps.Metro.Controls;

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
            newWindow.GoodAnswersCounter = 0;
            newWindow.BadAnswersCounter = 0;
            newWindow.Show();
            Close();
        }
    }
}
