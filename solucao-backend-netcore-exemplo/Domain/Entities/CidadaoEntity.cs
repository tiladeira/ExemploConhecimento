using Domain.Entities.Base;

namespace Domain.Entities
{
    public class CidadaoEntity : BaseEntity
    {
        public CidadaoEntity()
        {

        }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }
    }
}
