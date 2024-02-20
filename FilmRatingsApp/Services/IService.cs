using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmRatingsApp.Models;
using Windows.System.Diagnostics;

namespace FilmRatingsApp.Services;
public interface IService
{
    Task<List<Utilisateur>> GetUtilisateurs(string nomControleur);
    Task<Utilisateur> GetUtlisateurById(string nomControleur, int id);
    Task<Utilisateur> GetUtlisateurByEmail(string nomControleur, string email);

    Task<bool> PostUtilisateur(string nomControleur, Utilisateur user);

    Task<bool> PutUtilisateur(string nomControleur, int id, Utilisateur user);

    Task<bool> DeleteUtilisateur(string nomControleur, int id);
}
