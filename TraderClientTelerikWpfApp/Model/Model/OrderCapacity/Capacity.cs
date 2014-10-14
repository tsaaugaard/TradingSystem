using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Model.OrderCapacity
{
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

    public class OrderRestriction
    {
        public virtual string Name
        {
            get { return ""; }
        }
    }

   

    public class OrderRestrictionIssuerHolding : OrderRestriction
    {
        public override string Name
        {
            get { return " Issuer Holding"; }
        }
    }

    public class OrderRestrictionIssuePrice : OrderRestriction
    {
        public override string Name
        {
            get { return "Issue Price Stabilization"; }
        }
    }

    public class OrderRestrictionActingAsMarketMaker : OrderRestriction
    {
        public override string Name
        {
            get { return "Acting as Market Maker or Specialist in the security "; }
        }
    }
    public class OrderRestrictionNullObject : OrderRestriction
    {
        public override string Name
        {
            get { return ""; }
        }
    }

}
