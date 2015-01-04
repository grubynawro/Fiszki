using System.Windows;
using System.Data.SQLite;
using System.Data;


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
        private void Click_Reset(object sender, RoutedEventArgs e)
        {


            SQLiteConnection oSqLiteConnection = new SQLiteConnection("Data Source=Fisz.s3db");
            oSqLiteConnection.Open();

            // SQLiteCommand command = new SQLiteCommand(add, oSQLiteConnection);
            using (var reset = new SQLiteCommand(oSqLiteConnection))
            {
                using (var transaction = oSqLiteConnection.BeginTransaction())
                {
                    reset.CommandText = "UPDATE WORD SET COUNTER = 0";

                    reset.ExecuteNonQuery();
                    transaction.Commit();
                    oSqLiteConnection.Close();


                }
            }
            
            
            
            Close();
        }
        
    }
}
