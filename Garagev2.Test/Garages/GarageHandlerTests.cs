using System;

using Garagev2.Garages;
using Garagev2.Vehicles;


namespace Garagev2.Test.Garages;



public class GarageHandlerTests
{
  private readonly Garage<Vehicle> garage;
  private readonly GarageHandler handler;
public GarageHandlerTests()
{
  garage = new Garage<Vehicle>(5, "Test Garage");
  handler = new GarageHandler(garage);
}

  [Fact]
  public void ShouldCreateNewHandlerWithGarage()
  {
    Assert.NotNull(garage);
    Assert.NotNull(handler);
    Assert.Equal("Test Garage", garage.Name);
  }

  [Fact]
  public void ShouldCreateNewVehicle()
  {
    Car car = new Car("abc123", "black", 4, 4);

    handler.AddNewVehicle(car);

    Assert.NotEmpty(garage);
    Assert.Equal("abc123", garage.Vehicles[0].RegistryNumber);
  }

  [Fact]
  public void ShouldFindMatchingVehicleByRegNumber()
  {
    Car car = new Car("abc123", "black", 4, 4);

    handler.AddNewVehicle(car);

    var foundVehicle = handler.FindVehicleByRegistrationNumber("abc123");

    Assert.NotEmpty(garage);
    Assert.Equal(car, foundVehicle);
  }

  [Fact]
  public void ShouldNotFindAVehicleByRegNumber()
  {   
    Car car = new Car("abc123", "black", 4, 4);

    handler.AddNewVehicle(car);

    var foundVehicle = handler.FindVehicleByRegistrationNumber("123abc");

    Assert.Null(foundVehicle);
    Assert.Equal("abc123", garage.Vehicles[0].RegistryNumber);


  }


}
