using Contacts.Maui.Models;
using Contacts.Maui.Views.Controls;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact? _contact;

    public EditContactPage()
    {
        InitializeComponent();
    }

    private void BtnCancel_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    public string ContactId
    {
        set
        {
            _contact = ContactRepository.GetContactById(int.Parse(value));
            if (_contact != null)
            {
                ContactControl.Name = _contact.Name;
                ContactControl.Email = _contact.Email;
                ContactControl.Phone = _contact.Phone;
                ContactControl.Address = _contact.Address;
            }
        }
    }

    private void BtnUpdate_OnClicked(object? sender, EventArgs e)
    {
        _contact.Name = ContactControl.Name;
        _contact.Email = ContactControl.Email;
        _contact.Phone = ContactControl.Phone;
        _contact.Address = ContactControl.Address;
        
        ContactRepository.UpdateContact(_contact.ContactId, _contact);
        Shell.Current.GoToAsync("..");

    }

    private void ContactControl_OnError(object? sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}