using System.Collections.Generic;

namespace ChaosCC.DataLayer.Abstract
{
    public interface IGenericDal<Entity> where Entity:class,new()
    {
        Entity Add(Entity ent);

        Entity Update(Entity ent);

        List<Entity> Get(Entity filter);

        Entity Get(int id);

        void Delete(int id);
    }
}
