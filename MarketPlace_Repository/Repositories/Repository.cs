using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace_DAL;
using MarketPlace_Repository;

//Generic Repository Layer
namespace MarketPlace_Repository.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);
        void Insert(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        
        public Repository (DbContext context)
        {
            Context = context;
        }


        //Not being used
        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetByID(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity GetByProductName(string ProductName)
        {
            throw new NotImplementedException();

        }



        public void Insert(TEntity entity)
        {
          Context.Set<TEntity>().Add(entity);
        }
    }

}
