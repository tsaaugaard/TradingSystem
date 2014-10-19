using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TradingSystem.Business.Entities.Capacity
{
    [DataContract]
    public class OrderCapacity
    {
        public OrderRestriction OrderRestriction { get; set; }
        
        public virtual string Name
        {
            get { return ""; }
        }

        // legal Restrictions for this Capacity
        public virtual List<OrderRestriction> PosibleRestrictions
        {
            get { return null; }
        }
    }

    [DataContract]
    public class OrderCapacityPrincipal : OrderCapacity
    {
        public override string Name
        {
            get { return "Principal"; }
        }

        public override List<OrderRestriction> PosibleRestrictions
        {
            get
            {
                List<OrderRestriction> restrictions = new List<OrderRestriction>();
                restrictions.Add(new OrderRestrictionNullObject());
                restrictions.Add(new OrderRestrictionIssuePrice());
                restrictions.Add(new OrderRestrictionActingAsMarketMaker());
                return restrictions;
            }
        }
    }

    [DataContract]
    public class OrderCapacityAgency : OrderCapacity
    {
        public override string Name
        {
            get { return "Agency"; }
        }

        public override List<OrderRestriction> PosibleRestrictions
        {
            get
            {
                List<OrderRestriction> restrictions = new List<OrderRestriction>();
                restrictions.Add(new OrderRestrictionNullObject());
                restrictions.Add(new OrderRestrictionIssuerHolding());
                return restrictions;
            }
        }
    }

    [DataContract]
    public class OrderCapacityRisklessPrincipal  : OrderCapacity
    {
        public override string Name
        {
            get { return "Riskless Principal"; }
        }

        public override List<OrderRestriction> PosibleRestrictions
        {
            get
            {
                List<OrderRestriction> restrictions = new List<OrderRestriction>();
                return restrictions;
            }
        }
    }
    
    [DataContract]
    public class OrderRestriction
    {
        public virtual string Name
        {
            get { return ""; }
        }
    }


    [DataContract]
    public class OrderRestrictionIssuerHolding : OrderRestriction
    {
        public override string Name
        {
            get { return " Issuer Holding"; }
        }
    }

    [DataContract]
    public class OrderRestrictionIssuePrice : OrderRestriction
    {
        public override string Name
        {
            get { return "Issue Price Stabilization"; }
        }
    }
    
    [DataContract]
    public class OrderRestrictionActingAsMarketMaker : OrderRestriction
    {
        public override string Name
        {
            get { return "Acting as Market Maker or Specialist in the security "; }
        }
    }
    [DataContract]
    public class OrderRestrictionNullObject : OrderRestriction
    {
        public override string Name
        {
            get { return ""; }
        }
    }

}
