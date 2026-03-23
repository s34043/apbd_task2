namespace APBD_TASK2.Models;

public class Equipment
{
    public  Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsUnderMaintenance { get; set; }

    protected Equipment(string name)
    {
        
    
    Id = Guid.NewGuid();
    Name = name;
    IsAvailable = true;
    IsUnderMaintenance = false;
}
    public override string ToString()
    {
        return $"{Id} | {Name} | Available: {IsAvailable} | Maintenance: {IsUnderMaintenance}";
    }
}