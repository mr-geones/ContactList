﻿using Business.Factories;
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
            Console.WriteLine(" ");
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine(" ");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    AddNewContact();
                    break;
                case "2":
                    ViewAllContacts();
                    break;
            }
        }  
    }

    private void AddNewContact()
    {
        var contact = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine("--- Add New Contact ---");
        Console.WriteLine(" ");
        
        Console.Write("Enter Forename: ");
        contact.Forename = Console.ReadLine()!;

        Console.Write("Enter Surname: ");
        contact.Surname = Console.ReadLine()!;

        Console.Write("Enter Email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Enter Phone Number: ");
        contact.Phone = Console.ReadLine()!;

        Console.Write("Enter Address: ");
        contact.Address = Console.ReadLine()!;

        Console.Write("Enter Postal Code: ");
        contact.PostalCode = Console.ReadLine()!;

        Console.Write("Enter City: ");
        contact.City = Console.ReadLine()!;

        var result = _contactService.CreateContact(contact);

        if (result)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Contact added successfully. Press ENTER");
        }
        else
        {
            Console.WriteLine(" ");
            Console.WriteLine("Failed to add contact. Press ENTER");
        }

        Console.ReadKey();
    }

    private void ViewAllContacts()
    {
        Console.Clear();
        Console.WriteLine("--- View All Contacts ---");
        Console.WriteLine(" ");

        foreach (var contact in _contactService.GetAllContacts())
        {
            Console.WriteLine($"Name: {contact.Forename} {contact.Surname}");
            Console.WriteLine($"Address: {contact.Address}");
            Console.WriteLine($"Postal Code and City: {contact.PostalCode} {contact.City}");
            Console.WriteLine($"Phone number: {contact.Phone}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"ID: {contact.Id}");
            Console.WriteLine($"---------------------");
        }

        Console.ReadKey();
    }
}
