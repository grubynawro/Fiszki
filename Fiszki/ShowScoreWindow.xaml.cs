using System.Windows;
using System.Linq;
using System.Data.SQLite;
using System;
using Fiszki.Data;

namespace Fiszki
{
    /// <summary>
    /// Interaction logic for ShowScoreWindow.xaml
    /// </summary>
    public partial class ShowScoreWindow
    {
  
        public ShowScoreWindow()
        {
            InitializeComponent();
            InitBinding();
        }

        private void Click_GoBack(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new MainWindow().Show();
        }

        private void InitBinding()
        {
          
            


            Score1.Content = "Zapamiętane słowa " + Data.Data.Words.Count(t=>t.IsGood)  + " z " + Data.Data.Words.Count;
            Score2.Content = "Twój wynik: " + Data.Data.Words.Sum(t=>t.Counter) + " z " + (Data.Data.Words.Count * 5);



                    


        }

    }
}
