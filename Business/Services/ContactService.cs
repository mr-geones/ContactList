using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService(IContactRepository contactRepository) : IContactService
{
    private readonly IContactRepository _contactRepository = contactRepository;
    private List<Contact> _contacts = [];

    public bool CreateContact(Contact contact)
    {
        try
        {
            contact.Id = IdGenerator.GenerateUniqueId();
            _contacts.Add(contact);

            var result = _contactRepository.SaveContactListToFile(_contacts);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        _contacts = _contactRepository.GetContactsFromFile();
        return _contacts;
    }

    // VG kriterier
    public Contact GetContactById(Func<Contact, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public bool UpdateContact(Func<Contact, bool> predicate, Contact updatedContact)
    {
        throw new NotImplementedException();
    }

    public bool DeleteContact(Func<Contact, bool> predicate)
    {
        throw new NotImplementedException();
    }
}
