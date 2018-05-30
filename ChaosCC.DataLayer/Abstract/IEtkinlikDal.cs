using ChaosCC.Dto;
using ChaosCC.Entity;
using System.Collections.Generic;

namespace ChaosCC.DataLayer.Abstract
{
    public interface IEtkinlikDal : IGenericDal<Etkinlik>
    {
        List<DevamsizlikListDto> GetDevamsizlikWithEtkinlikId(int etkinlikId);
        Devamsizlik AddDevamsizlik(Devamsizlik ent);

        Devamsizlik UpdateDevamsizlik(Devamsizlik ent);
    }
}
