using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Models
{
    public class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>(); 
        }
        [Column("id")]
        public int Id { get; set; }
        private DateTime _createdAt = DateTime.Now;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        public DateTime CreateAt
        {
            get
            {
                return (_createdAt == DateTime.MinValue) ? DateTime.Now : _createdAt;
            }
            set { _createdAt = value; }
        }
        [ForeignKey("EmployeeNavigation")]
        public string EmployeeId { get; set; }
        [ForeignKey("CustomerNavigation")]
        public string CustomerId { get; set; }
        public ApplicationUser EmployeeNavigation { get; set; }
        public ApplicationUser CustomerNavigation { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; } 
    }
}
