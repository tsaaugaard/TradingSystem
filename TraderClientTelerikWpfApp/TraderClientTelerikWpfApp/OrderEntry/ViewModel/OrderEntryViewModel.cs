using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DomainModel.Model;
using Repositories.Repositories;
using TraderClientTelerikWpfApp.OrderEntry.ViewModel.Extensions;


namespace TraderClientTelerikWpfApp.OrderEntry.ViewModel
{
    public class OrderEntryViewModel : INotifyPropertyChanged

    {
        private ObservableCollection<Instrument> _instruments;
        private ObservableCollection<OrderType> _orderTypes;
        private double _price;
        private bool _priceVisible;
        private int _volume;
        private bool _isYieldVisible;
        private Instrument _chosenInstrument = Instrument.GetNullObject();
        private OrderType _chosenOrderType = OrderType.GetNullObject();
        private IInstrumetRepository _instrumetRepository;

        public OrderEntryViewModel()
        {
            
        }
        public void Init(IInstrumetRepository instrumetRepository)
        {
            _instrumetRepository = instrumetRepository;
        }

        public ObservableCollection<Instrument> Instruments
        {
            get
            {
                if (_instruments == null)
                {
                    _instruments = new ObservableCollection<Instrument>();
                    _instrumetRepository.GetAll();
                    foreach (var instrument in _instrumetRepository.GetAll())
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
                this.PropertyChanged.Notify(() => this.IsPriceVisible);

            }
        }

        public bool IsYieldVisible
        {
            get { return _isYieldVisible; }
            set
            {
                _isYieldVisible = value;
                this.PropertyChanged.Notify(() => this.IsYieldVisible);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


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
