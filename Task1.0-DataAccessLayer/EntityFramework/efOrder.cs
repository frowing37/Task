using Task1._0_DataAccessLayer.Abstract;
using Task1._0_DataAccessLayer.Concrete;
using Task1._0_DataAccessLayer.Repositories;
using Task1._0_EntityLayer.Concrete;

namespace Task1._0_DataAccessLayer.EntityFramework;

public class efOrder : GenericRepository<Order>, IOrderDal
{
    public efOrder(Context context) : base(context) { }
}