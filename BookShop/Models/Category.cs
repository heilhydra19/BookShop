using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Models
{
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name = "Tên thể loại")]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
