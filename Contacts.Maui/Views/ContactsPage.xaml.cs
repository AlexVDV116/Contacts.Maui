namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();

        List<Contact> contacts = new List<Contact>
        {
            new Contact { Name = "John Doe", Email = "JohnDoe@email.com" },
            new Contact { Name = "Jane Doe", Email = "JaneDoe@email.com" },
            new Contact { Name = "John Smith", Email = "JohnSmith@email.com" },
            new Contact { Name = "Jane Smith", Email = "JaneSmith@email.com" }
        };

        listContacts.ItemsSource = contacts;
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    private void ListContacts_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        throw new NotImplementedException();
    }
}