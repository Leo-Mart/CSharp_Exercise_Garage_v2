using System;
using Garagev2.Utilities;
using Garagev2.Vehicles;

namespace Garagev2.Garages;

public static class GarageHandler
{

  public static void ListAllVehicles(Vehicle[] vehicles)
  {
    if (CheckForAvailableSpaces(vehicles) == vehicles.Length)
    {
      ErrorUtils.PrintError("There are currently no vehicles in the garage!");

    }

    Console.WriteLine("Current Vehicles in the garage: ");
    foreach (var v in vehicles)
    {
      if (v == null)
      {
        continue;
      }
      Console.WriteLine(v.DisplayDetails());

    }
  }

  public static void AddNewVehicle(Vehicle newVehicle, Vehicle[] vehicles)
  {
    int availableSpace = CheckForAvailableSpaces(vehicles);
    if (availableSpace == 0)
    {
      Console.WriteLine("Oh no, the garage is full!");
    }

    for (int i = 0; i <= vehicles.Length; i++)
    {
      if (vehicles[i] == null)
      {
        vehicles[i] = newVehicle;
        Console.WriteLine("Vehicle was added successfully!");
        return;
      }
      else
      {
        continue;
      }
    }
  }

  public static Vehicle FindVehicleByRegistrationNumber(string regNumber, Vehicle[] vehicles)
  {
    try
    {
      var foundVehicle = vehicles.First(v => v != null && v.RegistryNumber == regNumber);
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

  public static void RemoveVehicleByRegistrationNumber(string regNumber, Vehicle[] vehicles)
  {
    var foundVehicle = vehicles.First(v => v != null && v.RegistryNumber == regNumber);
    if (foundVehicle == null)
    {
      ErrorUtils.PrintError("Could not find a vehicle with that registration number.");
      return;
    }
    int index = vehicles.IndexOf(foundVehicle);

    vehicles[index] = null;

    Console.WriteLine($"Vehicle with registration number: {regNumber} has been removed");
  }

  public static int CheckForAvailableSpaces(Vehicle[] vehicles)
  {
    Vehicle[] availableSpots = Array.FindAll(vehicles, v => v == null);
    return availableSpots.Length;

  }

  public static bool CheckRegistrationNumberUniqueness(string regNumber, Vehicle[] vehicles)
  {
    foreach (var v in vehicles)
    {
      var exists = vehicles.Any(v => v.RegistryNumber == regNumber);
      return exists;
    }
    return false;
  }

  public static void CountVehicleTypes(Vehicle[] vehicles)
  {
    int amountOfCars = vehicles.Count(v => v != null && v.GetType() == typeof(Car));
    int amountOfBuses = vehicles.Count(v => v != null && v.GetType() == typeof(Bus));
    int amountOfAirPlanes = vehicles.Count(v => v != null && v.GetType() == typeof(Airplane));
    int amountOfBoats = vehicles.Count(v => v != null && v.GetType() == typeof(Boat));
    int amountOfMotorcycles = vehicles.Count(v => v != null && v.GetType() == typeof(Motorcycle));

    Console.WriteLine("Currently these vehicles are parked in the garage: ");
    Console.WriteLine($"Cars: {amountOfCars}");
    Console.WriteLine($"Buses: {amountOfBuses}");
    Console.WriteLine($"Airplanes: {amountOfAirPlanes}");
    Console.WriteLine($"Boats: {amountOfBoats}");
    Console.WriteLine($"Motorcycles: {amountOfMotorcycles}");
  }

  //   public Vehicle[] SearchForVehiclesBySearchTerm(string type, string color, int wheels)
  //   {


  //     if (!string.IsNullOrEmpty(type) && type == "vehicle" && !string.IsNullOrEmpty(color) && wheels != 0)
  //     {
  //       return Array.FindAll(Vehicles, v => v != null && v.Color == color && v.NumberOfWheels == wheels && v.GetType().BaseType == typeof(Vehicle));  
  //     } 
  //     else if (!string.IsNullOrEmpty(type) && type == "vehicle" && !string.IsNullOrEmpty(color))
  //     {
  //       return Array.FindAll(Vehicles, v => v != null && v.Color == color && v.GetType().BaseType == typeof(Vehicle));  
  //     } 
  //     else if (!string.IsNullOrEmpty(type) && type == "vehicle")
  //     {
  //       return Array.FindAll(Vehicles, v => v != null && v.GetType().BaseType == typeof(Vehicle));  
  //     } 
  //     else if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(color) && wheels != 0)
  //     {
  //       return Array.FindAll(Vehicles, v => v != null && v.Color == color && v.NumberOfWheels == wheels && v.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase));      
  //     } 
  //     else if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(color))
  //     {
  //       return Array.FindAll(Vehicles, v => v != null && v.Color == color && v.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase));  
  //     } 
  //     else if (!string.IsNullOrEmpty(type))
  //     {
  //       return Array.FindAll(Vehicles, v => v != null && v.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase));       
  //     }

  //     return null;
  //   }
}
