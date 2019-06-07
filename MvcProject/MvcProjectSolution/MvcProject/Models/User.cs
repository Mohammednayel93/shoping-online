namespace MvcProject.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            ContactUs = new HashSet<ContactU>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invaild Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        public int Role_Id { get; set; }

        public bool? Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactU> ContactUs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Role Role { get; set; }
    }
}
