using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.Serialization;

using System.Text;
using System.Threading.Tasks;
using DomainModel.Model;
using TradingSystem.Business.Entities;
using TradingSystem.Data.Contracts;

namespace TradingSystem.Data
{
    [Export (typeof(IOrderRequestRepository)) ]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrderRequestRepository : DataRepositoryBase<OrderRequest>, IOrderRequestRepository
    {
        protected override OrderRequest AddEntity(TradingSystemContext entityContext, OrderRequest entity)
        {
            return entityContext.OrderRequestSet.Add(entity);
        }

        protected override OrderRequest UpdateEntity(TradingSystemContext entityContext, OrderRequest entity)
        {
            return (from e in entityContext.OrderRequestSet
                where e.OrderRequestId == entity.OrderRequestId
                select e).FirstOrDefault();
        }

        protected override IEnumerable<OrderRequest> GetEntities(TradingSystemContext entityContext)
        {
            return from e in entityContext.OrderRequestSet
                select e;
        }

        protected override OrderRequest GetEntity(TradingSystemContext entityContext, int id)
        {
            var query = (from e in entityContext.OrderRequestSet
                where e.AccountId == id
                select e);

            var results = query.FirstOrDefault();

            return results;
        }

      //  public IEnumerable<OrderRequest> GetByType(OrderType.OrderTypeEnum type)
        public IEnumerable<OrderRequest> GetByType(string type)
        {
            throw new NotImplementedException();
        }
    }
}
