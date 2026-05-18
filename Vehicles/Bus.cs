using System;

namespace Garagev2.Vehicles;

public class Bus : Vehicle
{
  private int seats;

  public int Seats
  {
    get {return seats;}
    set
    {
      seats = value;
    }
  }
  public Bus(string registryNumber, string color, int numberOfWheels, int seats) : base(registryNumber, color, numberOfWheels)
  {
    Seats = seats;
  }

  public override string DisplayDetails()
  {
    return $"{GetType().Name}\nRegistry Number: {RegistryNumber}\nColor:{Color}\nNumber Of Wheels: {NumberOfWheels}\nNumber of Seats: {seats}\n";
  }

  public override string PrintFileDetails()
  {
    return $"type:{GetType().Name};registryNumber:{RegistryNumber};color:{Color};numberOfWheels:{NumberOfWheels};seats:{Seats}";
  }
}
