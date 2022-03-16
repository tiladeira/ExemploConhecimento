using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valid.PesquisaBiometrica.Application.InputModels.Responses
{
    public class CidadaoGetResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }
    }
}
