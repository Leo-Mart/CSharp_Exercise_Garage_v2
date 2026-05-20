using Garagev2.Garages;
using Garagev2.UI;
using Garagev2.Utilities;

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


