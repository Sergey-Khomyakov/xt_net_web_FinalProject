using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Entities
{   
    public class BookModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public byte[] Image { get; set; }
        public DateTime DateCreatedBook { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int IdBook { get; set; }

    }
}
