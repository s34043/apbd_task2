namespace APBD_TASK2.Models;

public class Employee : User
{
    public Employee(int id, string firstName, string lastName) : base(id, firstName, lastName)
    {
        
    }
    public override string UserType => "Employee";
}