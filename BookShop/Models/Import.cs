using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Models
{
    public class Import
    {
        public Import()
        {
            ImportDetails = new HashSet<ImportDetail>();
        }
        public int Id { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("EmployeeNavigation")] 
        public string EmployeeId { get; set; }
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
        public Supplier SupplierNavigation { get; set; }
        public ApplicationUser EmployeeNavigation { get; set; }
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
    }
}
