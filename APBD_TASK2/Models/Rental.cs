namespace APBD_TASK2.Models;

public class Rental
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal Penalty { get; set; }
    public bool IsReturned { get; set; }

    public Rental(User user, Equipment equipment, int days)
    {
        Id = Guid.NewGuid();
        User = user;
        Equipment = equipment;
        RentalDate = DateTime.Now;
        DueDate = RentalDate.AddDays(days);
        ReturnDate = null;
        Penalty = 0;
        IsReturned = false;
    }

    public bool WasReturnedOnTime => ReturnDate.HasValue && ReturnDate.Value <= DueDate;

    public override string ToString()
    {
        return $"{Id} | User: {User.FirstName} {User.LastName} | Equipment: {Equipment.Name} | " +
               $"From: {RentalDate} | Due: {DueDate} | Returned: {ReturnDate} | Penalty: {Penalty}";
    }
}