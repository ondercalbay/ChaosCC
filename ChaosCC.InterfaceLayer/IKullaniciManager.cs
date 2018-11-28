using ChaosCC.Dto;
using ChaosCC.Entity;

namespace ChaosCC.InterfaceLayer
{
    public interface IKullaniciManager : IGenericManager<Kullanici, KullaniciListDto, KullaniciEditDto>
    {
        KullaniciSessionDto Authenticate(KullaniciLoginDto kullanici);
     }
}
