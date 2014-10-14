using System;
using System.Collections.Generic;

namespace DomainModel.Model.TimeInForce
{
    public class TimeInForce
    {
        private TimeINForceEnum _type;

        public virtual string Name {
            get { return ""; } }


        public static List<TimeInForce> PosibleTimeInForce 
        {
            get
            {
                List<TimeInForce> timeInForces = new List<TimeInForce>();
                timeInForces.Add(new TimeInForceDay());
                timeInForces.Add(new TimeInForceGTC());
                timeInForces.Add(new TimeInForceGTD());
                timeInForces.Add(new TimeInForceGTS());
                timeInForces.Add(new TimeInForceIOC());

                return timeInForces;
            }
        }

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
