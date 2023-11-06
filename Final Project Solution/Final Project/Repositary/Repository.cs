
using Final_Project.Models.DataContext;


namespace Final_Project.Repositary
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DataContext db { get; set; }

        public Repository(DataContext _db)
        {
            db = _db;
        }
       
        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList() ;
        }

        public TEntity GetByID(int Id)
        {
            return db.Set<TEntity>().Find(Id);
        }
        public TEntity GetByIDstring(string Id)
        {
            return db.Set<TEntity>().Find(Id);
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void Delete(int Id)
        {
            var entity = db.Set<TEntity>().Find(Id);
            if (entity != null)
                db.Set<TEntity>().Remove(entity);
        }
        public virtual void Update(int Id, TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
        }
        public void Save()
        {
            db.SaveChanges();
        }
      


      

    }
}
