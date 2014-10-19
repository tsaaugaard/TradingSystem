using System;
using System.Runtime.Serialization;

namespace TradingSystem.Business.Entities.TimeInForce
{
    [DataContract]
    public class TradingSession
    {
        public enum SessionTypeEnum
        {
            Auction,
            ContinuesTradingPeriod
        }

        private SessionTypeEnum _type;


        public TradingSession(SessionTypeEnum type)
        {
            _type = type;
        }

        public String Name
        {
            get
            {
                switch (_type)
                {
                    case SessionTypeEnum.Auction:
                        return "Auction";
                    case SessionTypeEnum.ContinuesTradingPeriod:
                        return "Continoues Trading Periode";
                    default:
                        return "";
                }
                
            }
        }
    }
}