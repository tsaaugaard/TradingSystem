namespace DomainModel.Model
{
    public class Instrument
    {

        public string InstrumentID { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Isin { get; set; }
        public QuotedInEnum QuotedIn { get; set; }

        public bool IsQuatedOnPrice
        {
            get { return (QuotedIn == QuotedInEnum.Price); }
        }

        public bool IsQuatedOnYield
        {
            get { return (QuotedIn == QuotedInEnum.Yield); }
        }

        public enum QuotedInEnum
        {
            None,
            Price,
            Yield
        }

        public static Instrument GetNullObject()
        {
            return new Instrument() {InstrumentID = "", Isin = "", Name = "", QuotedIn = QuotedInEnum.None, Symbol = ""};
        }
    }

    
}
