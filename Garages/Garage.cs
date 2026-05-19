using System;
using System.Collections;
using Garagev2.Vehicles;

namespace Garagev2.Garages;

public class Garage<T> : IEnumerable<T> where T : Vehicle
{
  private string name;
  private Vehicle[] vehicles;
  public Vehicle[] Vehicles
  {
    get {return vehicles;}
    set
    {
      vehicles = value;
    }
  }

  public string Name
  {
    get {return name;}
    set
    {
      name = value;
    }
  }

  public Garage(int sizeOfGarage, string name)
  {
    Vehicles = new Vehicle[sizeOfGarage];
    Name = name;
  }

  public IEnumerator<T> GetEnumerator()
  {
    foreach (var v in Vehicles)
    {
      if (v == null) 
        continue;
      yield return (T)v;
    }
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }
}
