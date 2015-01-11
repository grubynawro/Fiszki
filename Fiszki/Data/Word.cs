using System.Linq;

namespace Fiszki.Data
{
    class Word : DatabaseItem
    {
        private int _id;
        private string _plWord;
        private string _spWord;
        private int _categoryId;
        private int _counter;
	    // ReSharper disable once NotAccessedField.Local obsolete in db
        private int _isGood;

        public int Id
        {
            get { return _id; }
            set { _id = value; Changed = true; }
        }

        public string PlWord
        {
            get { return _plWord; }
            set { _plWord = value; Changed = true; }
        }

        public string SpWord
        {
            get { return _spWord; }
            set { _spWord = value; Changed = true; }
        }

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; Changed = true; }
        }

        public int Counter
        {
            get { return _counter; }
            set { _counter = value; Changed = true; }
        }

        public bool IsGood
        {
            get { return Counter == 5; } 
        }

        public Word(int id, string plWord, string spWord, int categoryId, int counter, int isGood)
        {
            _id = id;
            _plWord = plWord;
            _spWord = spWord;
            _categoryId = categoryId;
            _counter = counter;
            _isGood = isGood;
        }

        public string Category
        {
            get { return Data.Categories.Where(k => k.Id == CategoryId).Select(t => t.Name).FirstOrDefault(); }
        }
    }
}