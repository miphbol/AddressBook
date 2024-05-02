using System.Collections.Concurrent;
using System.Data;
using AddressBook.Repository;

namespace AddressBook.Test;

[TestClass]

public class AddressBookUnitTests
{
    private AddressBookRepo _addressbookrepo;

    private AddressBook.Repository.AddressBook _addressbook;
    [TestInitialize]

    public void Arrange()
    {
        _addressbookrepo = new AddressBookRepo();
        _addressbook = new Repository.AddressBook(5473, "Chandler Shover", "7777 Sneed Drive", "chandlershover@fakemail.com", 8675309);
    }

    // Add Method
    [TestMethod]

    public void AddToList_ShouldGetNotNull()
    {
        AddressBook.Repository.AddressBook contact = new Repository.AddressBook();
        contact.ContactID = 1337;
        AddressBookRepo repository = new AddressBookRepo();

        repository.AddContactToList(contact);
        AddressBook.Repository.AddressBook contactFromList = repository.GetContactByID(1337);

        Assert.IsNotNull(contactFromList);
    }

    // Update

    [TestMethod]

    public void UpdateContactList_ShouldReturnTrue()
    {
        AddressBook.Repository.AddressBook newContact = new Repository.AddressBook(5473, "Chandler Shover", "888 Fake Lane", "chandlershover@fakemail.com", 1234567);

        bool updateResult = _addressbookrepo.UpdateContactList(5473, newContact);

        Assert.IsTrue(updateResult);
    }

    [TestMethod]
    [DataRow(5473, true)]
    [DataRow(1337, false)]

    public void UpdateContactList_ShouldMatchGivenBool(int originalID, bool shouldUpdate)
    {
        AddressBook.Repository.AddressBook newContact = new Repository.AddressBook(5473, "Chandler Shover", "888 Fake Lane", "chandlershover@fakemail.com", 1234567);

        bool updateResult = _addressbookrepo.UpdateContactList(originalID, newContact);

        Assert.AreEqual(shouldUpdate, updateResult);
    }

    // Delete

    [TestMethod]

    public void DeleteContact_ShouldReturnTrue()
    {
        bool deleteResult = _addressbookrepo.RemoveContact(_addressbook.ContactID);

        Assert.IsTrue(deleteResult);
    }
}