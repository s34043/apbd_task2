namespace APBD_TASK2.Services;

using APBD_TASK2.Models;

public class RentalPolicy
{
    public int GetUserRentalLimit(User user)
    {
        if (user is Student)
            return 2;

        if (user is Employee)
            return 5;

        return 0;
    }

    public bool CanUserRent(User user, int activeRentalsCount)
    {
        return activeRentalsCount < GetUserRentalLimit(user);
    }
}