using System;

namespace DomainModel.Model.TimeInForce
{
    public interface IHasExpireDate
    {
        DateTime ExpireDate { get; set; }
    }
}