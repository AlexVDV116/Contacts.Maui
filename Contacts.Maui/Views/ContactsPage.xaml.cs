using System.Collections.ObjectModel;
using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        SearchBar.Text = string.Empty;

        LoadContacts();
    }

    private async void ListContacts_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        if (ListContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync(
                $"{nameof(EditContactPage)}?Id={((Contact)ListContacts.SelectedItem).ContactId}");
        }
    }

    private void ListContacts_OnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        ListContacts.SelectedItem = null;
    }

    private void BtnAddContact_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void Delete_Clicked(object? sender, EventArgs e)
    {
        var contact = (sender as MenuItem)?.CommandParameter as Contact;
        if (contact != null)
        {
            ContactRepository.DeleteContact(contact.ContactId);
        }

        LoadContacts();
    }

    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());

        ListContacts.ItemsSource = contacts;
    }

    private void SearchBar_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        ListContacts.ItemsSource = contacts;
    }
}