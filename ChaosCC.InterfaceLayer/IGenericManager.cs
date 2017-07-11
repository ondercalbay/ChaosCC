using System.Collections.Generic;

namespace ChaosCC.InterfaceLayer
{
    public interface IGenericManager<Entity, ListDto, EditDto>
    {
        EditDto Add(EditDto editDto);

        EditDto Update(EditDto editDto);

        void Delete(int id);

        List<ListDto> Get(Entity filter);

        EditDto Get(int id);
    }
}
