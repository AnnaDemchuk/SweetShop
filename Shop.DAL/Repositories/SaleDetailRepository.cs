using System.Data.Entity;


namespace Shop.DAL.Repositories
{
    using Shop.DAL.DbLayer;
    using Step.Repository.Common;

    public class SaleDetailRepository : GenericRepository<SaleDetail>
    {
        public SaleDetailRepository(DbContext context) : base(context)
        {
        }
    }
}
