namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        //Contrutor vazio
        public Suite() { }

        //Contrutores
        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        //Declara��o de propriedades
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}