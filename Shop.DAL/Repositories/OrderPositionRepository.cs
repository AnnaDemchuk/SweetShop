using System.Data.Entity;


namespace Shop.DAL.Repositories
{
    using Shop.DAL.DbLayer;
    using Step.Repository.Common;

    public class OrderPositionRepository : GenericRepository<OrderPosition>
    {
        public OrderPositionRepository(DbContext context) : base(context)
        {
        }
    }
}
