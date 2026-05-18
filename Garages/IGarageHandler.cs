using System;
using Garagev2.Vehicles;

namespace Garagev2.Garages;

public interface IGarageHandler
{
  void ListAllVehicles();
  void AddNewVehicle(Vehicle newVehicle);
  Vehicle FindVehicleByRegistrationNumber(string regNumber);
  void RemoveVehicleByRegistrationNumber(string regNumber);
  int CheckForAvailableSpaces();
  bool CheckRegistrationNumberUniqueness(string regNumber);
  void CountVehicleTypes();
}
