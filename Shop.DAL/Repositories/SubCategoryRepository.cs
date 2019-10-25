using Shop.DAL.DbLayer;
using Step.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Repositories
{
    public class SubCategoryRepository : GenericRepository<SubCategory>
    {
        public SubCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
