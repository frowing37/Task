namespace Task1._0_DataAccessLayer.Abstract;

public interface IGenericDal<T> where T : class
{
    void Insert(T t);
    void Update(T t);
    void Delete(T t);
    T GetByID(int ID);
    List<T> GetList();

}