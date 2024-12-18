using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Interfaces
{
    public interface IRepositoryFactory
    {
        IGenericRepository<T> GetRepository<T>( ) where T : class;
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        ICategoryRepository Categories { get; }
        IReviewRepository Reviews { get; }
        IAuctionRepository Auctions { get; }
    }
}
