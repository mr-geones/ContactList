using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    // För godkänd
    bool CreateContact(Contact contact);
    IEnumerable<Contact> GetAllContacts();

    // För väl godkänd
    Contact GetContactById(Func<Contact, bool> predicate);
    bool UpdateContact(Func<Contact, bool> predicate, Contact updatedContact);
    bool DeleteContact(Func<Contact, bool> predicate);
}