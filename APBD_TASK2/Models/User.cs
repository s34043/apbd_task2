namespace APBD_TASK2.Models;

public abstract class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected User(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public abstract string UserType { get; }

    public override string ToString()
    {
        return $"{Id} | {FirstName} {LastName} | Type: {UserType}";
    }
}