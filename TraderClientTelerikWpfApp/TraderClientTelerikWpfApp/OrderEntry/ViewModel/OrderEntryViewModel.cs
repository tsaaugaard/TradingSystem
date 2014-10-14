using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DomainModel.Model;
using DomainModel.Model.OrderCapacity;
using DomainModel.Model.TimeInForce;
using Repositories.Repositories;
using TraderClientTelerikWpfApp.OrderEntry.ViewModel.Extensions;

namespace TraderClientTelerikWpfApp.OrderEntry.ViewModel
{
    public class OrderEntryViewModel : INotifyPropertyChanged

    {
        private Instrument _chosenInstrument = Instrument.GetNullObject();
        private OrderType _chosenOrderType = OrderType.GetNullObject();
        private ObservableCollection<Instrument> _instruments;
        private IInstrumetRepository _instrumetRepository;
        private bool _isYieldVisible;
        private ObservableCollection<OrderType> _orderTypes;
        private double _price;
        private bool _priceVisible;
        private TimeInForce _timeInForce;
        private ObservableCollection<TimeInForce> _timeInForces;
        private ObservableCollection<TradingSession> _tradingSessions;
        private int _volume;
        private ObservableCollection<OrderCapacity> _orderCapacities;
        private OrderCapacity _orderCapacity;

        public ObservableCollection<Instrument> Instruments
        {
            get
            {
                if (_instruments == null)
                {
                    _instruments = new ObservableCollection<Instrument>();
                    _instrumetRepository.GetAll();
                    foreach (Instrument instrument in _instrumetRepository.GetAll())
                    {
                        _instruments.Add(instrument);
                    }
                }

                return _instruments;
            }
        }

        public ObservableCollection<OrderType> OrderTypes
        {
            get
            {
                if (_orderTypes == null)
                {
                    _orderTypes = new ObservableCollection<OrderType>();
                    _orderTypes.Add(new OrderType(OrderType.OrderTypeEnum.Limit));
                    _orderTypes.Add(new OrderType(OrderType.OrderTypeEnum.Market));
                    _orderTypes.Add(new OrderType(OrderType.OrderTypeEnum.MarketWithLeftOvers));
                }
                return _orderTypes;
            }
        }

        public ObservableCollection<TimeInForce> TimeInForces
        {
            get
            {
                if (_timeInForces == null)
                {
                    _timeInForces = new ObservableCollection<TimeInForce>();
                    foreach (var timeInForce in TimeInForce.PosibleTimeInForce)
                    {
                        _timeInForces.Add(timeInForce);
                    }
                }
                return _timeInForces;
            }
        }

        public ObservableCollection<TradingSession> TradingSessions
        {
            get
            {
                if (_tradingSessions == null)
                {
                    _tradingSessions = new ObservableCollection<TradingSession>();
                    _tradingSessions.Add(new TradingSession(TradingSession.SessionTypeEnum.Auction));
                    _tradingSessions.Add(new TradingSession(TradingSession.SessionTypeEnum.ContinuesTradingPeriod));
                }

                return _tradingSessions;
            }
        }

        public OrderRestriction ChosenOrderRestriction
        {
            set { _orderCapacity.OrderRestriction = value; }
        }
        public ObservableCollection<OrderRestriction> OrderRestrictions
        {
            get
            {
                ObservableCollection<OrderRestriction> restrictions = new ObservableCollection<OrderRestriction>();
         
                if (_orderCapacity == null)
                    return restrictions;
      
                foreach (var restriction in _orderCapacity.PosibleRestrictions)
                {
                    restrictions.Add(restriction);
                }
                return restrictions;
            }
        }
        public OrderCapacity ChosenOrderCapacity
        {
            set
            {
                _orderCapacity = value;
                this.PropertyChanged.Notify(()=>this.OrderRestrictions);
            }
            
        }

        public ObservableCollection<OrderCapacity> OrderCapacities
        {
            get
            {
                if (_orderCapacities == null)
                {
                    _orderCapacities = new ObservableCollection<OrderCapacity>();
                    _orderCapacities.Add(new OrderCapacityAgency());
                    _orderCapacities.Add(new OrderCapacityPrincipal());
                    _orderCapacities.Add(new OrderCapacityRisklessPrincipal());
                }
                return _orderCapacities;
            }
        }


        /// <summary>
        ///     property of chosen time in force - might change visibility of ExpireDate. (time in force has 0..1 expiredate)
        /// </summary>
        public TimeInForce ChosenTimeInForce
        {
            get { return _timeInForce; }
            set
            {
                _timeInForce = value;
                PropertyChanged.Notify(() => IsExpireDateVisible);
                PropertyChanged.Notify(() => IsTradingSessionVisible);
            }
        }

        public bool IsTradingSessionVisible
        {
            get
            {
                if (ChosenTimeInForce == null)
                {
                    return false;
                }
                if (ChosenTimeInForce is IHasTradingSession)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsExpireDateVisible
        {
            get
            {
                if (ChosenTimeInForce == null)
                {
                    return false;
                }
                if (ChosenTimeInForce is IHasExpireDate)
                {
                    return true;
                }
                return false;
            }
        }

        public TradingSession ChosenTradingSession
        {
            set
            {
                if (ChosenTimeInForce != null && ChosenTimeInForce is IHasTradingSession)
                {
                    ((IHasTradingSession) ChosenTimeInForce).Session = value;
                }
            }
        }

        public DateTime ChosenExperieDate
        {
            set
            {
                if (ChosenTimeInForce != null && ChosenTimeInForce is IHasExpireDate)
                {
                    ((IHasExpireDate) ChosenTimeInForce).ExpireDate = value;
                }
            }
        }


        public Instrument ChosenInstrument
        {
            set
            {
                _chosenInstrument = value;
                SetVisiblityPriceAndYield();
            }
        }

        public OrderType ChosenOrderType
        {
            set
            {
                _chosenOrderType = value;
                SetVisiblityPriceAndYield();
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (Math.Abs(_price - value) > 0.00001)
                {
                    _price = value;

                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this,
                            new PropertyChangedEventArgs("Price"));
                    }
                }
            }
        }

        public int Volume
        {
            get { return _volume; }
            set
            {
                if (_volume != value)
                {
                    _volume = value;

                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this,
                            new PropertyChangedEventArgs("Volume"));
                    }
                }
            }
        }

        public bool IsPriceVisible
        {
            get { return _priceVisible; }
            set
            {
                _priceVisible = value;
                PropertyChanged.Notify(() => IsPriceVisible);
            }
        }

        public bool IsYieldVisible
        {
            get { return _isYieldVisible; }
            set
            {
                _isYieldVisible = value;
                PropertyChanged.Notify(() => IsYieldVisible);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Init(IInstrumetRepository instrumetRepository)
        {
            _instrumetRepository = instrumetRepository;
        }


        private void SetVisiblityPriceAndYield()
        {
            if (_chosenOrderType.IsLimit)
            {
                if (_chosenInstrument.IsQuatedOnPrice)
                {
                    IsYieldVisible = false;
                    IsPriceVisible = true;
                }
                else if (_chosenInstrument.IsQuatedOnYield)
                {
                    IsYieldVisible = true;
                    IsPriceVisible = false;
                }
                else
                {
                    IsYieldVisible = false;
                    IsPriceVisible = false;
                }
            }
            else
            {
                IsPriceVisible = false;
                IsYieldVisible = false;
            }
        }
    }
}