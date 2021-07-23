using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Models
{
    public class Supplier
    {
        public Supplier()
        {
            Imports = new HashSet<Import>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name = "Tên nhà cung cấp")]
        public string Name { get; set; }
        [MaxLength(10, ErrorMessage = "Số điện thoại phải có 10 số")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        private DateTime _createdAt = DateTime.Now;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        [Display(Name = "Tên nhà cung cấp")]
        public DateTime CreateAt
        {
            get
            {
                return (_createdAt == DateTime.MinValue) ? DateTime.Now : _createdAt;
            }
            set { _createdAt = value; }
        }
        [MaxLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [MaxLength(150)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        public virtual ICollection<Import> Imports { get; set; }
    }
}
