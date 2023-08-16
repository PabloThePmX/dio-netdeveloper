namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        //Vai ser público apenas aquilo que é possível alterar em um smarthphone
        //visto que o modelo, imei, memoria serão sempre os mesmos no em um mesmo smartphone
        public string Numero { get; set; }
        private string Modelo { get; set; }
        private string IMEI { get; set; }
        private int Memoria { get; set; }          

        //Construtor, deverá ser declarado como base nas classes filhas, e nesta classes filhas
        //é possível alterar o valor das propriedades (porém so das propriedades publicas)
        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
        }

        public void Ligar()
        {
            Console.WriteLine("Ligando...");
        }

        public void ReceberLigacao()
        {
            Console.WriteLine("Recebendo ligação...");
        }

        public abstract void InstalarAplicativo(string nomeApp);
    }
}