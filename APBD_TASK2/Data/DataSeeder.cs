namespace APBD_TASK2.Data;

using APBD_TASK2.Models;
using APBD_TASK2.Services;

public static class DataSeeder
{
    public static void Seed(EquipmentRentalService service)
    {
        service.AddUser(new Student(1, "Sasha", "Kidala"));
        service.AddUser(new Student(2, "Sava", "Sosed"));
        service.AddUser(new Employee(3, "Lexa", "Jopa"));
        service.AddUser(new Employee(4, "Raiden", "Lightning"));

        service.AddEquipment(new Laptop("Mac pro", 16, 512));
        service.AddEquipment(new Laptop("Lenovo ThinkPad", 8, 256));
        service.AddEquipment(new Projector("Lenivi ", "1920x1080", 3200));
        service.AddEquipment(new Projector("BenQ Pro", "1280x720", 2800));
        service.AddEquipment(new Camera("Canon EOS", 24, true));
        service.AddEquipment(new Camera("Nikon D3500", 20, true));
    }
}