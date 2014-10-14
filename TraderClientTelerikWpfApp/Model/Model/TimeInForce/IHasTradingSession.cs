namespace DomainModel.Model.TimeInForce
{
    public interface IHasTradingSession
    {
        TradingSession Session { get; set; }
    }
}