using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Fiszki
{
    /// <summary>
    /// Interaction logic for DeleteWordWindow.xaml
    /// </summary>
    
    public partial class DeleteWordWindow : Window
    {

        private SQLiteDataAdapter m_oDataAdapter = null;
        private DataSet m_oDataSet = null;
        private DataTable m_oDataTable = null;
        
        
        
        public DeleteWordWindow()
        {
            InitializeComponent();
            InitBinding();
        }
        private void Click_GoBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new MainWindow().Show();
        }
        private void Click_Delete(object sender, RoutedEventArgs e)  //funkcja usuwająca zaznaczone słówka
        {
            if (slowka.SelectedItems.Count == 0 )
            {
                return;
            }
            DataRow oDataRow = ((DataRowView)slowka.SelectedItem).Row;
            oDataRow.Delete();
            m_oDataAdapter.Update(m_oDataSet);   //update listy po usunieci
        }

      



        



        private void InitBinding()
        {
                SQLiteConnection oSQLiteConnection = 
                    new SQLiteConnection("Data Source=Fisz.s3db");
               SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
               oCommand.CommandText = "SELECT ID_WORD,PLWORD,SPWORD FROM Word";
                m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                    oSQLiteConnection);
                SQLiteCommandBuilder oCommandBuilder = 
                    new SQLiteCommandBuilder(m_oDataAdapter);
                m_oDataSet = new DataSet();
                m_oDataAdapter.Fill(m_oDataSet);
                m_oDataTable = m_oDataSet.Tables[0];
                slowka.DataContext = m_oDataTable.DefaultView;
        }


        
    }
}
