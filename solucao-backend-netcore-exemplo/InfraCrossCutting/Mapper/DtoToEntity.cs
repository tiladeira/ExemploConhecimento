
using Domain.Entities;

using Valid.PesquisaBiometrica.Application.InputModels.Responses;

namespace InfraCrossCutting.Mapper
{
    public class DtoToEntity : AutoMapper.Profile
    {
        public DtoToEntity()
        {
            CreateMap<CidadaoCreateResponse, CidadaoEntity>();
            CreateMap<CidadaoGetResponse, CidadaoEntity>();
        }
    }
}
