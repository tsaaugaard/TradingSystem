using System.Runtime.Serialization;

namespace TradingSystem.Business.Entities.TimeInForce
{
    
    public interface IHasTradingSession
    {
        TradingSession Session { get; set; }
    }
}