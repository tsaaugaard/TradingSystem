// from Building End-to-End Multi-Client Service Oriented Applications
// Plural Sight.com
// by Miguel Castro 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Core.Common.Core
{
    [DataContract]
    public class EntityBase: IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
