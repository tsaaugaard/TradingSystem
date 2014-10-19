using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using TradingSystem.Business.Entities;

namespace TradingSystem.Business.Contracts
{
    [ServiceContract]
    public interface IInstrumentService
    {
        [OperationContract]
        Instrument GetInstrument(int instrumentId);

        [OperationContract]
        Instrument[] GetAllInstruments();
    }
}
