namespace C42G02_project.BLL.Interfaces
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {
        //We create a generic interface that encapsulates the general methods that both class employee and department do
        int Create(TEntity entity);
        int Delete(TEntity entity);
        TEntity? Get(int id);
        IEnumerable<TEntity> GetAll();
        int Update(TEntity entity);
    }
}
