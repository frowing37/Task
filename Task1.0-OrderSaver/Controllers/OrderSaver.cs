using Microsoft.AspNetCore.Mvc;
using Task1._0_BusinessLogicLayer.Abstract;
using Task1._0_EntityLayer.Concrete;
using Task1._0_OrderSaver.Model;

namespace Task1._0_OrderSaver.Controllers;

[Route("api/[controller]")]
public class OrderSaver : Controller
{
    private readonly IOrderService _orderService;

    public OrderSaver(IOrderService orderService) => _orderService = orderService;
    
    [HttpPost]
    public IActionResult PostOrder([FromBody] List<OrderDto> orders)
    {
        try
        {
            var ordersWillPost = new List<Order>();
            
            foreach (var order in orders)
            {
                //BrandId değeri 0 olmayanlar listeye ekleniyor
                if (order.BrandId != 0)
                {
                    ordersWillPost.Add(new Order()
                    {
                        BrandId = order.BrandId,
                        CustomerName = order.CustomerName ?? "Customer name is not given",
                        StoreName = order.StoreName ?? "Store name is not given",
                        Price = order.Price,
                        Status = order.Status,
                        CreatedOn = DateTime.Now
                    });
                }
            }

            //Listedekiler kaydediliyor
            foreach (var order in ordersWillPost)
            {
                _orderService.AddwS(order);
            }
            
            return Ok("Orders were posted with successfully");
        }

        catch (Exception e)
        {
            return StatusCode(500,e.Message);
        }
    }
}