namespace MvcProject.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ContactU
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Invaild Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]

        public string Message { get; set; }

        public int User_Id { get; set; }

        public virtual User User { get; set; }
    }
}
