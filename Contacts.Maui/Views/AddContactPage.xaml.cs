using Contacts.Maui.Models;

namespace Contacts.Maui.Views;

public partial class AddContactPage : ContentPage
{
    public AddContactPage()
    {
        InitializeComponent();
    }

    private void ContactControl_OnSave(object? sender, EventArgs e)
    {
        ContactRepository.AddContact(new Models.Contact
        {
            Name = ContactControl.Name,
            Email = ContactControl.Email,
            Phone = ContactControl.Phone,
            Address = ContactControl.Address
        });
        
        Shell.Current.GoToAsync("..");
    }

    private void ContactControl_OnCancel(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void ContactControl_OnError(object? sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}