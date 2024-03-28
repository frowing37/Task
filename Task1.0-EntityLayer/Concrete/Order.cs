using System.Diagnostics.CodeAnalysis;

namespace Task1._0_EntityLayer.Concrete;

public class Order
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public decimal Price { get; set; }
    public string StoreName { get; set; }
    public string CustomerName { get; set; }
    public DateTime CreatedOn { get; set; }
    public OrderStatus Status { get; set; }
}