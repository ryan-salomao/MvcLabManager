using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class LabController : Controller
{
    private readonly LabManagerContext _context;

    public LabController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Labs);
    }

    public IActionResult Show(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        return View(lab);
    }

    public IActionResult CreateLab([FromForm] int id, [FromForm] string nome, [FromForm] string setor)
    {
        Lab verificacao = _context.Labs.Find(id);

        if(verificacao == null)
        {
            var lab = new Lab(id, nome, setor);
            return View(lab);
        }
        else
        {
            return Content("ID já existente.");
        }
    }

    public IActionResult UpdateLab(int id, [FromForm] string nome, [FromForm] string setor)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }
        else
        {
            lab.Nome = nome;
            lab.Setor = setor;
            _context.SaveChanges();
            return View(lab);
        }
    }

    public IActionResult DeleteLab(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }
        else
        {
            _context.Labs.Remove(lab);
            return Content("Laboratóro Deletado.");
        }
    }
}