namespace Valid.PesquisaBiometrica.Application.InputModels.Requests
{
    public class CidadaoUpdateRequest
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }
    }
}
