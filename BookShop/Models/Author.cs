using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Models
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name = "Tên tác giả")]
        public string Name { get; set; }
        private DateTime _createdAt = DateTime.Now;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        [Display(Name = "Ngày tạo")]
        public DateTime CreateAt
        {
            get
            {
                return (_createdAt == DateTime.MinValue) ? DateTime.Now : _createdAt;
            }
            set { _createdAt = value; }
        }
        public virtual ICollection<Book> Books { get; set; }
    }
}
