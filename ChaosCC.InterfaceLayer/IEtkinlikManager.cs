using ChaosCC.Dto;
using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.InterfaceLayer
{
    public interface IEtkinlikManager : IGenericManager<Etkinlik, EtkinlikListDto, EtkinlikEditDto>
    {

    }
}
