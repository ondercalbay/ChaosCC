using ChaosCC.Dto;
using ChaosCC.Entity;
using System.Collections.Generic;

namespace ChaosCC.InterfaceLayer
{
    public interface IModelManager : IGenericManager<Model, ModelListDto, ModelEditDto>
    {
        List<ModelListDto> GetListByMarkaId(int markaId);
    }
}
