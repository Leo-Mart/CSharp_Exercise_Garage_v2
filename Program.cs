using Garagev2.Garages;
using Garagev2.UI;
using Garagev2.Utilities;
using Garagev2.Vehicles;


// Garage<Vehicle> garageEnum = new Garage<Vehicle>(5, "test-garaage");
// GarageHandler handler = new GarageHandler(garageEnum);

// Car Car1 = new Car("abc123", "black", 4, 4);
// Car Car2 = new Car("123abc", "black", 3, 3);
// Airplane Plane1 = new Airplane("11313", "white", 3, 100);
// Motorcycle Motorcycle1 = new Motorcycle("adfada", "purple", 3, "hojda");
// Boat Boat1 = new Boat("adf321", "purple", 3, true);

// handler.AddNewVehicle(Car1);
// handler.AddNewVehicle(Car2);
// handler.AddNewVehicle(Plane1);
// handler.AddNewVehicle(Motorcycle1);
// handler.AddNewVehicle(Boat1);

GarageHandler[] garages = new GarageHandler[3];
int currIndex = 0;
Menu.DisplaySplash();

string userSelection;
do
{
  Menu.DisplayStartMenu(); 


  userSelection = InputUtils.ValidateStringInput();

  switch (userSelection)
  {
    case "1":
      GarageHandler newGarage = Menu.HandleCreateGarage();
      if (currIndex + 1 > garages.Length)
      {
        Array.Resize(ref garages, garages.Length + 5);
      }
      garages[currIndex] = newGarage;
      currIndex++;
      Menu.DisplayGarageMenu(newGarage);
      break;
    case "2":
      Console.WriteLine("Current garages: ");
      int emptyGarages = 0;
      for (int i = 0; i < garages.Length; i++)
      {
        if (garages[i] == null)
        {
          emptyGarages++;
          continue;
        }      

        Console.WriteLine($"{i}. {garages[i].Garage.Name}");
      }
      if (emptyGarages == garages.Length)
      {
        Console.WriteLine("No garages in memory, create some first.");
        break;
      }
      Console.WriteLine("Which garage do you wish to load?");
      Console.WriteLine("Enter it's number: ");      
      
      int choice = InputUtils.ValidateIntInput();

      Menu.DisplayGarageMenu(garages[choice]);
      break;
    case "3":
      Console.WriteLine("Enter the filename of the file you want to import: ");
      string fileName = InputUtils.ValidateStringInput();

      GarageHandler loadedGarage = FileUtils.LoadGaragesFromFile(fileName);

      if (currIndex + 1 > garages.Length)
      {
        Array.Resize(ref garages, garages.Length + 5);
      }
      garages[currIndex] = loadedGarage;
      currIndex++;
      break;
    case "9":
      break;
    default:
      ErrorUtils.PrintError("Unrecoqnized command, try again.");
      break;
  }
  
} while (userSelection !="9");


