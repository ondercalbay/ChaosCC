using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.InterfaceLayer
{
    public interface Test<Entity, ListDto, EditDto>
    {
        EditDto Add(EditDto kullanici);

        EditDto Update(EditDto kullanici);

        void Delete(int id);

        List<ListDto> Get(Entity filter);

        EditDto Get(int id);
    }
}
