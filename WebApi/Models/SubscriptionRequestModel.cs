using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class SubscriptionRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
