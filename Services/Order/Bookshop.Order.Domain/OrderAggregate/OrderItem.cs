namespace Bookshop.Order.Domain.OrderAggregate
{
    public class OrderItem
    {
        public OrderItem(string productId, string productName, string productUrl, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            ProductUrl = productUrl;
            Price = price;
        }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
        public decimal Price { get; set; }

        public void UpdateOrderItem(string productName, string pictureUrl, decimal price)
        {
            ProductName = productName;
            ProductUrl = pictureUrl;
            Price = price;
        }
    }
}
