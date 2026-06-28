using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetLocation.Data;
using projetLocation.Models;

namespace projetLocation.Controllers;

public class ModelesController : Controller
{
    private readonly AppDbContext _context;

    public ModelesController(AppDbContext context)
    {
        _context = context;
    }

    // LISTE
    public IActionResult Index()
    {
        var modeles = _context.Modeles
            .Include(m => m.Marque)
            .ToList();

        return View(modeles);
    }

    // CREATE (GET)
    public IActionResult Create()
    {
        ViewBag.Marques = _context.Marques.ToList();
        return View();
    }

    // CREATE (POST)
    [HttpPost]
    public IActionResult Create(Modele modele)
    {
        // DEBUG (tu peux enlever après)
        Console.WriteLine("POST MODELE OK");

        if (string.IsNullOrWhiteSpace(modele.Nom) || modele.MarqueId == 0)
        {
            ViewBag.Marques = _context.Marques.ToList();
            return View(modele);
        }

        _context.Modeles.Add(modele);
        _context.SaveChanges();

        Console.WriteLine("MODELE AJOUTÉ");

        return RedirectToAction("Index");
    }
}