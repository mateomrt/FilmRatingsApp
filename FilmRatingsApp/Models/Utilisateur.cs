using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FilmRatingsApp.Models;


public partial class Utilisateur
{
    public Utilisateur()
    {
        NotesUtilisateur = new HashSet<Notation>();
    }

    public int UtilisateurId { get; set; }
    public string? Nom { get; set; }
    public string? Prenom { get; set; }
    public string? Mobile { get; set; }
    public string Mail { get; set; }
    public string Pwd { get; set; }
    public string? Rue { get; set; }
    public string? CodePostal { get; set; }
    public string? Ville { get; set; }
    public string? Pays { get; set; }
    public float? Latitude { get; set; }
    public float? Longitude { get; set; }
    public DateTime DateCreation { get; set; }

    public  ICollection<Notation> NotesUtilisateur { get; set; }

    
}
