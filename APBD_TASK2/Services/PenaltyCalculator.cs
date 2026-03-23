namespace APBD_TASK2.Services;

public class PenaltyCalculator
{
    private const decimal PenaltyPerDay = 5m;

    public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate <= dueDate)
            return 0;

        int lateDays = (returnDate.Date - dueDate.Date).Days;
        return lateDays * PenaltyPerDay;
    }
}