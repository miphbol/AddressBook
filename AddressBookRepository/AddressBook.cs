namespace AddressBook.Repository;

// POCO

public class AddressBook

{
    public int ContactID { get; set; }
    public string ContactName { get; set; }
    public string  ContactAddress { get; set; }
    public string ContactEmail { get; set; }
    public int ContactPhone { get; set; }

    public AddressBook() {}

    public AddressBook(int contactid, string contactname, string contactaddress, string contactemail, int contactphone )
    {
        ContactID = contactid;
        ContactName = contactname;
        ContactAddress = contactaddress;
        ContactEmail = contactemail;
        ContactPhone = contactphone;
    }

}

