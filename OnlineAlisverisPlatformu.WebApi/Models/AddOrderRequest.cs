using System.ComponentModel.DataAnnotations;

namespace OnlineAlisverisPlatformu.WebApi.Models
{
    public class AddOrderRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public List<int> ProductIds { get; set; }
    }
}
