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

    public IActionResult CreateComputer([FromForm] int id, [FromForm] string ram, [FromForm] string processor)
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

    public IActionResult UpdateComputer(int id, [FromForm] string ram, [FromForm] string processor)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }
        else
        {
            computer.Ram = ram;
            computer.Processor = processor;
            _context.SaveChanges();
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
            _context.Computers.Remove(computer);
            return Content("Computador deletado.");
        }
    }
}