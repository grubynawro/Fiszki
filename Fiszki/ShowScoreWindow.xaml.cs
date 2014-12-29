using System.Windows;
using System.Data.SQLite;
using System;

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
                    SQLiteDataReader reader;
                    int WordCountResult = 0;
                    count.CommandText = "SELECT * FROM Word WHERE ISGOOD = 1";
                    reader = count.ExecuteReader();
                    while (reader.Read())
                    {

                        WordCountResult++;

                    }


                    WordCount.SetResult(WordCountResult);
                    transaction.Commit();
                 }

            }
           
           
          using (var count = new SQLiteCommand(oSqLiteConnection))
            {

            
                using (var transaction = oSqLiteConnection.BeginTransaction())
                {
                    SQLiteDataReader reader;
                    int Possible = 0;
                    count.CommandText = "SELECT * FROM Word";
                    reader = count.ExecuteReader();
                    while( reader.Read())
                    {
                        Possible++;
                    }
                    WordCount.SetPossible(Possible);
                    ScoreCount.SetPossible(Possible * 5);
                    transaction.Commit();
                }

            }
          
          using (var count = new SQLiteCommand(oSqLiteConnection))
          {

            
                using (var transaction = oSqLiteConnection.BeginTransaction())
                {
                    SQLiteDataReader reader;

                    int countScore = 0;
                    count.CommandText = "SELECT * FROM Word";
                    reader = count.ExecuteReader();
                    while (reader.Read())
                    {

                        countScore += reader.GetInt32(3);

                    }
                    ScoreCount.SetResult(countScore);
                    transaction.Commit();
                }

            }
            oSqLiteConnection.Close();



            Score1.Content = "Zapamiętane słowa " + WordCount.GetResult() + " z " + WordCount.GetPossible();
            Score2.Content = "Twój wynik: " + ScoreCount.GetResult() + " z " + ScoreCount.GetPossible();



        /*    SQLiteDataReader reader2;

            count.CommandText = "SELECT ID_WORD FROM Word";

            reader2 = count.ExecuteReader();
            WordCount.SetPossible(reader2.FieldCount);
            ScoreCount.SetPossible(reader2.FieldCount * 5);

            // SQLiteDataReader reader3;

            count.CommandText = "SELECT SUM(COUNTER) FROM WORD";

            ScoreCount.SetResult(reader.FieldCount);

            transaction.Commit();
            oSqLiteConnection.Close();*/
                    


        }

    }
}
