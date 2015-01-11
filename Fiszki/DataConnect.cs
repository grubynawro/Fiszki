using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Fiszki
{
   
    

    class DataConnect
    {

        private SQLiteDataAdapter m_oDataAdapter = null;
        private DataSet m_oDataSet = null;
        private DataTable m_oDataTable = null;



      /*  public void InitBinding()
        {
                SQLiteConnection oSQLiteConnection = 
                    new SQLiteConnection("Data Source=Fisz.s3db");
               // SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
               // oCommand.CommandText = "SELECT * FROM PersonData";
                m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                    oSQLiteConnection);
                SQLiteCommandBuilder oCommandBuilder = 
                    new SQLiteCommandBuilder(m_oDataAdapter);
                m_oDataSet = new DataSet();
                m_oDataAdapter.Fill(m_oDataSet);
                m_oDataTable = m_oDataSet.Tables[0];
                lstItems.DataContext = m_oDataTable.DefaultView;
        }
        public void GetWords()
        {
            SQLiteCommand wordList = oSQLite
        }*/
      

        
    }

}
