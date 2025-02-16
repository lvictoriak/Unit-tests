using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.ComponentModel.DataAnnotations;
using Лаб_раб_9;

namespace Unit_tests
{
    [TestClass]
    public class UnitTest1
    {
        // Тест для некорректного значения FuelFlow
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNegativeFuelFlow()
        {
            // Act
            Car car = new Car(-10, 50);
        }

        // Тест для некорректного значения FuelVolume
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNegativeFuelVolume()
        {
            // Act
            Car car = new Car(10, -50);
        }
        //Тесты для проверки работы конструкторов
        [TestMethod]
        public void TestVoidConstructor()
        {
            // Arrange & Act
            Car car = new Car();
            // Assert
            Assert.AreEqual(0, car.FuelFlow);
            Assert.AreEqual(0, car.FuelVolume);
        }
        [TestMethod]
        public void TestConstructor()
        {
            // Arrange & Act
            Car car = new Car(10, 20);
            // Assert
            Assert.AreEqual(10, car.FuelFlow);
            Assert.AreEqual(20, car.FuelVolume);
        }
        [TestMethod]
        public void TestCopyConstructor()
        {
            // Arrange
            Car expected = new Car(10, 15);
            // Act
            Car actual = new Car(expected);
            // Assert
            Assert.AreNotSame(expected, actual);
            Assert.AreEqual(expected.FuelVolume, actual.FuelVolume);
            Assert.AreEqual(expected.FuelFlow, actual.FuelFlow);
        }
        // Тест для конструктора копирования с null
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCopyConstructorWithNull()
        {
            // Act
            Car car = new Car(null); 
        }
        //Тесты для проверки вычисления запаса хода
        [TestMethod]
        public void TestCalculateRange()
        {
            // Arrange
            Car car = new Car(10, 40);
            double expected = car.CalculateRange();
            // Act
            double actual = 40 / 10 * 100;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestStCalculateRange()
        {
            // Arrange
            double expected = Car.CalculateRangeStatic(new Car(10, 40));
            // Act
            double actual = 40/10 * 100;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        //Унарные операции
        [TestMethod]
        public void TestIncrementOperator()
        {
            // Arrange
            Car car = new Car(10, 20);
            // Act
            Car car2 = car++;
            // Assert
            Assert.AreEqual(10.1, car.FuelFlow);
        }
        [TestMethod]
        public void TestDecrementOperator()
        {
            // Arrange
            Car car = new Car(10, 10);
            // Act
            Car car2 = car--;
            // Assert
            Assert.AreEqual(9, car.FuelVolume);
        }
        //Операции приведения типа
        [TestMethod]
        public void TestExplicitBool_True()
        {
            // Arrange
            Car car = new Car(10, 10);
            // Act
            bool actual = (bool)car;
            // Assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void TestExplicitBool_False()
        {
            // Arrange
            Car car = new Car(10, 4);
            // Act
            bool actual = (bool)car;
            // Assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void TestImplicitDouble_True()
        {
            // Arrange
            Car car = new Car(10, 60);
            double expected = Logic.MathematicalRound((60d - 5d) / 10d, 3);
            // Act
            double actual = (double)car;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestImplicitDouble_False()
        {
            // Arrange
            Car car = new Car(10, 2);
            // Act
            double actual = (double)car;
            // Assert
            Assert.AreEqual(-1, actual);
        }
        //Бинарные операции
        [TestMethod]
        public void TestLeftAddOperator()
        {
            // Arrange
            Car car = new Car(10, 10);
            double litersToAdd = 5;
            double expected = 15;
            // Act
            car = car + litersToAdd;
            double actual = car.FuelVolume;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestRightAddOperator()
        {
            // Arrange
            Car car = new Car(10, 15);
            double litersToMin = 5;
            double expected = 10;
            // Act
            car = litersToMin + car;
            double actual = car.FuelVolume;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestEqualityOperator_True()
        {
            // Arrange
            Car car1 = new Car(10, 15);
            Car car2 = new Car(10, 15);
            // Act
            // Assert
            Assert.IsFalse(car1 == car2);
        }
        [TestMethod]
        public void TestEqualityOperator_False()
        {
            // Arrange
            Car car1 = new Car(10, 15);
            Car car2 = new Car(10, 10);
            // Act
            // Assert
            Assert.IsFalse(car1 == car2);
        }
        [TestMethod]
        public void TestInequalityOperator_True()
        {
            // Arrange
            Car car1 = new Car(5, 20);
            Car car2 = new Car(10, 15);
            // Act
            // Assert
            Assert.IsTrue(car1 != car2);
        }
        [TestMethod]
        public void TestInequalityOperator_False()
        {
            // Arrange
            Car car1 = new Car(10, 15);
            Car car2 = new Car(10, 15);
            // Act
            // Assert
            Assert.IsTrue(car1 != car2);
        }
        [TestMethod]
        public void TestEqualMethod_True()
        {
            // Arrange
            Car car1 = new Car(10, 15);
            Car car2 = new Car(10, 15);
            // Act
            // Assert
            Assert.IsTrue(car1.Equals(car2));
        }
        [TestMethod]
        public void TestEqualMethod_False()
        {
            // Arrange
            Car car1 = new Car(10, 15);
            Car car2 = new Car(5, 15);
            // Act
            // Assert
            Assert.IsFalse(car1.Equals(car2));
        }
        //Тесты для проверки работы конструкторов
        [TestMethod]
        public void TestDefaultConstructor()
        {
            // Arrange & Act
            CarArray carArray = new CarArray();

            // Assert
            Assert.AreEqual(0, carArray.Length);
        }
            [TestMethod]
        public void TestArrayConstructor_Length()
        {
            // Arrange
            int expected = 5;
            // Act
            CarArray actual = new CarArray(5);
            // Assert
            Assert.AreEqual(expected, actual.Length);
        }
        [TestMethod]
        public void TestArrayCopyConstructor()
        {
            // Arrange
            CarArray expected = new CarArray(2);
            expected[0] = new Car(10, 10);
            expected[1] = new Car(10, 20);
            // Act
            CarArray actual = new CarArray(expected);
            // Assert
            Assert.AreEqual(expected.Length, actual.Length);
            Assert.AreEqual(expected[0].FuelVolume, actual[0].FuelVolume);
            Assert.AreEqual(expected[0].FuelFlow, actual[0].FuelFlow);
            Assert.AreEqual(expected[1].FuelVolume, actual[1].FuelVolume);
            Assert.AreEqual(expected[1].FuelFlow, actual[1].FuelFlow);
        }
        [TestMethod]
        public void TestRandomConstructor()
        {
            // Arrange & Act
            int length = 5;
            CarArray cars = new CarArray(length);
            // Assert
            Assert.AreEqual(length, cars.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.IsNotNull(cars[i]);
                Assert.IsTrue(cars[i].FuelFlow >= 5 && cars[i].FuelFlow <= 20);
                Assert.IsTrue(cars[i].FuelVolume >= 10 && cars[i].FuelVolume <= 70);
            }
        }
        [TestMethod]
        public void TestManualConstructor()
        {
            // Arrange
            int length = 3;
            double[] flows = { 8, 7.2, 10 };
            double[] volumes = { 42.5, 50, 20 };
            // Act
            CarArray cars = new CarArray(length, flows, volumes);
            // Assert
            Assert.AreEqual(length, cars.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.AreEqual(flows[i], cars[i].FuelFlow);
                Assert.AreEqual(volumes[i], cars[i].FuelVolume);
            }
        }

        [TestMethod]
        public void TestIndexer_ValidIndex()
        {
            // Arrange
            CarArray carArray = new CarArray(2);
            carArray[0] = new Car(10, 10);
            carArray[1] = new Car(15, 20);
            // Act
            Car actual0 = carArray[0];
            Car actual1 = carArray[1];
            // Assert
            Assert.AreEqual(10, actual0.FuelFlow);
            Assert.AreEqual(15, actual1.FuelFlow);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexer_OutOfRangeIndex()
        {
            // Arrange
            CarArray carArray = new CarArray(2);
            // Act
            Car car = carArray[2];
        }
        [TestMethod]
        public void TestPrintInfo()
        {
            // Arrange
            Car car = new Car(10, 15);
            string expected = "Расход топлива: 10 л/100км. Объем топлива: 15 л. Запас хода: 150 км.";
            // Act
            string actual = car.PrintInfo(car);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        //Тесты для функции нахождения машины с наименьшим запасом хода
        // Тест для пустого массива
        [TestMethod]
        public void TestEmptyArray()
        {
            // Arrange
            CarArray cars = new CarArray(0);
            // Act
            Car result = Лаб_раб_9.Program.FindCarMinimumRange(cars);
            // Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestSingleCarArray()
        {
            // Arrange
            CarArray cars = new CarArray(1);
            cars[0] = new Car(10, 50);
            // Act
            Car result = Лаб_раб_9.Program.FindCarMinimumRange(cars);
            // Assert
            Assert.AreEqual(cars[0], result);
        }
        [TestMethod]
        public void TestMultipleCarsArray()
        {
            // Arrange
            CarArray cars = new CarArray(2);
            cars[0] = new Car(10, 50);
            cars[1] = new Car(10, 40);  
            // Act
            Car result = Лаб_раб_9.Program.FindCarMinimumRange(cars);
            // Assert
            Assert.AreEqual(cars[1], result); 
        }
    }
}