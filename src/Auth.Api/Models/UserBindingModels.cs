using System.ComponentModel.DataAnnotations;
using Auth.Core.Entities;

namespace Auth.Web.Models
{
    public class UserBindingModel
    {   
        public long Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [EmailAddress]
        public string Username { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}