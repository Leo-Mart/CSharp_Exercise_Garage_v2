using System;
using Garagev2.Utilities;
using Garagev2.Vehicles;

namespace Garagev2.Garages;

public class GarageHandler : IGarageHandler
{
  public Garage<Vehicle> Garage {get; private set;}

  public GarageHandler(Garage<Vehicle> garage)
  {
    Garage = garage;
  }

  public void ListAllVehicles()
  {
    if (CheckForAvailableSpaces() == Garage.Count())
    {
      ErrorUtils.PrintError("There are currently no vehicles in the garage!");

    }

    Console.WriteLine("Current Vehicles in the garage: ");
    foreach (var v in Garage)
    {
      if (v == null)
      {
        continue;
      }
      Console.WriteLine(v.DisplayDetails());

    }
  }

  public void AddNewVehicle(Vehicle newVehicle)
  {       
    for (int i = 0; i <= Garage.Count(); i++)
    {
      if (Garage.Vehicles[i] == null)
      {
        Garage.Vehicles[i] = newVehicle;
        Console.WriteLine("Vehicle was added successfully!");
        return;
      }
      else
      {
        continue;
      }
    }
  }

  public Vehicle FindVehicleByRegistrationNumber(string regNumber)
  {
    try
    {
      var foundVehicle = Garage.First(v => v != null && v.RegistryNumber == regNumber);
      Console.WriteLine("Found vehicle");
      return foundVehicle;
    }
    catch (InvalidOperationException e)
    {
      ErrorUtils.PrintError("Could not find a vehicle with that registration number.");
      ErrorUtils.PrintError(e.Message);
      return null;
    }
  }

  public void RemoveVehicleByRegistrationNumber(string regNumber)
  {
    var foundVehicle = Garage.First(v => v != null && v.RegistryNumber == regNumber);
    if (foundVehicle == null)
    {
      ErrorUtils.PrintError("Could not find a vehicle with that registration number.");
      return;
    }
    int index = Garage.Vehicles.IndexOf(foundVehicle);

    Garage.Vehicles[index] = null;

    Console.WriteLine($"Vehicle with registration number: {regNumber} has been removed");
  }

  public int CheckForAvailableSpaces()
  {
    int count = Garage.Vehicles.Count( v => v == null);
    return count; 
  }

  public bool CheckRegistrationNumberUniqueness(string regNumber)
  {
    foreach (var v in Garage.Vehicles)
    {
      var exists = Garage.Any(v => v.RegistryNumber == regNumber.ToLower());
      return exists;
    }
    return false;
  }

  public void CountVehicleTypes()
  {
    int amountOfCars = Garage.Count(v => v != null && v.GetType() == typeof(Car));
    int amountOfBuses = Garage.Count(v => v != null && v.GetType() == typeof(Bus));
    int amountOfAirPlanes = Garage.Count(v => v != null && v.GetType() == typeof(Airplane));
    int amountOfBoats = Garage.Count(v => v != null && v.GetType() == typeof(Boat));
    int amountOfMotorcycles = Garage.Count(v => v != null && v.GetType() == typeof(Motorcycle));

    Console.WriteLine("Currently these vehicles are parked in the garage: ");
    Console.WriteLine($"Cars: {amountOfCars}");
    Console.WriteLine($"Buses: {amountOfBuses}");
    Console.WriteLine($"Airplanes: {amountOfAirPlanes}");
    Console.WriteLine($"Boats: {amountOfBoats}");
    Console.WriteLine($"Motorcycles: {amountOfMotorcycles}");
  }

    public Vehicle[] SearchForVehiclesBySearchTerm(string type, string color, int wheels)
    {
      if (!string.IsNullOrEmpty(type) && type == "vehicle" && !string.IsNullOrEmpty(color) && wheels != 0)
      {
        return Garage.Where(v => v != null && v.Color == color && v.NumberOfWheels == wheels && v.GetType().BaseType == typeof(Vehicle)).ToArray();  
      } 
      else if (!string.IsNullOrEmpty(type) && type == "vehicle" && !string.IsNullOrEmpty(color))
      {
        return Garage.Where(v => v != null && v.Color == color && v.GetType().BaseType == typeof(Vehicle)).ToArray();  
      } 
      else if (!string.IsNullOrEmpty(type) && type == "vehicle")
      {
        return Garage.Where(v => v != null && v.GetType().BaseType == typeof(Vehicle)).ToArray();  
      } 
      else if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(color) && wheels != 0)
      {
        return Garage.Where(v => v != null && v.Color == color && v.NumberOfWheels == wheels && v.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase)).ToArray();      
      } 
      else if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(color))
      {
        return Garage.Where(v => v != null && v.Color == color && v.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase)).ToArray();  
      } 
      else if (!string.IsNullOrEmpty(type))
      {
        return Garage.Where(v => v != null && v.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase)).ToArray();       
      }

      return null;
    }
}
