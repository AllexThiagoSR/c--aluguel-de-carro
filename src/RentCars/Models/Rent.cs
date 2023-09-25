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
        this.Vehicle = vehicle;
        this.Person = person;
        this.DaysRented = daysRented;
        this.Status = RentStatus.Confirmed;
        this.Vehicle.IsRented = true;
        // if (typeof(PhysicalPerson).IsInstanceOfType(person))
        // {
        //     Price = Vehicle.PricePerDay * DaysRented;
        // }
        // else
        // {
        //     Price = Vehicle.PricePerDay * DaysRented;
        //     Price -= Price * 0.1;
        // }
        double totalPrice = this.Vehicle.PricePerDay * this.DaysRented;
        this.Price = typeof(PhysicalPerson).IsInstanceOfType(person) ? totalPrice : totalPrice - totalPrice * 0.1;
        this.Person.Debit = this.Price;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Cancel()
    {
        this.Status = RentStatus.Canceled;
        this.Vehicle.IsRented = false;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Finish()
    {
        this.Status = RentStatus.Finished;
        this.Vehicle.IsRented = false;
    }
}