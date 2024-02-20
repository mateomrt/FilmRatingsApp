using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FilmRatingsApp.Models;

namespace FilmRatingsApp.Services;
public class WSService : IService
{
    private readonly HttpClient httpClient;

    public WSService(string uri)
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(uri);
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Utilisateur>> GetUtilisateurs(string nomControleur)
    {
        try
        {
            return await httpClient.GetFromJsonAsync<List<Utilisateur>>(nomControleur);
        }
        catch (Exception)
        {
            return null;
        }
    }
    public async Task<Utilisateur> GetUtlisateurById(string nomControleur, int id)
    {
        try
        {
            string lien = string.Concat(nomControleur, "/", id);
            return await httpClient.GetFromJsonAsync<Utilisateur>(lien);
        }
        catch (Exception)
        {
            return null;
        }
    }
    public async Task<Utilisateur> GetUtlisateurByEmail(string nomControleur, string email)
    {
        try
        {
            string lien = string.Concat(nomControleur, "/getbyemail/", email);
            return await httpClient.GetFromJsonAsync<Utilisateur>(lien);
        }
        catch (Exception)
        {
            return null;
        }
    }
    public async Task<bool> PostUtilisateur(string nomControleur, Utilisateur user)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync(nomControleur, user);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;

        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<bool> PutUtilisateur(string nomControleur, int id, Utilisateur user)
    {
        try
        {
            string lien = string.Concat(nomControleur, "/", id);
            var response = await httpClient.PutAsJsonAsync(lien, user);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;

        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<bool> DeleteUtilisateur(string nomControleur, int id)
    {
        try
        {
            string lien = string.Concat(nomControleur, "/", id);
            var response = await httpClient.DeleteAsync(lien);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;

        }
        catch (Exception)
        {
            return false;
        }
    }
}
