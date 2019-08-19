using System.ComponentModel.DataAnnotations;

namespace ChaosCC.Entity
{
    public static class Enumlar
    {
        public enum EnuAidatDurum
        {
            Odenmedi = 0,
            Odendi = 1,
            Donduruldu = 2
        }
        public enum EnuKanGrup
        {
            [Display(Name = "-")]
            Seciniz = 0,

            [Display(Name = "A Rh(+)")]
            APozitif = 1,

            [Display(Name = "A Rh(-)")]
            ANegatif = 2,

            [Display(Name = "B Rh(+)")]
            BPozitif = 3,

            [Display(Name = "B Rh(-)")]
            BNegatif = 4,

            [Display(Name = "AB Rh(+)")]
            ABPozitif = 5,

            [Display(Name = "AB Rh(-)")]
            ABNegatif = 6,

            [Display(Name = "0 Rh(+)")]
            SifirPozitif = 7,

            [Display(Name = "0 Rh(-)")]
            SifirNegatif = 8,
        }

        public enum EnuVoyegerRozet
        {
            [Display(Name = "Voyager 1")]
            Voyoger1 = 1,

            [Display(Name = "Voyager 2")]
            Voyoger2 = 2,

            [Display(Name = "Voyager 3")]
            Voyoger3 = 3,

            [Display(Name = "Voyager Captaion")]
            VoyogerCaptain = 4
        }

        public enum EnuEtkinlikTuru
        {
            [Display(Name = "Cuma Toplantısı")]
            CumaToplantisi = 1,
            [Display(Name = "Önemli Gün")]
            OnemliGun = 2,
            [Display(Name = "Eğitim")]
            Egitim = 3,
            [Display(Name = "Sürüş")]
            Sürüş = 4
        }
        public enum EnuRutbe
        {
            [Display(Name = "HangAround")]
            HangAround = 1,

            [Display(Name = "HangAround 1")]
            HangAround1 = 2,

            [Display(Name = "HangAround 2")]
            HangAround2 = 3,

            [Display(Name = "HangAround 3")]
            HangAround3 = 4,

            [Display(Name = "Prospect")]
            Prospect = 5,

            [Display(Name = "Member")]
            Member = 6,

            [Display(Name = "Senior Member")]
            SeniorMember = 7
        }
        public enum EnuHareketTuru
        {
            [Display(Name = "Cıktı")]
            Cikti = 0,
            [Display(Name = "Girdi")]
            Girdi = 1
        }

        public enum EnuRol
        {
            [Display(Name = "Admin")]
            Admin = 0,
            [Display(Name = "Üye")]
            Uye = 1
        }

        public enum EnuTarihAralik
        {
            [Display(Name = "Son 3 Ay")]
            Son3Ay = 0,
            [Display(Name = "Son 6 Ay")]
            Son6Ay = 1,
            [Display(Name = "Bu Sene")]
            BuSune = 2,
            [Display(Name = "Son 1 Sene")]
            Son1Sene = 3,
            [Display(Name = "Tümü")]
            Tümü = 4
        }

        public enum EnuDuyuruTipi
        {
            Karar = 1,
            Duyuru = 2,
            Bilgilendirme = 3
        }
    }
}
