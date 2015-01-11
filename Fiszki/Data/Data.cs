using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiszki.Data
{
    static class Data
    {

        static Data()
        {
            Words = new List<Word>();
            Categories = new List<Category>();

        }


        public static List<Word> Words { get; private set; }
        public static List<Category> Categories { get; private set; }



        public static void DownloadAll()
        {
            var dataReader = DatabaseConnection.Execute("Select * from Word").ExecuteReader();

            while (dataReader.Read())
            {
                var word = new Word
                (
                     dataReader.GetInt32(0),
                     dataReader.GetString(1),
                     dataReader.GetString(2),
                     dataReader.GetInt32(5),
                     dataReader.GetInt32(3),
                     dataReader.GetInt32(4)
                );

                Words.Add(word);
            }

            dataReader.Close();

            dataReader = DatabaseConnection.Execute("Select * from CATEGORY").ExecuteReader();

            while (dataReader.Read())
            {
                var category = new Category
                {
                    Id = dataReader.GetInt32(0),
                    Name = dataReader.GetString(1),

                };
                Categories.Add(category);

            }

            dataReader.Close();
        }

        public static void UpdateWords()
        {
	        foreach (var word in Words.Where(word => word.Changed))
	        {
		        string updateQuery = "update Word set COUNTER= " + word.Counter + " where ID_WORD =" + word.Id;
				DatabaseConnection.Execute(updateQuery).ExecuteNonQuery();
		        word.Changed = false;
	        }
        }
    }
}