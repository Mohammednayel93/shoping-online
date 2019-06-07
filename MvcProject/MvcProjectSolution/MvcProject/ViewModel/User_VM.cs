using MvcProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MvcProject.ViewModel
{
    public class User_VM : User
    {
        [NotMapped]
        [Required(ErrorMessage = "*")]
        public string OldPassword { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "*")]
        public string NewPassword { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "*")]
        [Compare("NewPassword", ErrorMessage = "Password Not Match")]
        public string ConfirmPasswordForChange { get; set; }


        [NotMapped]
        [Required(ErrorMessage = "*")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
        [NotMapped]

        public HttpPostedFileBase ImagePath { get; set; }
    }
}