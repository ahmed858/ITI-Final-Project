namespace Final_Project.Repositary
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int Id);
        void Add(TEntity entity );
        void Delete(int Id);
        void Update(int Id,TEntity entity);
        void Save();
        //unitofwork  
        //data access layer
        //presention  layer view
        //bu
    }
}
