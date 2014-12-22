using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;


namespace Fiszki
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddWordWindow
    {
        private SQLiteDataAdapter m_oDataAdapter;
        private DataSet m_oDataSet = null;
        private DataTable m_oDataTable = null;

        public AddWordWindow()
        {
            InitializeComponent();
        }
        private void Click_GoBack(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (m_oDataAdapter != null)
            {
                m_oDataAdapter.Dispose();
                m_oDataAdapter = null;
            }

            new MainWindow().Show();

        }
        private void Click_Add(object sender, RoutedEventArgs e)
        {
            BindingExpression plword = plWord.GetBindingExpression(TextBox.TextProperty);
            plword.UpdateSource();
            BindingExpression spword = spWord.GetBindingExpression(TextBox.TextProperty);
            spword.UpdateSource();
            SQLiteConnection oSqLiteConnection = new SQLiteConnection("Data Source=Fisz.s3db");
            oSqLiteConnection.Open();

            // SQLiteCommand command = new SQLiteCommand(add, oSQLiteConnection);
            using (var add = new SQLiteCommand(oSqLiteConnection))
            {
                using (var transaction = oSqLiteConnection.BeginTransaction())
                {
                    add.CommandText = "INSERT INTO WORD(PLWORD,SPWORD) VALUES('" + plWord.Text + "','" + spWord.Text + "')";

                    add.ExecuteNonQuery();
                    transaction.Commit();
                    plWord.Text = "Dodaj kolejne słowo";
                    spWord.Text = "";
                    oSqLiteConnection.Close();


                }
            }

        }
        
    }
}


        