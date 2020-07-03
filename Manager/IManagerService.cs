using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Manager
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IManagerService" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IManagerService
    {
        [OperationContract]
        void DoWork();

        //[OperationContract]

        //int Raddoppia(int n);
    }
}
