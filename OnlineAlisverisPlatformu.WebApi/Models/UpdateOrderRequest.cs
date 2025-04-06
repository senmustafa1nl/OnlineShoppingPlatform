using System.ComponentModel.DataAnnotations;

namespace OnlineAlisverisPlatformu.WebApi.Models
{
    public class UpdateOrderRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
