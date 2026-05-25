using System;
using Garagev2.Garages;
using Garagev2.Vehicles;
using Garagev2.Utilities;

namespace Garagev2.Test.Utilities;

public class UtilitiesTest : IDisposable
{
  public void Dispose()
  {
    File.Delete(@"./../../../Test_Garage.txt");
  }

  [Fact]
  public void ShouldSaveGarageToFile()
  {
    Garage<Vehicle> garage = new Garage<Vehicle>(5, "Test_Garage");
    GarageHandler handler = new GarageHandler(garage);

    Car car1 = new Car("abc123", "black", 4, 4);
    Motorcycle mc1 = new Motorcycle("123abc", "white", 2, "Harley Davidson");

    handler.AddNewVehicle(car1);
    handler.AddNewVehicle(mc1);

    FileUtils.SaveToFile(handler.Garage);

    Assert.True(File.Exists(@"./../../../Test_Garage.txt"));   
  }

  [Fact]
  public void ShouldLoadGarageFromFile()
  {
    Garage<Vehicle> garage = new Garage<Vehicle>(5, "Test_Garage");
    GarageHandler handler = new GarageHandler(garage);

    Car car1 = new Car("abc123", "black", 4, 4);
    Motorcycle mc1 = new Motorcycle("123abc", "white", 2, "Harley Davidson");

    handler.AddNewVehicle(car1);
    handler.AddNewVehicle(mc1);

    FileUtils.SaveToFile(handler.Garage);

    Assert.True(File.Exists(@"./../../../Test_Garage.txt"));

    var loadedHandler = FileUtils.LoadGaragesFromFile("Test_Garage");

    Assert.NotNull(loadedHandler);
    Assert.Equal("abc123", loadedHandler.Garage.Vehicles[0].RegistryNumber );
    Assert.Collection(loadedHandler.Garage,
      item1 => Assert.NotSame(car1, item1),
      item2 => Assert.NotSame(mc1, item2)
      );

  }
}
