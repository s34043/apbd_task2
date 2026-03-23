namespace APBD_TASK2.Models;

public class Student : User
{
    public Student(int id, string firstName, string lastName) : base(id, firstName, lastName)
    {
        
    }

    public override string UserType => "Student";
}