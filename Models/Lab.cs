namespace MvcLabManager.Models;

public class Lab 
{   
    public int Id { get; set; }
    public List<Computer> Computers { get; set; }

    public Lab() {}

    public Lab(int id, Computer computer) 
    {
        Id = id;
        Computers.add(computer);
    }

    public void AddComputer(Computer computer)
    {
        Computers.add(computer);
    }
}