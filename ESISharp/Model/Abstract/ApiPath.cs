using System;
using System.Collections.Generic;
using System.Text;

namespace ESISharp.Model.Abstract
{
    public abstract class ApiPath
    {
        protected EsiConnection EsiConnection;

        protected ApiPath(EsiConnection esiconnection) => EsiConnection = esiconnection;
    }
}
