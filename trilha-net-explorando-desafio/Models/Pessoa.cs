namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{   
    //Contrutor vazio
    public Pessoa() { }

    //Contrutores
    public Pessoa(string nome)
    {
        Nome = nome;
    }

    public Pessoa(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }

    //Declaração de propriedades
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
}