using Business.Factories;
using Business.Interfaces;

namespace ConsoleApp_Main.Dialogs;

public class MenuDialog(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Main Menu ---");
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Select an option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    AddNewContact();
                    break;
                case "2":
                    ViewAllContacts();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }  
    }

    private void ViewAllContacts()
    {
        var contact = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine("--- Add New Contact ---");
        Console.WriteLine("Enter Name: ");

        contact.Name = Console.ReadLine()!;

        var result = _contactService.CreateContact(contact);

        if (result)
        {
            Console.WriteLine("Contact added successfully");
        }
        else
        {
            Console.WriteLine("Failed to add contact");
        }

        Console.ReadKey();
    }

    private void AddNewContact()
    {
        Console.Clear();
        Console.WriteLine("--- View All Contacts ---");

        foreach (var contact in _contactService.GetAllContacts())
        {
            Console.WriteLine($"Name: {contact.Name} ({contact.Id})");
        }

        Console.ReadKey();
    }
}
