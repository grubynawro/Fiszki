using System.Windows;
using System.Data.SQLite;

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
            Score WordCount = new Score();
            Score ScoreCount = new Score();
            SQLiteConnection oSqLiteConnection = new SQLiteConnection("Data Source=Fisz.s3db");
            oSqLiteConnection.Open();
           
            using (var count = new SQLiteCommand(oSqLiteConnection))
            {
                using (var transaction = oSqLiteConnection.BeginTransaction())
                {
                    count.CommandText = "SELECT COUNT(ID_WORD) FROM Word WHERE ISGOOD = 1";
                    WordCount.SetResult(count.ExecuteNonQuery());

                    count.CommandText = "SELECT COUNT(ID_WORD) FROM Word";
                    WordCount.SetPossible(count.ExecuteNonQuery());

                    ScoreCount.SetPossible((count.ExecuteNonQuery()) * 5);

                    count.CommandText = "SELECT SUM(COUNTER) FROM WORD";
                    ScoreCount.SetResult(count.ExecuteNonQuery());

                    transaction.Commit();
                    oSqLiteConnection.Close();
                 }
            }

            Score1.Content = "Zapamiętane słowa " + WordCount.GetResult() + " z " + WordCount.GetPossible();
            Score2.Content = "Twój wynik: " + ScoreCount.GetResult() + " z " + ScoreCount.GetPossible();


        }

    }
}
