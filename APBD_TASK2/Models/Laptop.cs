namespace APBD_TASK2.Models;

public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public int StorageGb { get; set; }

    public Laptop(string name, int ramGb, int storageGb) : base(name)
    {
        RamGb = ramGb;
        StorageGb = storageGb;
    }

    public override string ToString()
    {
        return $"Laptop: {base.ToString()} | RAM: {RamGb} GB | Storage: {StorageGb} GB";
    }
}