using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace_Repository.Repositories;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using MarketPlace_DAL;

namespace MarketPlace_Repository
{
    public class UnitOfWork : IDisposable
    {
        DbContext Context;
        public IUser user;
        public IProducts products;
        public IProductDetails productdetails;
        public IProductProductDetails productsproductdetails;
        public UnitOfWork(DbContext context)
        {

            this.Context = context;
            user = new UsersRepo(Context);
            products = new ProductsRepo(Context);
            productdetails = new ProductDetailsRepo(Context);
            productsproductdetails = new ProductProductDetailsRepo(Context);

        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
             Context.Dispose();
        }
    }
}
