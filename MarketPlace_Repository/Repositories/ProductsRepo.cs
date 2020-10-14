using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MarketPlace_DAL;
using MarketPlace_Repository;

namespace MarketPlace_Repository.Repositories
{
    public interface IProducts : IRepository<tblProduct>
    {

    }
    public class ProductsRepo : Repository<tblProduct>, IProducts
    {
        public ProductsRepo(DbContext context) : base(context)
        {

        }
    }
}
