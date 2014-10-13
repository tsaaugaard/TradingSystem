using System.Collections.Generic;
using DomainModel.Model;

namespace Repositories.Repositories
{
    public class InstrumetRepository : IInstrumetRepository
    {
        public List<Instrument> GetAll()
        {
           // real connection to service or ORM or database 
            return null;
        }
    }
}
