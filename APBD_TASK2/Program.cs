using APBD_TASK2.Data;
using APBD_TASK2.Models;
using APBD_TASK2.Services;

RentalPolicy rentalPolicy = new RentalPolicy();
PenaltyCalculator penaltyCalculator = new PenaltyCalculator();
EquipmentRentalService service = new EquipmentRentalService(rentalPolicy, penaltyCalculator);

DataSeeder.Seed(service);

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("===== EQUIPMENT RENTAL SYSTEM =====");
    Console.WriteLine("1. Add new user");
    Console.WriteLine("2. Add new equipment");
    Console.WriteLine("3. Show all equipment");
    Console.WriteLine("4. Show available equipment");
    Console.WriteLine("5. Rent equipment");
    Console.WriteLine("6. Return equipment");
    Console.WriteLine("7. Mark equipment as unavailable");
    Console.WriteLine("8. Show active rentals for user");
    Console.WriteLine("9. Show overdue rentals");
    Console.WriteLine("10. Show summary");
    Console.WriteLine("11. Show all users");
    Console.WriteLine("12. Show all rentals");
    Console.WriteLine("0. Exit");
    Console.Write("Choose option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddUser(service);
            break;
        case "2":
            AddEquipment(service);
            break;
        case "3":
            ShowAllEquipment(service);
            break;
        case "4":
            ShowAvailableEquipment(service);
            break;
        case "5":
            RentEquipment(service);
            break;
        case "6":
            ReturnEquipment(service);
            break;
        case "7":
            MarkUnavailable(service);
            break;
        case "8":
            ShowActiveRentalsForUser(service);
            break;
        case "9":
            ShowOverdueRentals(service);
            break;
        case "10":
            Console.WriteLine(service.GetSystemSummary());
            break;
        case "11":
            ShowAllUsers(service);
            break;
        case "12":
            ShowAllRentals(service);
            break;
        case "0":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static void AddUser(EquipmentRentalService service)
{
    Console.Write("Enter user id: ");
    int id = int.Parse(Console.ReadLine()!);

    Console.Write("Enter first name: ");
    string firstName = Console.ReadLine()!;

    Console.Write("Enter last name: ");
    string lastName = Console.ReadLine()!;

    Console.Write("Choose type: 1 - Student, 2 - Employee: ");
    string? type = Console.ReadLine();

    if (type == "1")
        service.AddUser(new Student(id, firstName, lastName));
    else if (type == "2")
        service.AddUser(new Employee(id, firstName, lastName));
    else
        Console.WriteLine("Invalid user type.");
}

static void AddEquipment(EquipmentRentalService service)
{
    Console.WriteLine("Choose equipment type:");
    Console.WriteLine("1. Laptop");
    Console.WriteLine("2. Projector");
    Console.WriteLine("3. Camera");
    Console.Write("Option: ");
    string? type = Console.ReadLine();

    Console.Write("Enter name: ");
    string name = Console.ReadLine()!;

    switch (type)
    {
        case "1":
            Console.Write("Enter RAM (GB): ");
            int ram = int.Parse(Console.ReadLine()!);
            Console.Write("Enter storage (GB): ");
            int storage = int.Parse(Console.ReadLine()!);
            service.AddEquipment(new Laptop(name, ram, storage));
            break;

        case "2":
            Console.Write("Enter resolution: ");
            string resolution = Console.ReadLine()!;
            Console.Write("Enter brightness: ");
            int brightness = int.Parse(Console.ReadLine()!);
            service.AddEquipment(new Projector(name, resolution, brightness));
            break;

        case "3":
            Console.Write("Enter megapixels: ");
            int mp = int.Parse(Console.ReadLine()!);
            Console.Write("Is digital? (true/false): ");
            bool isDigital = bool.Parse(Console.ReadLine()!);
            service.AddEquipment(new Camera(name, mp, isDigital));
            break;

        default:
            Console.WriteLine("Invalid equipment type.");
            break;
    }
}

static void ShowAllEquipment(EquipmentRentalService service)
{
    foreach (var item in service.GetAllEquipment())
    {
        Console.WriteLine(item);
    }
}

static void ShowAvailableEquipment(EquipmentRentalService service)
{
    foreach (var item in service.GetAvailableEquipment())
    {
        Console.WriteLine(item);
    }
}

static void RentEquipment(EquipmentRentalService service)
{
    ShowAllUsers(service);
    Console.Write("Enter user id: ");
    int userId = int.Parse(Console.ReadLine()!);

    ShowAvailableEquipment(service);
    Console.Write("Enter equipment id: ");
    Guid equipmentId = Guid.Parse(Console.ReadLine()!);

    Console.Write("Enter number of rental days: ");
    int days = int.Parse(Console.ReadLine()!);

    bool result = service.RentEquipment(userId, equipmentId, days);

    Console.WriteLine(result ? "Equipment rented successfully." : "Rental failed.");
}

static void ReturnEquipment(EquipmentRentalService service)
{
    ShowAllRentals(service);
    Console.Write("Enter rental id: ");
    Guid rentalId = Guid.Parse(Console.ReadLine()!);

    decimal penalty = service.ReturnEquipment(rentalId);

    if (penalty >= 0)
        Console.WriteLine($"Equipment returned. Penalty: {penalty}");
    else
        Console.WriteLine("Return failed.");
}

static void MarkUnavailable(EquipmentRentalService service)
{
    ShowAllEquipment(service);
    Console.Write("Enter equipment id: ");
    Guid equipmentId = Guid.Parse(Console.ReadLine()!);

    bool result = service.MarkEquipmentUnavailable(equipmentId);
    Console.WriteLine(result ? "Equipment marked as unavailable." : "Operation failed.");
}

static void ShowActiveRentalsForUser(EquipmentRentalService service)
{
    ShowAllUsers(service);
    Console.Write("Enter user id: ");
    int userId = int.Parse(Console.ReadLine()!);

    var rentals = service.GetActiveRentalsForUser(userId);

    foreach (var rental in rentals)
    {
        Console.WriteLine(rental);
    }
}

static void ShowOverdueRentals(EquipmentRentalService service)
{
    var rentals = service.GetOverdueRentals();

    foreach (var rental in rentals)
    {
        Console.WriteLine(rental);
    }
}

static void ShowAllUsers(EquipmentRentalService service)
{
    foreach (var user in service.GetAllUsers())
    {
        Console.WriteLine(user);
    }
}

static void ShowAllRentals(EquipmentRentalService service)
{
    foreach (var rental in service.GetAllRentals())
    {
        Console.WriteLine(rental);
    }
}