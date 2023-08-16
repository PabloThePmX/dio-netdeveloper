namespace DesafioPOO.Models
{
    public class Nokia : Smartphone
    {
        //Construtor herdado
        public Nokia(string numero, string modelo, string imei, int memoria): base(numero, modelo, imei, memoria) { }

        //Método sobrescrito
        public override void InstalarAplicativo(string nomeApp)
        {
            Console.WriteLine($"O aplicativo {nomeApp} foi instalado com sucesso!");
        }
    }
}