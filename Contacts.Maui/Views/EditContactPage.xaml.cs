using Contacts.Maui.Models;
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
                EntryName.Text = _contact.Name;
                EntryEmail.Text = _contact.Email;
                EntryPhone.Text = _contact.Phone;
                EntryAddress.Text = _contact.Address;
            }
        }
    }

    private void BtnUpdate_OnClicked(object? sender, EventArgs e)
    {
        _contact.Name = EntryName.Text;
        _contact.Email = EntryEmail.Text;
        _contact.Phone = EntryPhone.Text;
        _contact.Address = EntryAddress.Text;


        ContactRepository.UpdateContact(_contact.ContactId, _contact);
        Shell.Current.GoToAsync("..");

    }
}