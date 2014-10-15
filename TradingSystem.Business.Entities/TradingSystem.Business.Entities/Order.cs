using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Core;

namespace TradingSystem.Business.Entities
{
    [DataContract]
    public class Order : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public double Volume { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int SideId { get; set; }

        [DataMember]
        public double Yield { get; set; }

        [DataMember]
        public int InstrumentID { get; set; }

        [DataMember]
        public int OrderTypeId { get; set; } 

        [DataMember] 
        public int TimeInForceId { get; set; }

        [DataMember]
        public int TradingSessionId { get; set; }

        [DataMember]
        public int OrderRestrictionId { get; set; }

        public int EntityId
        {
            get { return OrderId; }
            set { OrderId = value; }
        }
    }

}
