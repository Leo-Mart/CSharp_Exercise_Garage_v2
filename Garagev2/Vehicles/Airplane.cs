using System;

namespace Garagev2.Vehicles;

public class Airplane : Vehicle
{
  private int length;

  public int Length
  {
    get {return length;}
    set
    {
      length = value;
    }
  }
  public Airplane(string registryNumber, string color, int numberOfWheels, int length) : base(registryNumber, color, numberOfWheels)
  {
    Length = length;
  }

  public override string DisplayDetails()
  {
    return $"{GetType().Name}\nRegistry Number: {RegistryNumber}\nColor:{Color}\nNumber Of Wheels: {NumberOfWheels}\nTotal Length: {Length}\n";
  }

  public override string PrintFileDetails()
  {
    return $"type:{GetType().Name};registryNumber:{RegistryNumber};color:{Color};numberOfWheels:{NumberOfWheels};length:{Length}";
  }
}
