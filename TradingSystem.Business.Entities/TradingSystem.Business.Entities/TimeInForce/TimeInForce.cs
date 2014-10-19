using System;
using System.Runtime.Serialization;
using DomainModel.Model.TimeInForce;

namespace TradingSystem.Business.Entities.TimeInForce
{
    [DataContract]
    public class TimeInForce
    {
        private TimeINForceEnum _type;

        public virtual string Name {
            get { return ""; } }

        public enum TimeINForceEnum
        {
            Day,
            GTD,
            GTS,
            IOC,
            GTC
        }
    }

    public class TimeInForceDay : TimeInForce
    {
        private static TimeINForceEnum _type = TimeINForceEnum.Day;
        public override string Name
        {
            get { return "Day order (day)"; }
        }
    }
    public class TimeInForceGTD : TimeInForce, IHasExpireDate
    {
        private static TimeINForceEnum _type = TimeINForceEnum.GTD;
        public override string Name
        {
            get { return "Good till date (GTD)"; }
        }
        public DateTime ExpireDate { get; set; }
            
    }
    public class TimeInForceIOC : TimeInForce
    {
        private static TimeINForceEnum _type = TimeINForceEnum.IOC;
        public override string Name
        {
            get { return "Immediate or cancel (IOC)"; }
        }
    }
    public class TimeInForceGTC : TimeInForce
    {
        private static TimeINForceEnum _type = TimeINForceEnum.GTC;
        public override string Name
        {
            get { return "Good till Cancelled (GTC)"; }
        }
    }
    public class TimeInForceGTS : TimeInForce, IHasTradingSession
    {
        private static TimeINForceEnum _type = TimeINForceEnum.GTS;
        public TradingSession Session { get; set; }
        public override string Name
        {
            get { return "Good till Session (GTS)"; }
        }
    }


}
