using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using System.ComponentModel.Composition;
using Core.Common.Core;
using Core.Common.Exceptions;
using TradingSystem.Business.Contracts;
using TradingSystem.Business.Entities;
using TradingSystem.Data.Contracts;
using System.Threading.Tasks;

namespace TradingSystem.Business.Managers
{
    // each call gets its own thread, and they can run in parallel.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
    ConcurrencyMode  = ConcurrencyMode.Multiple,
    ReleaseServiceInstanceOnTransactionComplete = false)]
    public class InstrumentManager : ManagerBase, IInstrumentService
    {

        /// <summary>
        /// constructor for unit testing - injecting IDataRepositoryFactory
        /// </summary>
        /// <param name="dataRepositoryFactory"></param>
        public InstrumentManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        [Import] private IDataRepositoryFactory _dataRepositoryFactory;

        public Instrument GetInstrument(int instrumentId)
        {

            return ExecuteFaultHandledOperation(() =>
            {
                IInstrumentRepository instrumentRepository
                    = _dataRepositoryFactory.GetDataRepository<IInstrumentRepository>();

                Instrument instrumentEntity = instrumentRepository.Get(instrumentId);

                if (instrumentEntity == null)
                {
                    NotFoundException ex =
                        new NotFoundException(
                            string.Format("Instrument with ID of {0} is not found", instrumentId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
                return instrumentEntity;
            });
        }

        public Instrument[] GetAllInstruments()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IInstrumentRepository instrumentRepository
                    = _dataRepositoryFactory.GetDataRepository<IInstrumentRepository>();

                IEnumerable<Instrument> instruments = instrumentRepository.Get();

                return instruments.ToArray();
            });

        }
    }
}