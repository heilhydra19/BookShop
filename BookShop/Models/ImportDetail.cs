using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace BookShop.Models
{
    public class ImportDetail
    {
        [Key, Column(Order = 1)]
        public int ImportId { get; set; }
        [Key, Column(Order = 2)]
        public int BookId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public Book BookNavigation { get; set; }
        public Import ImportNavigation { get; set; }
    }
}
