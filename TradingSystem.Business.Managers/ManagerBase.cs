using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Core;
using System.ComponentModel.Composition;
namespace TradingSystem.Business.Managers
{
    public class ManagerBase
    {
        public ManagerBase()
        {
            if (ObjectBase.Container != null)
            {
                ObjectBase.Container.SatisfyImportsOnce(this);
            }
        }


        protected T ExecuteFaultHandledOperation<T>(Func<T> codetoExecute)
        {
            try
            {
                return codetoExecute.Invoke();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
