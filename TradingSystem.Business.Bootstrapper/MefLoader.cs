using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using TradingSystem.Data;


namespace TradingSystem.Business.Bootstrapper
{
    public static class MefLoader
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(OrderRequestRepository).Assembly));

            CompositionContainer container = new CompositionContainer(catalog);
            
            return container;
        }
    }
}
