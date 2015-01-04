using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiszki.Data
{
    class Word
    {
        public int Id { get; set; }

        public string PlWord { get; set; }
        public string SpWord { get; set; }
        public int CategoryId { get; set; }

        public string Category
        {
            get
            {
                return Data.Categories.Where(k => k.Id == CategoryId).Select(t => t.Name).FirstOrDefault();
                
            }
        }
    
    }
}
