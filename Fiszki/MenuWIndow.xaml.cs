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
        private SQLiteDataAdapter m_oDataAdapter;
        private DataSet m_oDataSet;
        private DataTable m_oDataTable;
        public MenuWindow()
        {
            InitializeComponent();
            FillComboBox();
        }

        void FillComboBox()
        {
            SQLiteConnection oSQLiteConnection = new SQLiteConnection("Data Source=Fisz.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            oCommand.CommandText = "select name from category";
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText, oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder = new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];
            CategoryComboBox.Items.Add(m_oDataTable);
            CategoryComboBox.DataContext = m_oDataTable.DefaultView;


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
