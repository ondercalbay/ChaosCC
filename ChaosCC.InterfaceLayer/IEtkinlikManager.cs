using ChaosCC.Dto;
using ChaosCC.Entity;
using System.Collections.Generic;

namespace ChaosCC.InterfaceLayer
{
    public interface IEtkinlikManager : IGenericManager<Etkinlik, EtkinlikListDto, EtkinlikEditDto>
    {
        DevamsizlikGridDto GetDevamsizlik(int etkinlikId);
        void SaveDevamsizlik(DevamsizlikGridDto model);
        void DevamsizlikDelete(int id);
        List<KullaniciEditDto> GetKullaniciWitOutEtkinlik(int id);
    }
}
