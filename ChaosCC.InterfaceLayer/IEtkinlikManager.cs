using ChaosCC.Dto;
using ChaosCC.Entity;
using System.Collections.Generic;

namespace ChaosCC.InterfaceLayer
{
    public interface IEtkinlikManager : IGenericManager<Etkinlik, EtkinlikListDto, EtkinlikEditDto>
    {
        List<DevamsizlikListDto> GetDevamsizlik(int etkinlikId);
    }
}
