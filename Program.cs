using Garagev2.Garages;
using Garagev2.UI;
using Garagev2.Utilities;
using Garagev2.Vehicles;



Garage<Vehicle> garageEnum = new Garage<Vehicle>(5, "test-garaage");

Car Car1 = new Car("abc123", "black", 4, 4);
Car Car2 = new Car("123abc", "black", 3, 3);
Airplane Plane1 = new Airplane("113131", "white", 3, 100);
Motorcycle Motorcycle1 = new Motorcycle("adfadad", "purple", 3, "hojda");

GarageHandler.AddNewVehicle(Car1, garageEnum.Vehicles);
GarageHandler.AddNewVehicle(Car2, garageEnum.Vehicles);
GarageHandler.AddNewVehicle(Plane1, garageEnum.Vehicles);
GarageHandler.AddNewVehicle(Motorcycle1, garageEnum.Vehicles);

Menu.DisplayGarageMenu(garageEnum);

// foreach (Car car in garageEnum)
// {
//   Console.WriteLine(car.DisplayDetails());
// }
// Garage[] garages = new Garage[3];
// int currIndex = 0;
// Menu.DisplaySplash();

// string userSelection;
// do
// {
//   Menu.DisplayStartMenu(); 


//   userSelection = InputUtils.ValidateStringInput();

//   switch (userSelection)
//   {
//     case "1":
//       Garage newGarage = Menu.HandleCreateGarage();
//       if (currIndex + 1 > garages.Length)
//       {
//         Array.Resize(ref garages, garages.Length + 5);
//       }
//       garages[currIndex] = newGarage;
//       currIndex++;
//       Menu.DisplayGarageMenu(newGarage);
//       break;
//     case "2":
//       Console.WriteLine("Current garages: ");
//       int emptyGarages = 0;
//       for (int i = 0; i < garages.Length; i++)
//       {
//         if (garages[i] == null)
//         {
//           emptyGarages++;
//           continue;
//         }      

//         Console.WriteLine($"{i}. {garages[i].Name}");
//       }
//       if (emptyGarages == garages.Length)
//       {
//         Console.WriteLine("No garages in memory, create some first.");
//         break;
//       }
//       Console.WriteLine("Which garage do you wish to load?");
//       Console.WriteLine("Enter it's number: ");      
      
//       int choice = InputUtils.ValidateIntInput();

//       Menu.DisplayGarageMenu(garages[choice]);
//       break;
//     case "3":
//       Console.WriteLine("Enter the filename of the file you want to import: ");
//       string fileName = InputUtils.ValidateStringInput();

//       Garage loadedGarage = FileUtils.LoadGaragesFromFile(fileName);

//       if (currIndex + 1 > garages.Length)
//       {
//         Array.Resize(ref garages, garages.Length + 5);
//       }
//       garages[currIndex] = loadedGarage;
//       currIndex++;
//       break;
//     case "9":
//       break;
//     default:
//       ErrorUtils.PrintError("Unrecoqnized command, try again.");
//       break;
//   }
  
// } while (userSelection !="9");


