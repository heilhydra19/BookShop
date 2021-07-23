using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Models
{
    public class Book
    {
        public Book()
        {
            BillDetails = new HashSet<BillDetail>();
            ImportDetails = new HashSet<ImportDetail>();
        }
        public int Id { get; set; }
        
        [Display(Name = "Tên Sách")]
        public string Name { get; set; }
        
        public int CategoryId { get; set; }
        
        public int PublisherId { get; set; }
        
        public int AuthorId { get; set; }
        
        [Display(Name = "Giá Bìa")]
        public double Price { get; set; }
        
        [Display(Name = "Tồn Kho")]
        public int Count { get; set; }

        [Display(Name = "Hình Ảnh")]
        public int Img { get; set; }
        [Display(Name = "Thể Loại")]
        public Category CategoryNavigation { get; set; }
        [Display(Name = "Nhà Xuất Bản")]
        public Publisher PublisherNavigation { get; set; }
        [Display(Name = "Tác Giả")]
        public Author AuthorNavigation { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
        public ICollection<ImportDetail> ImportDetails { get; set; }
    }
}
