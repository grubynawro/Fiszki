using System;
using System.Windows;
using System.Data.SQLite;
using System.Data;

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
            newWindow.ProgressBar.Maximum = Convert.ToInt32(NumberOfWordsBox.Text);
            newWindow.Show();
            Close();
        }
    }
}
