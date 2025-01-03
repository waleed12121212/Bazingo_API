﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Domain_Logic.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IReviewRepository Reviews { get; }
        IComplaintRepository Complaints { get; }
        ICartRepository Cart { get; }
        IAuctionRepository Auctions { get; }
        IPaymentRepository Payments { get; }
        Task<int> CompleteAsync( );
    }
}