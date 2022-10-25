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

    public IActionResult CreateLab(int id, string nome, string setor)
    {
        Lab verificacao = _context.Labs.Find(id);

        if(verificacao == null)
        {
            var lab = new Lab(id, nome, setor);
            return Content("Novo laboratório criado.");
        }
        else
        {
            return Content("ID já existente.");
        }
    }

    public IActionResult UpdateLab(int id, string nome, string setor)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }
        else
        {
            //instrução para atualizar o computador a partir do id
            return Content("Laboratóro atualizado.");
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
            //instrução para deletar no banco de dados o laboratório a partir do id
            return Content("Laboratóro Deletado.");
        }
    }
}