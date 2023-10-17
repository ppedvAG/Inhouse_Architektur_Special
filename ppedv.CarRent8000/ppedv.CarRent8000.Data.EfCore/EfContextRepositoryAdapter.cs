using ppedv.CarRent8000.Model.Contracts;
using ppedv.CarRent8000.Model.DomainModel;

namespace ppedv.CarRent8000.Data.EfCore
{
    public class EfContextRepositoryAdapter : IRepository
    {

        EfContext context;

        public EfContextRepositoryAdapter(string conString)
        {
            context = new EfContext(conString); 
        }

        public void Add<T>(T entity) where T : Entity
        {
            context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public void SaveAll()
        {
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            context.Set<T>().Update(entity);
        }
    }
}
