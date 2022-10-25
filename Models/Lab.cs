namespace MvcLabManager.Models;

public class Lab 
{   
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Setor { get; set; }

    public Lab() {}

    public Lab(int id, string nome, string setor) 
    {
        Id = id;
        Nome = nome;
        Setor = setor;
    }
}