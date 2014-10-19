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
    public class Account : EntityBase, IIdentifiableEntity
    {

        [DataMember]
        public int EntityId { get; set; }

        [DataMember]
        public string LoginEmail { get; set; }

    }
}
