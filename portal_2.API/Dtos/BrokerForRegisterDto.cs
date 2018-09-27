using System.ComponentModel.DataAnnotations;

namespace portal_2.API.Dtos
{
    public class BrokerForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 8, ErrorMessage = "You must specify a password between 8 and 16 characters")]
        public string Password { get; set; }
    }
}