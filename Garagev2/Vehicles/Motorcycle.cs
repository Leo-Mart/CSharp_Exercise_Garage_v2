using System;

namespace Garagev2.Vehicles;

public class Motorcycle : Vehicle
{
  private string brand;

  public string Brand
  {
    get {return brand;}
    set
    {
      brand = value;
    }
  }
  public Motorcycle(string registryNumber, string color, int numberOfWheels, string brand) : base(registryNumber, color, numberOfWheels)
  {
    Brand = brand;
  }

  public override string DisplayDetails()
  {
    return $"{GetType().Name}\nRegistry Number: {RegistryNumber}\nColor:{Color}\nNumber Of Wheels: {NumberOfWheels}\nMotorcycle Brand: {Brand}\n";
  }

  public override string PrintFileDetails()
  {
    return $"type:{GetType().Name};registryNumber:{RegistryNumber};color:{Color};numberOfWheels:{NumberOfWheels};brand:{Brand}";
  }
}
