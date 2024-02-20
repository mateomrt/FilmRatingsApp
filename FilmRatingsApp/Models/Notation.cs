using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmRatingsApp.Models;

public partial class Notation
{
    public int UtilisateurId { get; set; }
    
    public int FilmId { get; set; }

    public int Note { get; set; }

    public virtual Film FilmNote { get; set; }

    public  Utilisateur UtilisateurNotant { get; set; } 

}
