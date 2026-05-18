using System;

namespace Garagev2.Vehicles;

public abstract class Vehicle: IVehicle
{
  private string registryNumber;
  private string color;
  private int numberOfWheels;
 

  public string RegistryNumber
  {
    get {return registryNumber;}
    set
    {
      registryNumber = value;
    }
  }
  public string Color
  {
    get {return color;}
    set
    {
      color = value;
    }
  }
  
  public int NumberOfWheels
  {
    get {return numberOfWheels;}
    set
    {
      numberOfWheels = value;
    }
  }


  public Vehicle(string registryNumber, string color, int numberOfWheels)
  {
    Color = color;
    RegistryNumber = registryNumber;
    NumberOfWheels = numberOfWheels;
    
  } 

  public virtual string DisplayDetails()
  {
    return $"Registry Number: {RegistryNumber}\nColor:{Color}\nNumber Of Wheels: {NumberOfWheels}\n";
  }

  public virtual string PrintFileDetails()
  {
    return $"type:{GetType().Name};registryNumber:{RegistryNumber};color:{Color};numberOfWheels:{NumberOfWheels}";
  }
}
