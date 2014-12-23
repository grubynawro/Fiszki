using System.Windows;

//using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Fiszki
{
    /// <summary>
    /// Interaction logic for DeleteWordWindow.xaml
    /// </summary>
    
    public partial class DeleteWordWindow
    {

        private SQLiteDataAdapter m_oDataAdapter;
        private DataSet m_oDataSet;
        private DataTable m_oDataTable;
        
        
        
        public DeleteWordWindow()
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
            if ( m_oDataAdapter != null)
            {
                m_oDataAdapter.Dispose();
                m_oDataAdapter = null;
            }

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
