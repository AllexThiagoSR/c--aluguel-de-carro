using RentCars.Types;
namespace RentCars.Models;

//6 - Faça a classe `Car` herdar de `Vehicle`
public class Car : Vehicle
{
  public int Seats;
  public int Doors;
  public TractionType Traction;
  public BrakeType FrontBrake;
  public BrakeType RearBrake;
}