using System.ComponentModel.Design;
using System.Runtime.Serialization;
using AddressBook.Repository;


namespace AddressBookConsole;

public class ProgramUI
{
    private AddressBookRepo _contactRepo = new AddressBookRepo();

    public void Run()
    {
        SeedContactList();
        Menu();
    }

    // Menu

    private void Menu()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            System.Console.WriteLine("Select a menu option:\n" +
            "1. Create a contact\n" +
            "2. List all contacts\n" +
            "3. Search contact by name\n" +
            "4. Edit contact info\n" +
            "5. Remove a contact\n" +
            "6. Exit");

            // Get user input

            string input = System.Console.ReadLine();

            switch (input)
            {
                case "1":
                AddContactToList();
                break;

                case "2":
                GetContactList();
                break;

                case "3":
                GetContactByName();
                break;

                case "4":
                UpdateContactList();
                break;

                case "5":
                RemoveContact();
                break;

                case "6":
                System.Console.WriteLine("Closing address book. Good-bye!");
                keepRunning = false;
                break;

                default:
                System.Console.WriteLine("Please enter a valid number.");
                break;
            }

            System.Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();
            System.Console.Clear();
        }
    }

    // Create a contact

    private void AddContactToList()
    {
        System.Console.Clear();
        AddressBook.Repository.AddressBook newContact = CreateNewContactObject();
        _contactRepo.AddContactToList(newContact);
    }

    // View all contacts

    private void GetContactList()
    {
        System.Console.Clear();
        
        List<AddressBook.Repository.AddressBook> listOfAllContacts = _contactRepo.GetContactList();
        foreach (AddressBook.Repository.AddressBook contact in listOfAllContacts)
        {
            System.Console.WriteLine(
                $"Name: {contact.ContactName}\n" +
                $"ID: {contact.ContactID}");
        }
    }


    // View contact by name

    private void GetContactByName()
    {
        System.Console.Clear();

        System.Console.WriteLine("Enter the name of the contact you wish to see more information about.");

        string contactname = System.Console.ReadLine();

        var contact = _contactRepo.GetContactByName(contactname);

        if (contact != null)
        {
            System.Console.WriteLine(
                $"Name: {contact.ContactName}\n" +
                $"ID: {contact.ContactID}\n" +
                $"Address: {contact.ContactAddress}\n" +
                $"E-Mail: {contact.ContactEmail}\n" +
                $"Phone Number: {contact.ContactPhone}");
        }
    }

    // Edit contact info by ID

    private void UpdateContactList()
    {
        GetContactList();

        System.Console.WriteLine("Enter the ID of the contact you wish to update:");

        int originalID = int.Parse(System.Console.ReadLine());

        AddressBook.Repository.AddressBook newContact = CreateNewContactObject();

        bool wasUpdated = _contactRepo.UpdateContactList(originalID, newContact);

        if (wasUpdated)
        {
            System.Console.WriteLine("Contact succesfully updated.");
        }
        else
        {
            System.Console.WriteLine("Could not update contact.");
        }
    }

    private static AddressBook.Repository.AddressBook CreateNewContactObject()
    {
        AddressBook.Repository.AddressBook newContact = new AddressBook.Repository.AddressBook();

        System.Console.WriteLine("Enter the name of the contact:");
        newContact.ContactName = System.Console.ReadLine();

        System.Console.WriteLine("Enter the ID of the contact:");
        string contactByID = System.Console.ReadLine();
        newContact.ContactID = int.Parse(contactByID);

        System.Console.WriteLine("Enter the address of the contact:");
        newContact.ContactAddress = System.Console.ReadLine();

        System.Console.WriteLine("Enter the email of the contact:");
        newContact.ContactEmail = System.Console.ReadLine();

        System.Console.WriteLine("Enter the phone number of the contact:");
        string contactByPhone = System.Console.ReadLine();
        newContact.ContactPhone = int.Parse(contactByPhone);
        
        return newContact;
    }

    // Delete a contact by their ID

    private void RemoveContact()
    {
        System.Console.Clear();

        GetContactList();

        System.Console.WriteLine("Enter the ID of the contact you wish to delete.");
        int contactUniqueID = int.Parse(System.Console.ReadLine());
        var contactToDisplay = _contactRepo.GetContactByID(contactUniqueID);

        bool wasDeleted = _contactRepo.RemoveContact(contactUniqueID);

        if (wasDeleted)
        {
            System.Console.WriteLine("The contact was successfully deleted.");
        }
        else
        {
            System.Console.WriteLine("The contact could not be deleted.");
        }
    }

    private void SeedContactList()
    {
        AddressBook.Repository.AddressBook chandler = new AddressBook.Repository.AddressBook(5473, "Chandler Shover", "7777 Sneed Drive", "chandlershover@fakemail.com", 8675309);
        AddressBook.Repository.AddressBook sergio = new AddressBook.Repository.AddressBook(1337, "Sergio Hernandez", "1234 Fake Lane", "sergiohernandez@fakemail.com", 4445555);

        _contactRepo.AddContactToList(chandler);
        _contactRepo.AddContactToList(sergio);
    }

}