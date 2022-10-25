using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class ComputerController : Controller
{
    private readonly LabManagerContext _context;

    public ComputerController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Computers);
    }

    public IActionResult Show(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        return View(computer);
    }

    public IActionResult CreateComputer(int id, string ram, string processor)
    {
        Computer verificacao = _context.Computers.Find(id);

        if(verificacao == null)
        {
            var computer = new Computer(id, ram, processor);
            return View(computer);
        }
        else
        {
            return Content("ID já existente.");
        }
    }

    public IActionResult UpdateComputer(int id, string ram, string processor)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }
        else
        {
            //instrução para atualizar os dados de ram e processador do computador a partir do id
            return View(computer);
        }
    }

    public IActionResult DeleteComputer(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }
        else
        {
            //instrução para deletar no banco de dados o computador a partir do id
            return Content("Computador deletado.");
        }
    }
}