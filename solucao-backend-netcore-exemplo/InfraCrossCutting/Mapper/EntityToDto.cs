
using Domain.Entities;

using Valid.PesquisaBiometrica.Application.InputModels.Responses;

namespace InfraCrossCutting.Mapper
{
    public class EntityToDto : AutoMapper.Profile
    {
        public EntityToDto()
        {
            CreateMap<CidadaoEntity, CidadaoCreateResponse>();
            CreateMap<CidadaoEntity, CidadaoGetResponse>();
        }
    }
}
