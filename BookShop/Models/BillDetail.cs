using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Models
{
    public class BillDetail
    {
        [Key, Column(Order = 1)]
        public int BookId { get; set; }
        [Key, Column(Order = 2)]
        public int BillId { get; set; }
        public int Count { get; set; } 
        public Book BookNavigation { get; set; }
        public Bill BillNavigation { get; set; }
    }
}
