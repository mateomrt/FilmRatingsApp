using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmRatingsApp.Models;
using FilmRatingsApp.Services;
using Microsoft.UI.Xaml.Controls;

namespace FilmRatingsApp.ViewModels;

public partial class UtilisateurViewModel : ObservableObject
{
    private WSService service;
    public WSService Service
    {
        get
        {
            return service;
        }
        set
        {
            service = value;
            OnPropertyChanged();
        }
    }
    

    private Utilisateur utilisateurSearch;
    public Utilisateur UtilisateurSearch
    {
        get
        {
            return utilisateurSearch;
        }
        set
        {
            utilisateurSearch = value;
            OnPropertyChanged();
        }
    }

    private string searchMail;
    public string SearchMail
    {
        get
        {
            return searchMail;
        }
        set
        {
            searchMail = value;
            OnPropertyChanged();
        }
    }

    public IRelayCommand BtnSearchUtilisateurCommand { get; }
    public IRelayCommand BtnModifyUtilisateurCommand { get; }
    public IRelayCommand BtnAddUtilisateurCommand { get; }
    public UtilisateurViewModel()
    {
        var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
        string Uri = loader.GetString("WSSeriesLocalUri");
        Service = new WSService(Uri);

        UtilisateurSearch = new Utilisateur();

        BtnSearchUtilisateurCommand = new RelayCommand(RechercheUtilisateur);
        BtnModifyUtilisateurCommand = new RelayCommand(ModifierUtilisateur);
        BtnAddUtilisateurCommand = new RelayCommand(AjouterUtilisateur);

    }

    private async void AjouterUtilisateur()
    {
        bool result = await Service.PostUtilisateur("Utilisateurs", UtilisateurSearch);
        if (result)
            await MessageAsync("Utilisateur " + UtilisateurSearch.Nom + " ajouté !", "Information");
        else
            await MessageAsync("Opération ratée", "Erreur");
    }

    private async void ModifierUtilisateur()
    {
        bool result = await Service.PutUtilisateur("Utilisateurs", UtilisateurSearch.UtilisateurId, UtilisateurSearch);
        if (result)
            await MessageAsync("Utilisateur " + UtilisateurSearch.Nom + " modifié !", "Information");
        else
            await MessageAsync("Opération ratée", "Erreur");
    }

    private async void RechercheUtilisateur()
    {
        UtilisateurSearch = await Service.GetUtlisateurByEmail("Utilisateurs", SearchMail);
        
    }

    public async Task MessageAsync(string message, string titre)
    {
        ContentDialog contentDialog = new ContentDialog
        {
            Title = titre,
            Content = message,
            CloseButtonText = "Ok"
        };
        contentDialog.XamlRoot = App.MainRoot.XamlRoot;
        await contentDialog.ShowAsync();
    }
    public async Task<ContentDialogResult> MessageYesNoAsync(string message, string titre)
    {
        ContentDialog contentDialog = new ContentDialog
        {
            Title = titre,
            Content = message,
            CloseButtonText = "Annuler",
            PrimaryButtonText = "Confirmer"
        };
        contentDialog.XamlRoot = App.MainRoot.XamlRoot;
        return await contentDialog.ShowAsync();
    }
}
