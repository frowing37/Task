using Task1._0_EntityLayer.Concrete;

namespace Task1._0_OrderSaver.Model;

public class OrderDto
{
    public int BrandId { get; set; }
    public decimal Price { get; set; }
    public string StoreName { get; set; }
    public string CustomerName { get; set; }
    public OrderStatus Status { get; set; }
}