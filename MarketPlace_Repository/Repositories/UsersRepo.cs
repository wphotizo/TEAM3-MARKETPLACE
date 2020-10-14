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
    public interface IUser : IRepository<tblUser>
    {

    }
    public class UsersRepo : Repository<tblUser>, IUser
    {
    public UsersRepo(DbContext context) : base(context)
        {

        }
    }
}
