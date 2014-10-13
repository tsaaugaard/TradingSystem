using System.Collections.Generic;
using DomainModel.Model;

namespace Repositories.Repositories
{
    public interface IInstrumetRepository
    {
        List<Instrument> GetAll();
    }
}
