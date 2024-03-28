using Microsoft.AspNetCore.Mvc;
using Task1._0_BusinessLogicLayer.Abstract;
using Task1._0_EntityLayer.Concrete;
using Task1._0_OrderSearcher.Model;

namespace Task1._0_OrderSearcher.Controllers;

[Route("api/[controller]")]
public class OrderSearcher : Controller
{
    private readonly IOrderService _orderService;

    public OrderSearcher(IOrderService orderService) => _orderService = orderService;
    
    [HttpPost]
    public IActionResult SearchOrder([FromBody] OrderFilterModel filter)
    {
        try {
            var orders = _orderService.GetListwS();
            var filteredOrders = new List<Order>();

            foreach (var order in orders)
            {
                //Verilen tarih aralığı kontrolü yapılıyor
                if (order.CreatedOn >= filter.StartDate && order.CreatedOn <= filter.EndDate)
                {
                    //Verilen statü durumu kontrolü yapılıyor
                    foreach (var status in filter.Statuses)
                    {
                        if (order.Status == status)
                        {
                            //Verilen metin müşteri ve mağaza adında aranıyor
                            if (filter.SearchText is not null)
                            {
                                //Harf duyarlılığı olmaksızın arama yapılıyor
                                if ((order.CustomerName.IndexOf(filter.SearchText, StringComparison.OrdinalIgnoreCase) >= 0) || (order.StoreName.IndexOf(filter.SearchText, StringComparison.OrdinalIgnoreCase) >= 0))
                                {
                                    filteredOrders.Add(order);
                                    break;
                                }
                            }
                            else
                            {
                                filteredOrders.Add(order);
                                break;
                            }
                        }
                    }
                }
            }
            
            //Sayfalama ve sıralama işleminden önce filtreden order dönüyor mu kontrol ediliyor
            if (filteredOrders.Count == 0)
                return BadRequest("Not found order for your filter");

            //Filtreleme işleminde verilen sayıların uygunluğu kontrol ediliyor 
            if (filteredOrders.Count < (filter.PageSize * filter.PageNumber - filter.PageSize) || filter.PageSize == 0 || filter.PageNumber == 0)
                return BadRequest("Filter has pagesize and pagenumber is not appropriate");
            
            //İstenilen sayfa boyutuna göre sayfalama işlemi
            if (filteredOrders.Count > filter.PageSize)
            {
                List<Order> tempList = new List<Order>();
                var indexNumber = (filter.PageNumber * filter.PageSize) - filter.PageSize;
                
                if(filter.PageSize * filter.PageNumber > filteredOrders.Count)
                    tempList = filteredOrders.GetRange(indexNumber,filteredOrders.Count - indexNumber);
                else
                    tempList = filteredOrders.GetRange(indexNumber,(filter.PageSize));
                
                filteredOrders.Clear();
                filteredOrders = tempList;
            }
        
            //SortBy parametresine göre ascending sıralama
            if(filter.SortBy == "Id")
                filteredOrders.Sort((x,y) => x.Id.CompareTo(y.Id));
            else if(filter.SortBy == "BrandId")
                filteredOrders.Sort((x,y) => x.BrandId.CompareTo(y.BrandId));
            else if(filter.SortBy == "Price")
                filteredOrders.Sort((x,y) => x.Price.CompareTo(y.Price));
            else if(filter.SortBy == "StoreName")
                filteredOrders.Sort((x,y) => string.Compare(x.StoreName,y.StoreName));
            else if(filter.SortBy == "CustomerName")
                filteredOrders.Sort((x,y) => string.Compare(x.CustomerName,y.CustomerName));
            else if(filter.SortBy == "CreatedOn")
                filteredOrders.Sort((x,y) => x.CreatedOn.CompareTo(y.CreatedOn));
            else if(filter.SortBy == "Status")
                filteredOrders.Sort((x,y) => x.Status.CompareTo(y.Status));
            
            return Ok(filteredOrders);
        }
        
        catch (Exception e)
        {
            return StatusCode(500,e.Message);
        }
    }
}