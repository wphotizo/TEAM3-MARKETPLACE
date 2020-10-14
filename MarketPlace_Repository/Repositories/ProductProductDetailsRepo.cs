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

    public class ProductProductDetailVM
    {
        //public ProductVM Products { get; set; }
        // public ProductDetailsVM ProductDetails { get; set; }

        public tblProduct Products { get; set; }

        public tblProductDetail ProductDetails { get; set; }
    }

    public interface IProductProductDetails : IRepository<ProductProductDetailVM>
    {

    }
    public class ProductProductDetailsRepo : Repository<ProductProductDetailVM>, IProductProductDetails
    {
        public ProductProductDetailsRepo(DbContext context) : base(context)
        {

        }
    }
}
