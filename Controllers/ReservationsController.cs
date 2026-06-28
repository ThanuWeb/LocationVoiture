using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetLocation.Data;
using projetLocation.Models;

namespace projetLocation.Controllers;

public class ReservationsController : Controller
{
    private readonly AppDbContext _context;

    public ReservationsController(AppDbContext context)
    {
        _context = context;
    }

    // LISTE
    public IActionResult Index()
    {
        var reservations = _context.Reservations
            .Include(r => r.Client)
            .Include(r => r.Voiture)
                .ThenInclude(v => v.Modele)
                    .ThenInclude(m => m.Marque)
            .ToList();

        return View(reservations);
    }

    // CREATE GET
    public IActionResult Create()
    {
        ViewBag.Clients = _context.Clients.ToList();

        ViewBag.Voitures = _context.Voitures
            .Include(v => v.Modele)
                .ThenInclude(m => m.Marque)
            .ToList();

        return View();
    }

    // CREATE POST
    [HttpPost]
    public IActionResult Create(Reservation reservation)
    {
        if (reservation.ClientId == null)
            ModelState.AddModelError("", "Client obligatoire");

        if (reservation.VoitureId == null)
            ModelState.AddModelError("", "Voiture obligatoire");

        if (reservation.DateDebut == null)
            ModelState.AddModelError("", "Date début obligatoire");

        if (reservation.DateFin == null)
            ModelState.AddModelError("", "Date fin obligatoire");

        if (reservation.DateDebut != null && reservation.DateFin != null &&
            reservation.DateFin < reservation.DateDebut)
        {
            ModelState.AddModelError("", "Date fin invalide");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Clients = _context.Clients.ToList();
            ViewBag.Voitures = _context.Voitures
                .Include(v => v.Modele)
                    .ThenInclude(m => m.Marque)
                .ToList();

            return View(reservation);
        }

        _context.Reservations.Add(reservation);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // EDIT GET
    public IActionResult Edit(int id)
    {
        var reservation = _context.Reservations.Find(id);

        if (reservation == null)
            return RedirectToAction("Index");

        ViewBag.Clients = _context.Clients.ToList();

        ViewBag.Voitures = _context.Voitures
            .Include(v => v.Modele)
                .ThenInclude(m => m.Marque)
            .ToList();

        return View(reservation);
    }

    // EDIT POST
    [HttpPost]
    public IActionResult Edit(Reservation reservation)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Clients = _context.Clients.ToList();
            ViewBag.Voitures = _context.Voitures
                .Include(v => v.Modele)
                    .ThenInclude(m => m.Marque)
                .ToList();

            return View(reservation);
        }

        _context.Reservations.Update(reservation);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // DELETE
    public IActionResult Delete(int id)
    {
        var r = _context.Reservations.Find(id);

        if (r != null)
        {
            _context.Reservations.Remove(r);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}