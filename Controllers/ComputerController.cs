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
}