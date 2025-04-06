namespace OnlineAlisverisPlatformu.Business.Operations.Orders
{
    public class AddOrderDto
    {
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public List<int> ProductIds { get; set; }
    }
}