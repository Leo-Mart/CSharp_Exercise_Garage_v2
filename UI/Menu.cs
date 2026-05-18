using System;
using Garagev2.Garages;
using Garagev2.Utilities;
using Garagev2.Vehicles;

namespace Garagev2.UI;

public class Menu
{
    public static void DisplaySplash()
  {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("***********************************");
    Console.WriteLine("*********** The Garage ************");
    Console.WriteLine("***********************************\n\n");
    Console.ResetColor();
  }

  public static void DisplayStartMenu()
  {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("********************");
    Console.WriteLine("* Select an action *");
    Console.WriteLine("********************\n");

    Console.WriteLine("1: Create a garage");
    Console.WriteLine("2: Switch between garages");
    Console.WriteLine("3: Load a garage from file");
    Console.WriteLine("9: Quit application");
    Console.ResetColor();
  }

  public static Garage<Vehicle> HandleCreateGarage()
  {
    Console.WriteLine("What is the name of the garage?");
    string name = InputUtils.ValidateStringInput();

    Console.WriteLine("How many vehicles should the garage fit?");

    int garageSize = InputUtils.ValidateIntInput();

    Garage<Vehicle> garage = new Garage<Vehicle>(garageSize, name);

    Console.WriteLine("Would you like to add vehicles as well? yes/no");

    string choice = InputUtils.ValidateStringInput();

    if (choice == "no")
    {
      Console.WriteLine("Ok, no vehicles will be added to the garage at this point.");
      Console.WriteLine("You can add new vehicles in the next menu.");
      return garage;
    }

    Console.WriteLine("How many vehicles would you like to add?.");
    Console.WriteLine($"Enter a number between 1 and {garageSize}");

    int numberOfVehicles = InputUtils.ValidateIntInput();

    if (numberOfVehicles > garageSize)
    {
      ErrorUtils.PrintError("Too large, so automatically set to max garage size");
      numberOfVehicles = garageSize;

    }
    else if (numberOfVehicles < 0)
    {
      ErrorUtils.PrintError("A Garage can't have a negative amount of vehicles, assuming 0.");
      numberOfVehicles = 0;
    }

    for (int i = 1; i <= numberOfVehicles; i++)
    {
      Console.WriteLine($"Entering info for vehicle {i} of {numberOfVehicles}");
      HandleAddNewVehicle(garage);
    }

    Console.WriteLine("New Garage successfully made!\n");
    return garage;

  }

  public static void DisplayGarageMenu(Garage<Vehicle> g)
  {

    bool showSubMenu = true;
    string userSelection;
    do
    {
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("***********************************");
      Console.WriteLine($"*********** {g.Name} ************");
      Console.WriteLine("***********************************\n\n");

      Console.WriteLine("********************");
      Console.WriteLine("* Select an action *");
      Console.WriteLine("********************");

      Console.WriteLine("1: Add new vehicle");
      Console.WriteLine("2: Remove vehicle");
      Console.WriteLine("3: View all vehicles in the garage");
      Console.WriteLine("4: List available vehicle types");
      Console.WriteLine("5: Find vehicle by registrynumber");
      Console.WriteLine("6: Find vehicle by search term");
      Console.WriteLine("7: Save garage information to file.");
      Console.WriteLine("9: Return to garage menu");

      userSelection = InputUtils.ValidateStringInput();

      switch (userSelection)
      {
        case "1":
          HandleAddNewVehicle(g);
          break;
        case "2":
          Console.WriteLine("Enter the registration number of the vehicle you would like to remove: ");
          string regNumber = InputUtils.ValidateStringInput();
          GarageHandler.RemoveVehicleByRegistrationNumber(regNumber, g.Vehicles);
          break;
        case "3":
          GarageHandler.ListAllVehicles(g.Vehicles);
          break;
        case "4":
          GarageHandler.CountVehicleTypes(g.Vehicles);
          break;
        case "5":
          Console.WriteLine("Enter the registration number of the vehicle you would like to find: ");
          regNumber = InputUtils.ValidateStringInput();
          Vehicle foundVehicle = GarageHandler.FindVehicleByRegistrationNumber(regNumber, g.Vehicles);
          if (foundVehicle == null)
          {
            break;
          }
          Console.WriteLine(foundVehicle.DisplayDetails());
          break;
        case "6":

          // Console.WriteLine("Enter your filters");
          // Console.WriteLine("Vehicle type, enter 'none' to ignore type: ");
          // string vehicleType = InputUtils.ValidateStringInput();
          // if (vehicleType == "none")
          // {
          //   vehicleType = "vehicle";
          // }

          // Console.WriteLine("Vehicle color, enter 'none' to ignore color: ");
          // string vehicleColor = InputUtils.ValidateStringInput();
          // if (vehicleColor == "none")
          // {
          //   vehicleColor = "";
          // }

          // Console.WriteLine("Number of wheels: ");
          // int wheels = InputUtils.ValidateIntInput();

          // Vehicle[] foundVehicles = g.SearchForVehiclesBySearchTerm(vehicleType, vehicleColor, wheels);
          // if (foundVehicles.Length == 0)
          // {
          //   Console.WriteLine("found no matches");
          // }
          // else
          // {
          //   Console.WriteLine("Found matches: ");
          //   foreach (var v in foundVehicles)
          //   {
          //     Console.WriteLine(v.DisplayDetails());
          //   }
          // }
          break;
        case "7":
          Console.WriteLine("Saving garage info to file...");
          FileUtils.SaveToFile(g);
          break;
        case "9":
          showSubMenu = false;
          break;
        default:
          Console.WriteLine("Unrecoqnized command, try again.");
          break;

      }
      Console.ResetColor();
    } while (showSubMenu);

  }

  public static void HandleAddNewVehicle(Garage<Vehicle> g)
  {
    Console.WriteLine("What type of vehicle is it? ");
    string vehicleType = InputUtils.ValidateStringInput();

    Console.WriteLine("Enter a registry number for the vehicle: ");
    string registryNumber = InputUtils.ValidateStringInput();

    if (registryNumber.Length > 6)
    {
      Console.WriteLine("That registration number is too long!");
      registryNumber = InputUtils.ValidateStringInput();
    }

    if (GarageHandler.CheckRegistrationNumberUniqueness(registryNumber, g.Vehicles))
    {
      Console.WriteLine("A vehicle with that registration number is already parked in the garage!");
      registryNumber = InputUtils.ValidateStringInput();
    }

    Console.WriteLine("Enter a color for the vehicle: ");
    string color = InputUtils.ValidateStringInput();

    Console.WriteLine("Enter the number of wheels for the vehicle: ");
    int numberOfWheels = InputUtils.ValidateIntInput();

    switch (vehicleType)
    {
      case "car":
        Console.WriteLine("Enter the number of doors for the car: ");
        int numberOfDoors = InputUtils.ValidateIntInput();
        Car newCar = new Car(registryNumber, color, numberOfWheels, numberOfDoors);
        GarageHandler.AddNewVehicle(newCar, g.Vehicles);
        break;
      case "motorcycle":
        Console.WriteLine("Enter the brand of the motorcycle:");
        string mcBrand = InputUtils.ValidateStringInput();
        Motorcycle newMotorcycle = new Motorcycle(registryNumber, color, numberOfWheels, mcBrand);
        GarageHandler.AddNewVehicle(newMotorcycle, g.Vehicles);
        break;
      case "airplane":
        Console.WriteLine("Enter the length of the airplane(use whole numbers): ");
        int planeLength = InputUtils.ValidateIntInput();
        Airplane newAirplane = new Airplane(registryNumber, color, numberOfWheels, planeLength);
        GarageHandler.AddNewVehicle(newAirplane, g.Vehicles);
        break;
      case "bus":
        Console.WriteLine("Enter the amount of seats on the buss: ");
        int amountOfSeats = InputUtils.ValidateIntInput();
        Bus newBus = new Bus(registryNumber, color, numberOfWheels, amountOfSeats);
        GarageHandler.AddNewVehicle(newBus, g.Vehicles);
        break;
      case "boat":
        Console.WriteLine("Does the boat have sails(yes/no)?");
        string choice = InputUtils.ValidateStringInput();
        bool hasSails = false;
        if (choice == "yes")
        {
          hasSails = true;
        }

        Boat newBoat = new Boat(registryNumber, color, numberOfWheels, hasSails);
        GarageHandler.AddNewVehicle(newBoat, g.Vehicles);
        break;

      default:
        ErrorUtils.PrintError("Did not recognize that vehicle type, try again.");
        break;
    }
  }
}
