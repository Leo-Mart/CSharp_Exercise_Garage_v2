using System;

namespace Garagev2.Vehicles;

public class Car : Vehicle
{

  private int numberOfDoors;

  public int NumberOfDoors
  {
    get {return numberOfDoors;}
    set
    {
      numberOfDoors = value;
    }
  }

  public Car(string registryNumber, string color, int numberOfWheels, int numberOfDoors) : base(registryNumber, color, numberOfWheels)
  {
    NumberOfDoors = numberOfDoors;
  }

  public override string DisplayDetails()
  {
    return $"{GetType().Name}\nRegistry Number: {RegistryNumber}\nColor:{Color}\nNumber Of Wheels: {NumberOfWheels}\nNumber of Doors: {NumberOfDoors}\n";
  }

  public override string PrintFileDetails()
  {
    return $"type:{GetType().Name};registryNumber:{RegistryNumber};color:{Color};numberOfWheels:{NumberOfWheels};numberOfDoors:{NumberOfDoors}";
  }
}
