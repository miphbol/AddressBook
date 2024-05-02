namespace AddressBook.Repository;

public class AddressBookRepo
{
    private List<AddressBook> _addressBookList = new List<AddressBook>();

    // Create

    public void AddContactToList(AddressBook contact)
    {
        _addressBookList.Add(contact);
    }

    // Read

    public List<AddressBook> GetContactList()
    {
        return new List<AddressBook>(_addressBookList);
    }

    // Update

    public bool UpdateContactList(int originalID, AddressBook newContact)
    {
        AddressBook oldContact = GetContactByID(originalID);

        if (oldContact != null)
        {
            oldContact.ContactID = newContact.ContactID;
            oldContact.ContactName = newContact.ContactName;
            oldContact.ContactAddress = newContact.ContactAddress;
            oldContact.ContactEmail = newContact.ContactEmail;
            oldContact.ContactPhone = newContact.ContactPhone;

            return true;

        }
        else
        {
            return false;
        }
    }

    // Delete

    public bool RemoveContact(int contactid)
    {
        AddressBook contact = GetContactByID(contactid);

        if (contact == null)
        {
            return false;
        }

        int initialCount = _addressBookList.Count;
        _addressBookList.Remove(contact);

        if (initialCount > _addressBookList.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    


    // Helper methods

    public AddressBook GetContactByID(int contactid)
    {
        foreach (AddressBook contact in _addressBookList)
        {
            if (contact.ContactID == contactid)
            {
                return contact;
            }
        }

        return null;
    }

    public AddressBook GetContactByName(string contactname)
    {
        foreach (AddressBook contact in _addressBookList)
        {
            if (contact.ContactName.ToLower() == contactname.ToLower())
            {
                return contact;
            }
        }

        return null;
    }
}


