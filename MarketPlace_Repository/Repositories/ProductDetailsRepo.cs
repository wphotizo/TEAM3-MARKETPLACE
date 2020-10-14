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
    public interface IProductDetails : IRepository<tblProductDetail>
    {

    }
    public class ProductDetailsRepo : Repository<tblProductDetail>, IProductDetails
    {
        public ProductDetailsRepo(DbContext context) : base(context)
        {

        }
    }
}
