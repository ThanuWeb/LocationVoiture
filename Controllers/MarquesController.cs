using Microsoft.AspNetCore.Mvc;
using projetLocation.Data;
using projetLocation.Models;

namespace projetLocation.Controllers;

public class MarquesController : Controller
{
    private readonly AppDbContext _context;

    public MarquesController(AppDbContext context)
    {
        _context = context;
    }

    // LISTE
    public IActionResult Index()
    {
        var marques = _context.Marques.ToList();
        return View(marques);
    }

    // CREATE GET
    public IActionResult Create()
    {
        return View();
    }

    // CREATE POST
    [HttpPost]
    public IActionResult Create(Marque marque)
    {
        if (string.IsNullOrWhiteSpace(marque.Nom))
        {
            return View(marque);
        }

        _context.Marques.Add(marque);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // DELETE (option bonus mais utile prof)
    public IActionResult Delete(int id)
    {
        var marque = _context.Marques.Find(id);

        if (marque != null)
        {
            _context.Marques.Remove(marque);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}