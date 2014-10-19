using System.Collections.Generic;
using Core.Common.Contracts;
using Core.Common;
using TradingSystem.Business.Entities;
namespace TradingSystem.Data.Contracts
{

    public interface IOrderRequestRepository : IDataRepository<OrderRequest>
    {
        // methods not in IDataRepository (other than standard CRUD)
       //  IEnumerable<OrderRequest> GetByType(OrderType.OrderTypeEnum type);

        IEnumerable<OrderRequest> GetByType(string type);
    }
}
