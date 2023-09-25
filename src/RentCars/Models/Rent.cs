using RentCars.Types;

namespace RentCars.Models;

public class Rent
{
    public Vehicle Vehicle { get; set; }
    public Person Person { get; set; }
    public int DaysRented { get; set; }
    public double Price { get; set; }
    public RentStatus Status { get; set; }

    //10 - Crie o construtor de `Rent` seguindo as regras de negócio
    public Rent(Vehicle vehicle, Person person, int daysRented)
    {
        Vehicle = vehicle;
        Person = person;
        DaysRented = daysRented;
        Status = RentStatus.Confirmed;
        Vehicle.IsRented = true;
        // if (typeof(PhysicalPerson).IsInstanceOfType(person))
        // {
        //     Price = Vehicle.PricePerDay * DaysRented;
        // }
        // else
        // {
        //     Price = Vehicle.PricePerDay * DaysRented;
        //     Price -= Price * 0.1;
        // }
        double totalPrice = Vehicle.PricePerDay * DaysRented;
        Price = typeof(PhysicalPerson).IsInstanceOfType(person) ? totalPrice : totalPrice - totalPrice * 0.1;
        Person.Debit = Price;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Cancel()
    {
        Status = RentStatus.Canceled;
        Vehicle.IsRented = false;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Finish()
    {
        Status = RentStatus.Finished;
        Vehicle.IsRented = false;
    }
}