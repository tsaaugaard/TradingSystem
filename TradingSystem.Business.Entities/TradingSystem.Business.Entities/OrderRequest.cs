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
    public class OrderRequest : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        int OrderRequestId { get; set; }

        [DataMember]
        public double Volume { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int SideId { get; set; }

        [DataMember]
        public double Yield { get; set; }

        [DataMember]
        public int InstrumentId { get; set; }

        [DataMember]
        public int OrderTypeId { get; set; }

        [DataMember]
        public int TimeInForceId { get; set; }

        [DataMember]
        public int TradingSessionId { get; set; }

        [DataMember]
        public int OrderRestrictionId { get; set; }

        [DataMember]
        public int EchangeOrderId { get; set; }


        public int EntityId
        {
            get { return OrderRequestId; }
            set { OrderRequestId = value; }
        }
    }
}
