using System;

namespace Garagev2.Vehicles;

public class Boat : Vehicle
{
  private bool hasSails;

  public bool HasSails
  {
    get {return hasSails;}
    set
    {
      hasSails = value;
    }
  }
  public Boat(string registryNumber, string color, int numberOfWheels, bool hasSails) : base(registryNumber, color, numberOfWheels)
  {
    HasSails = hasSails;
  }

  public override string DisplayDetails()
  {
    return $"{GetType().Name}\nRegistry Number: {RegistryNumber}\nColor:{Color}\nNumber Of Wheels: {NumberOfWheels}\nIs a Sailboat: {HasSails}\n";
  }

  public override string PrintFileDetails()
  {
    return $"type:{GetType().Name};registryNumber:{RegistryNumber};color:{Color};numberOfWheels:{NumberOfWheels};hasSails:{HasSails}";
  }
}
