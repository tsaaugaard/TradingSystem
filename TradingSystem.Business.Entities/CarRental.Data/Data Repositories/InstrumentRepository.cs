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
    [Export(typeof(IOrderRequestRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    class InstrumentRepository : DataRepositoryBase<Instrument>, IInstrumentRepository
    {
        protected override Instrument AddEntity(TradingSystemContext entityContext, Instrument entity)
        {
            throw new NotImplementedException();
        }

        protected override Instrument UpdateEntity(TradingSystemContext entityContext, Instrument entity)
        {
            throw new NotImplementedException();
        }
            
        protected override IEnumerable<Instrument> GetEntities(TradingSystemContext entityContext)
        {
            throw new NotImplementedException();
        }

        protected override Instrument GetEntity(TradingSystemContext entityContext, int id)
        {
            throw new NotImplementedException();
        }
    }
}
