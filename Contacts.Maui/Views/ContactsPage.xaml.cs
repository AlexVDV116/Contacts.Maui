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

        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());

        ListContacts.ItemsSource = contacts;
    }
    private async void ListContacts_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        if (ListContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)ListContacts.SelectedItem).ContactId}");
        }
    }

    private void ListContacts_OnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        ListContacts.SelectedItem = null;
    }
}