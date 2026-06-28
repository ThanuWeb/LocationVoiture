using System.ComponentModel.DataAnnotations;

namespace projetLocation.Models;
public class Modele
{
    public int Id { get; set; }
    [Required]
    public string Nom { get; set; } = string.Empty;
    public int MarqueId { get; set; }
    public Marque Marque { get; set; } = null!;
    public List<Voiture> Voitures { get; set; } = new();
}