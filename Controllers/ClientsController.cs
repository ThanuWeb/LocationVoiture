using Microsoft.AspNetCore.Mvc;
using projetLocation.Data;
using projetLocation.Models;

namespace projetLocation.Controllers;

public class ClientsController : Controller
{
    private readonly AppDbContext _context;

    public ClientsController(AppDbContext context)
    {
        _context = context;
    }

    // LISTE
    public IActionResult Index()
    {
        var clients = _context.Clients.ToList();
        return View(clients);
    }

    // CREATE GET
    public IActionResult Create()
    {
        return View();
    }

    // CREATE POST
    [HttpPost]
    public IActionResult Create(Client client)
    {
        if (string.IsNullOrWhiteSpace(client.Nom))
        {
            return View(client);
        }

        _context.Clients.Add(client);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // DELETE
    public IActionResult Delete(int id)
    {
        var client = _context.Clients.Find(id);

        if (client != null)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}