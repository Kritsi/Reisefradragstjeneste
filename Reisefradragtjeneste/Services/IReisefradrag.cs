using Reisefradragtjeneste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reisefradragtjeneste.Services
{
    public interface IReisefradrag
    {
        ReisefradagBelop BeregnReisefradrag(ReiseInfo reiseInfo);
    }
}
