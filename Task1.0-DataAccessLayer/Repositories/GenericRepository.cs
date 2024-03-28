using Task1._0_DataAccessLayer.Abstract;
using Task1._0_DataAccessLayer.Concrete;

namespace Task1._0_DataAccessLayer.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    protected readonly Context _context;

    public GenericRepository(Context context) => _context = context;
    
    public void Insert(T t)
    {
        _context.Add(t);
        _context.SaveChanges();
    }

    public void Update(T t)
    {
        _context.Update(t);
        _context.SaveChanges();
    }

    public void Delete(T t)
    {
        _context.Remove(t);
        _context.SaveChanges();
    }

    public T GetByID(int ID)
    {
        return _context.Set<T>().Find(ID);
    }

    public List<T> GetList()
    {
        return _context.Set<T>().ToList();
    }
}