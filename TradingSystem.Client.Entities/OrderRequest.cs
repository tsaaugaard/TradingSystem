using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Core;
using DomainModel.Model.TimeInForce;
using FluentValidation;

namespace TradingSystem.Client.Entities
{
    /// <summary>
    /// All members a considered Datamembers
    /// </summary>
    public class OrderRequest : ObjectBase
    {
        private double _volume;
        private double _price;
        private int _sideId;
        private double _yield;
        private int _orderTypeId;
        private int _orderRequestId;
        private TimeInForce _timeInForceId;
        private int _tradingSessionId;
        private int _orderRestrictionId;
        private int _echangeOrderId;
        private int _instrumentId;

        public int OrderRequestId
        {
            get { return _orderRequestId; }
            set
            {
                if (_orderRequestId != value)
                {
                    _orderRequestId = value;
                    OnPropertyChanged(() => OrderRequestId);
                }
            }
        }


        public double Volume
        {
            get { return _volume; }
            set
            {
                if (Math.Abs(_volume - value) > 0.01)
                {
                    _volume = value;
                    OnPropertyChanged(() => Volume);
                }
            }
        }


        public double Price
        {
            get { return _price; }
            set
            {
                if (Math.Abs(_price - value) > 0.000001)
                {
                    _price = value;
                    OnPropertyChanged(()=>Price);
                }
            }
        }


        public int SideId
        {
            get { return _sideId; }
            set
            {
                if (_sideId != value)
                {
                    _sideId = value;
                    OnPropertyChanged(()=>SideId);
                } 
            }
        }


        public double Yield
        {
            get { return _yield; }
            set
            {
                if (Math.Abs(_yield - value) > 0.000001)
                {
                    _yield = value;
                    OnPropertyChanged(()=>Yield);
                }
            }
        }


        public int InstrumentId
        {
            get { return _instrumentId; }
            set
            {
                if (_instrumentId != value)
                {
                    _instrumentId = value;
                    OnPropertyChanged(()=>InstrumentId);
                }
            }
        }


        public int OrderTypeId
        {
            get { return _orderTypeId; }
            set
            {
                if (_orderTypeId != value)
                {
                    _orderTypeId = value;
                    OnPropertyChanged(()=>OrderTypeId);
                }
            }
        }


        public TimeInForce TimeInForce
        {
            get { return _timeInForceId; }
            set
            {
                if (_timeInForceId != value)
                {
                    _timeInForceId = value;
                    OnPropertyChanged(()=>TimeInForce);
                }
            }
        }


        public int TradingSessionId
        {
            get { return _tradingSessionId; }
            set
            {
                if (_tradingSessionId != value)
                {
                    _tradingSessionId = value;
                    OnPropertyChanged(()=>TradingSessionId);
                }
            }
        }


        public int OrderRestrictionId
        {
            get { return _orderRestrictionId; }
            set
            {
                if (_orderRestrictionId != value)
                {
                    _orderRestrictionId = value; 
                    OnPropertyChanged(()=>OrderRestrictionId);
                }
            }
        }


        public int EchangeOrderId
        {
            get { return _echangeOrderId; }
            set
            {
                if (_echangeOrderId != value)
                {
                    _echangeOrderId = value;
                    OnPropertyChanged(() => EchangeOrderId);
                }
            }
        }
        
        class OrderRequestValidation : AbstractValidator<OrderRequest>
        {
            public OrderRequestValidation()
            {
                RuleFor(obj => obj.SideId).NotEmpty();
                RuleFor(obj => obj.Volume).NotEmpty();
                RuleFor(obj => obj.Volume).GreaterThan(0.0);
                RuleFor(obj => obj.TimeInForce).NotEmpty();

            }
        }

        protected override IValidator GetValidator()
        { 
            return new OrderRequestValidation();

        }
    }

    
    
}
