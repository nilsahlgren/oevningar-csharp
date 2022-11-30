using oevning_5;
using System.Xml.Linq;

namespace test_oevning_5
{
    public class GarageUnitTest
    {
        /// <summary>
        /// Publika Metoder i garage:
        /// 
        /// Capacity()
        /// Park(T vehicle)
        /// Unpark(string regNbr)
        /// 
        /// </summary>
        [Fact]
        public void Capacity_AfterInstantiatingGarage_ReturnsCorrectValue()
        {
            //Arrange
            const int expectedCapacity = 5;
            Garage<Vehicle> testGarage = new Garage<Vehicle>("Q-Park", 5);

            //Act
            int actualCapacity = testGarage.Capacity();

            //Assert
            Assert.Equal(expectedCapacity, actualCapacity);
        }

        [Fact]
        public void Park_InEmptyGarage_ReturnsSuccessMessage()
        {
            //Arrange
            Car testVehicle = new Car("AAA111", "Volvo", "V70", 1999, 10000);
            Garage<Vehicle> testGarage = new Garage<Vehicle>("Q-Park", 5);
            const string expectedMessage = "Vehicle AAA111 was successfully parked at slot 1 in garage Q-Park.";

            //Act
            string returnMessage = testGarage.Park(testVehicle);

            //Assert
            Assert.Equal(expectedMessage, returnMessage);
        }

        [Fact]
        public void Park_InFullGarage_ReturnsFullMessage()
        {
            //Arrange
            Car testVehicle = new Car("AAA111", "Volvo", "V70", 1999, 10000);
            Garage<Vehicle> testGarage = new Garage<Vehicle>("Q-Park", 5);
            Handler testHandler = new Handler();
            testHandler.CurrentGarage = testGarage;
            testHandler.AddFiveGenericVehicles();
            const string expectedMessage = "The garage is full, vehicle AAA111 was not parked in the garage Q-Park.";

            //Act
            string returnMessage = testGarage.Park(testVehicle);

            //Assert
            Assert.Equal(expectedMessage, returnMessage);
        }

        [Fact]
        public void Park_DuplicateInGarage_ReturnsAlreadyParkedMessage()
        {
            //Arrange
            Car testVehicle = new Car("AAA111", "Volvo", "V70", 1999, 10000);
            Garage<Vehicle> testGarage = new Garage<Vehicle>("Q-Park", 5);
            testGarage.Park(testVehicle);
            
            const string expectedMessage = "A car with a registration number equal to aaA111 is already parked in the garage Q-Park.";

            //Act
            Car testVehicle2 = new Car("aaA111", "BMW", "S3", 2005, 12000);
            string returnMessage = testGarage.Park(testVehicle2);

            //Assert
            Assert.Equal(expectedMessage, returnMessage);
        }

        [Fact]
        public void Unpark_AVehicleNotInTheGarage_ReturnsNotFoundMessage()
        {
            //Arrange
            Car testVehicle = new Car("AAA111", "Volvo", "V70", 1999, 10000);
            Garage<Vehicle> testGarage = new Garage<Vehicle>("Q-Park", 5);
            testGarage.Park(testVehicle);

            const string expectedMessage = "Vehicle BBB222 could not be found in garage Q-Park, no vehicle was unparked.";

            //Act
            string returnMessage = testGarage.Unpark("BBB222");

            //Assert
            Assert.Equal(expectedMessage, returnMessage);
        }

        [Fact]
        public void Unpark_AVehicleInTheGarage_ReturnsSuccessMessage()
        {
            //Arrange
            Car testVehicle = new Car("AAA111", "Volvo", "V70", 1999, 10000);
            Garage<Vehicle> testGarage = new Garage<Vehicle>("Q-Park", 5);
            testGarage.Park(testVehicle);

            const string expectedMessage = "Vehicle AAA111 successfully unparked from garage Q-Park";

            //Act
            string returnMessage = testGarage.Unpark("AAA111");

            //Assert
            Assert.Equal(expectedMessage, returnMessage);
        }

    }
}