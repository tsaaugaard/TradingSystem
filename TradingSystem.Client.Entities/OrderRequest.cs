using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TradingSystem.Client.Entities
{
    /// <summary>
    /// All members a considered Datamembers
    /// </summary>
    public class OrderRequest
    {
        private double _volume;
        private double _price;
        private int _sideId;
        private double _yield;
        private int _orderTypeId;
        private int _orderRequestId;
        private int _timeInForceId;
        private int _tradingSessionId;
        private int _orderRestrictionId;
        private int _echangeOrderId;
        private int _instrumentId;

        public int OrderRequestId
        {
            get { return _orderRequestId; }
            set { _orderRequestId = value; }
        }


        public double Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }


        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }


        public int SideId
        {
            get { return _sideId; }
            set { _sideId = value; }
        }


        public double Yield
        {
            get { return _yield; }
            set { _yield = value; }
        }


        public int InstrumentId
        {
            get { return _instrumentId; }
            set { _instrumentId = value; }
        }


        public int OrderTypeId
        {
            get { return _orderTypeId; }
            set { _orderTypeId = value; }
        }


        public int TimeInForceId
        {
            get { return _timeInForceId; }
            set { _timeInForceId = value; }
        }


        public int TradingSessionId
        {
            get { return _tradingSessionId; }
            set { _tradingSessionId = value; }
        }


        public int OrderRestrictionId
        {
            get { return _orderRestrictionId; }
            set { _orderRestrictionId = value; }
        }


        public int EchangeOrderId
        {
            get { return _echangeOrderId; }
            set { _echangeOrderId = value; }
        }
    }
}
