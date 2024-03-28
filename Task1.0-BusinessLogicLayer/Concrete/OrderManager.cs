using Task1._0_BusinessLogicLayer.Abstract;
using Task1._0_DataAccessLayer.Abstract;
using Task1._0_EntityLayer.Concrete;

namespace Task1._0_BusinessLogicLayer.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;

    public OrderManager(IOrderDal orderDal) => _orderDal = orderDal;
    
    public void AddwS(Order t)
    {
        _orderDal.Insert(t);
    }

    public void UpdatewS(Order t)
    {
        _orderDal.Update(t);
    }

    public void DeletewS(Order t)
    {
        _orderDal.Delete(t);
    }

    public Order GetByIDwS(int ID)
    {
        return _orderDal.GetByID(ID);
    }

    public List<Order> GetListwS()
    {
        return _orderDal.GetList();
    }
}