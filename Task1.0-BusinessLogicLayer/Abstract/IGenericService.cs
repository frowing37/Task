namespace Task1._0_BusinessLogicLayer.Abstract;

public interface IGenericService<T> where T : class
{
    void AddwS(T t);
    void UpdatewS(T t);
    void DeletewS(T t);
    T GetByIDwS(int ID);
    List<T> GetListwS();
}