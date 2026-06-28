namespace projetLocation.Models;
public class Voiture
{
    public int Id { get; set; }
    public string Immatriculation { get; set; } = string.Empty;
    public int Annee { get; set; }
    public decimal TarifJournalier { get; set; }
    public int NombrePlaces { get; set; }
    public string Carburant { get; set; } = string.Empty;
    public int ModeleId { get; set; }
    public Modele? Modele { get; set; }
}