# APBD_TASK2

## Project description
This is a console application for renting equipment.  
The system allows managing users, equipment, rentals, returns, overdue items, and penalties.

## Domain model
The application includes:
 Equipment as a common base class
 Three equipment types: Laptop, Projector, Camera
 User as a common base class
 Two user types: Student, Employee
 Rental entity for storing rental details
 Service layer for business logic

## Functionalities
The application supports:
1. Adding a new user
2. Adding a new equipment item
3. Displaying all equipment
4. Displaying available equipment
5. Renting equipment
6. Returning equipment and calculating penalty
7. Marking equipment as unavailable
8. Displaying active rentals for a selected user
9. Displaying overdue rentals
10. Generating a summary report

## Business rules
 A student can have at most 2 active rentals
 An employee can have at most 5 active rentals
 Unavailable equipment cannot be rented
 Late return results in a penalty
 Penalty is calculated as 5 per late day

## Design decisions
 Inheritance was used for equipment and user hierarchies
 Business rules were separated into service classes
 `RentalPolicy` is responsible for rental limits
 `PenaltyCalculator` is responsible for penalty calculation
 `EquipmentRentalService` handles the main business logic
 `DataSeeder` provides initial sample data

