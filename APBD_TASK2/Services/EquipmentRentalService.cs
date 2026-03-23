namespace APBD_TASK2.Services;

using APBD_TASK2.Models;

public class EquipmentRentalService
{
    private readonly List<User> _users = new();
    private readonly List<Equipment> _equipment = new();
    private readonly List<Rental> _rentals = new();

    private readonly RentalPolicy _rentalPolicy;
    private readonly PenaltyCalculator _penaltyCalculator;

    public EquipmentRentalService(RentalPolicy rentalPolicy, PenaltyCalculator penaltyCalculator)
    {
        _rentalPolicy = rentalPolicy;
        _penaltyCalculator = penaltyCalculator;
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void AddEquipment(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return _equipment;
    }

    public List<Equipment> GetAvailableEquipment()
    {
        return _equipment.Where(e => e.IsAvailable && !e.IsUnderMaintenance).ToList();
    }

    public bool RentEquipment(int userId, Guid equipmentId, int days)
    {
        User? user = _users.FirstOrDefault(u => u.Id == userId);
        Equipment? item = _equipment.FirstOrDefault(e => e.Id == equipmentId);

        if (user == null || item == null)
            return false;

        if (!item.IsAvailable || item.IsUnderMaintenance)
            return false;

        int activeRentals = _rentals.Count(r => r.User.Id == userId && !r.IsReturned);

        if (!_rentalPolicy.CanUserRent(user, activeRentals))
            return false;

        Rental rental = new Rental(user, item, days);
        _rentals.Add(rental);
        item.IsAvailable = false;

        return true;
    }

    public decimal ReturnEquipment(Guid rentalId)
    {
        Rental? rental = _rentals.FirstOrDefault(r => r.Id == rentalId && !r.IsReturned);

        if (rental == null)
            return -1;

        rental.ReturnDate = DateTime.Now;
        rental.IsReturned = true;
        rental.Penalty = _penaltyCalculator.CalculatePenalty(rental.DueDate, rental.ReturnDate.Value);
        rental.Equipment.IsAvailable = true;

        return rental.Penalty;
    }

    public bool MarkEquipmentUnavailable(Guid equipmentId)
    {
        Equipment? item = _equipment.FirstOrDefault(e => e.Id == equipmentId);

        if (item == null)
            return false;

        item.IsAvailable = false;
        item.IsUnderMaintenance = true;
        return true;
    }

    public List<Rental> GetActiveRentalsForUser(int userId)
    {
        return _rentals.Where(r => r.User.Id == userId && !r.IsReturned).ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return _rentals.Where(r => !r.IsReturned && r.DueDate < DateTime.Now).ToList();
    }

    public string GetSystemSummary()
    {
        int totalUsers = _users.Count;
        int totalEquipment = _equipment.Count;
        int availableEquipment = _equipment.Count(e => e.IsAvailable && !e.IsUnderMaintenance);
        int activeRentals = _rentals.Count(r => !r.IsReturned);
        int overdueRentals = _rentals.Count(r => !r.IsReturned && r.DueDate < DateTime.Now);

        return $"Users: {totalUsers}, Equipment: {totalEquipment}, Available: {availableEquipment}, Active rentals: {activeRentals}, Overdue rentals: {overdueRentals}";
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public List<Rental> GetAllRentals()
    {
        return _rentals;
    }
}