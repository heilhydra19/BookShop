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
        public int Id { get; set; }
        private DateTime _createdAt = DateTime.Now;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        [Display(Name = "Ngày Tạo")]
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
        [Display(Name = "Nhân viên lập")]
        public ApplicationUser EmployeeNavigation { get; set; }
        [Display(Name = "Khách Hàng")]
        public ApplicationUser CustomerNavigation { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; } 
    }
}
