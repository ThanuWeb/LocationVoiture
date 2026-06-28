using projetLocation.Data;
using projetLocation.Models;

namespace projetLocation.Services;
public class ReservationService
{
    private readonly AppDbContext _context;
    public ReservationService(AppDbContext context)
    {
        _context = context;
    }
    public bool Ajouter(Reservation reservation, out string erreur)
    {
        erreur = "";
        if (reservation.DateFin < reservation.DateDebut)
        {
            erreur = "La date de fin doit être après la date de début.";
            return false;
        }
        _context.Reservations.Add(reservation);
        _context.SaveChanges();
        return true;
    }
}