namespace Contacts.Maui.Models;

public static class ContactRepository
{
    public static List<Contact> _contacts = new List<Contact>()
    {
        new Contact { ContactId = 0, Name = "John Doe", Email = "JohnDoe@email.com" },
        new Contact { ContactId = 1, Name = "Jane Doe", Email = "JaneDoe@email.com" },
        new Contact { ContactId = 2, Name = "John Smith", Email = "JohnSmith@email.com" },
        new Contact { ContactId = 3, Name = "Jane Smith", Email = "JaneSmith@email.com" }
    };
    
    public static List<Contact> GetContacts() => _contacts;

    public static Contact? GetContactById(int contactId)
    {
        return _contacts.FirstOrDefault(c => c.ContactId == contactId);
    }
}