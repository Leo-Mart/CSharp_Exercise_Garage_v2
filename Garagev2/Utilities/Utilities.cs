using System;
using System.Text;
using Garagev2.Garages;
using Garagev2.Vehicles;

namespace Garagev2.Utilities;

internal class InputUtils
{

  public static string ValidateStringInput()
  {
    Console.Write(">  ");
    string? userInput = Console.ReadLine() ?? "";

    if (string.IsNullOrEmpty(userInput))
    {
      ErrorUtils.PrintError("Please enter a valid choice!");
      ValidateStringInput();
    }

    return userInput.ToLower().Trim();
  }

  public static int ValidateIntInput()
  {
    Console.Write(">  ");
    bool success = int.TryParse(Console.ReadLine(), out int userInput);


    if (!success)
    {
      ErrorUtils.PrintError("Please enter a valid choice!");
      ValidateIntInput();
    }

    return userInput;
  }

}

internal class ErrorUtils
{
  public static void PrintError(string errMsg)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\n{errMsg}\n");
    Console.ResetColor();
  }
}

internal class FileUtils
{
  internal static void SaveToFile(Garage<Vehicle> garage)
  {
    string directory = @"./../../../";
    string filename = $"{garage.Name}.txt";
    string path = $"{directory}{filename}";

    StringBuilder sb = new StringBuilder();

    sb.Append($"name:{garage.Name};size:{garage.Vehicles.Length};");
    sb.Append(Environment.NewLine);
    foreach (var vehicle in garage)
    {
      if (vehicle == null)
        continue;

      sb.Append(vehicle.PrintFileDetails());
      sb.Append(Environment.NewLine);
    }

    File.WriteAllText(path, sb.ToString());

    Console.WriteLine("Saved the garage to file!");

  }

  internal static GarageHandler LoadGaragesFromFile(string fileName)
  {
    string path = @$"./../../../{fileName}.txt";
    try
    {
      if (File.Exists(path))
      {
        string[] garagesString = File.ReadAllLines(path);
        string[] garageInfo = garagesString[0].Split(';');
        string garageName = garageInfo[0].Substring(garageInfo[0].IndexOf(':') + 1);
        int garageSize = int.Parse(garageInfo[1].Substring(garageInfo[1].IndexOf(':') + 1));

        Garage<Vehicle> garage = new Garage<Vehicle>(garageSize, garageName);
        GarageHandler handler = new GarageHandler(garage);

        for (int i = 1; i < garagesString.Length; i++)
        {
          string[] vehicleSplit = garagesString[i].Split(';');
          string vehicleType = vehicleSplit[0].Substring(vehicleSplit[0].IndexOf(':') + 1).ToLower();
          string regNumber = vehicleSplit[1].Substring(vehicleSplit[1].IndexOf(':') + 1);
          string color = vehicleSplit[2].Substring(vehicleSplit[2].IndexOf(':') + 1);
          int numberOfWheels = int.Parse(vehicleSplit[3].Substring(vehicleSplit[3].IndexOf(':') + 1));

          Vehicle vehicle = null;

          switch (vehicleType)
          {
            case "car":
              int numberOfDoors = int.Parse(vehicleSplit[4].Substring(vehicleSplit[4].IndexOf(':') + 1));
              vehicle = new Car(regNumber, color, numberOfWheels, numberOfDoors);
              break;
            case "motorcycle":
              string brand = vehicleSplit[4].Substring(vehicleSplit[4].IndexOf(':') + 1);
              vehicle = new Motorcycle(regNumber, color, numberOfWheels, brand);
              break;
            case "bus":
              int seats = int.Parse(vehicleSplit[4].Substring(vehicleSplit[4].IndexOf(':') + 1));
              vehicle = new Bus(regNumber, color, numberOfWheels, seats);
              break;
            case "boat":
              bool hasSails = bool.Parse(vehicleSplit[4].Substring(vehicleSplit[4].IndexOf(':') + 1));
              vehicle = new Boat(regNumber, color, numberOfWheels, hasSails);
              break;
            case "airplane":
              int length = int.Parse(vehicleSplit[4].Substring(vehicleSplit[4].IndexOf(':') + 1));
              vehicle = new Airplane(regNumber, color, numberOfWheels, length);
              break;
          }
          handler.AddNewVehicle(vehicle);
        }

        Console.WriteLine($"Added {garage.Name}");
        return handler;
      } 
    }
    catch (FileNotFoundException e)
    {
      ErrorUtils.PrintError("Could not find file");
      Console.WriteLine(e.Message);
    }
    catch (Exception e)
    {
      ErrorUtils.PrintError("Something went wrong while loading the file.");
      Console.WriteLine(e.Message);
    }

    return null;
  }

}
