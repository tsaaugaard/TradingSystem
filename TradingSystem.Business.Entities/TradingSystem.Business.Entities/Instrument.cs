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
    public class Instrument : EntityBase, IIdentifiableEntity 
    {
        [DataMember]
        public int InstrumentId { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Isin { get; set; }
        [DataMember]
        public QuotedInEnum QuotedIn { get; set; }

        
        public bool IsQuatedOnPrice
        {
            get { return (QuotedIn == QuotedInEnum.Price); }
        }

        public bool IsQuatedOnYield
        {
            get { return (QuotedIn == QuotedInEnum.Yield); }
        }

        [DataContract]
        public enum QuotedInEnum
        {
            [EnumMember]
            None,
            [EnumMember]
            Price,
            [EnumMember]
            Yield
        }
    
public int EntityId
{
	  get 
	{ 
		return InstrumentId; 
	}
	  set 
	{ 
		InstrumentId = value; 
	}
}
}
}
