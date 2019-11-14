using System.ComponentModel.DataAnnotations;
using Auth.Core.Entities;

namespace Auth.Web.Models
{
    public class RefreshAuthenticatedUserBindingModel
    {
        [Required(ErrorMessage = "Access token is required.")]
        public string AccessToken { get; set; }

        [Required(ErrorMessage = "Refresh token is required.")]
        public string RefreshToken { get; set; }
    }
}