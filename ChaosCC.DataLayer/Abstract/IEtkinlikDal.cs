using ChaosCC.Dto;
using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.DataLayer.Abstract
{
    public interface IEtkinlikDal : IGenericDal<Etkinlik>
    {
        List<DevamsizlikListDto> GetDevamsizlik(int etkinlikId);
    }
}
