using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetLocation.Data;
using projetLocation.Models;

namespace projetLocation.Controllers;

public class VoituresController : Controller
{
    private readonly AppDbContext _context;

    public VoituresController(AppDbContext context)
    {
        _context = context;
    }

    // LISTE
    public IActionResult Index()
    {
        var voitures = _context.Voitures
            .Include(v => v.Modele)
            .ThenInclude(m => m.Marque)
            .ToList();

        return View(voitures);
    }

    // DETAILS
    public IActionResult Details(int id)
    {
        var voiture = _context.Voitures
            .Include(v => v.Modele)
            .ThenInclude(m => m.Marque)
            .FirstOrDefault(v => v.Id == id);

        if (voiture == null)
            return NotFound();

        return View(voiture);
    }

    // CREATE GET
    public IActionResult Create()
    {
        ViewBag.Modeles = _context.Modeles.ToList();
        return View();
    }

    // CREATE POST
    [HttpPost]
    public IActionResult Create(Voiture voiture)
    {
        _context.Voitures.Add(voiture);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // EDIT GET
    public IActionResult Edit(int id)
    {
        var voiture = _context.Voitures.Find(id);

        if (voiture == null)
            return NotFound();

        ViewBag.Modeles = _context.Modeles.ToList();
        return View(voiture);
    }

    // EDIT POST
    [HttpPost]
    public IActionResult Edit(Voiture voiture)
    {
        _context.Voitures.Update(voiture);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // DELETE
    public IActionResult Delete(int id)
    {
        var voiture = _context.Voitures.Find(id);

        if (voiture != null)
        {
            _context.Voitures.Remove(voiture);
            _context.SaveChanges();
        }

        return RedirectToAction(nameof(Index));
    }
}