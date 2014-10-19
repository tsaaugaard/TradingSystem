using System;
using Core.Common.Core;

namespace TradingSystem.Business.Entities
{
    public class OrderType : EntityBase
    {
        private OrderTypeEnum _type;


        public OrderType(OrderTypeEnum type)
        {
            _type = type;
        }

        public String Name
        {
            get
            {
                switch (_type)
                {
                    case OrderTypeEnum.Market:
                        return "Market";
                    case OrderTypeEnum.Limit:
                        return "Limit";
                    case OrderTypeEnum.MarketWithLeftOvers:
                        return "Market With Left Overs As Limit";
                    default:
                        return "";
                }

            }
        }

        public enum OrderTypeEnum
        {
            None,
            Market,
            Limit,
            MarketWithLeftOvers
        }

        public bool IsMarket
        {
            get { return (_type == OrderTypeEnum.Market || _type == OrderTypeEnum.MarketWithLeftOvers); }
        }

        public bool IsLimit
        {
            get { return (_type == OrderTypeEnum.Limit); }
        }

        public static OrderType GetNullObject()
        {
            return new OrderType(OrderTypeEnum.None);
        }
    }



}
