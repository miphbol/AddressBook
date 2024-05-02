using AddressBook.Repository;

namespace AddressBook.Test;

[TestClass]

public class UnitTest1
{
    public void SetID_ShouldSetCorrectInt()
    {
        AddressBook.Repository.AddressBook contact = new Repository.AddressBook();

        contact.ContactID = 5473;

        int expected = 5473;
        int actual = contact.ContactID;

        Assert.AreEqual(expected, actual);
    }
}