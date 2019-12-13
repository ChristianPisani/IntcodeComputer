using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntCodeComputer;

namespace IntCodeComputerTests {
    [TestClass]
    public class Day1Tests {
        [TestMethod]
        public void Add1And1() {
            Computer computer = new Computer(new long[] { 1, 0, 0, 0, 99 });
            computer.Calculate();

            Assert.AreEqual(computer.Memory[0], 2);
        }

        [TestMethod]
        public void Multiply3And2() {
            Computer computer = new Computer(new long[] { 2, 3, 0, 3, 99 });
            computer.Calculate();

            Assert.AreEqual(computer.Memory[3], 6);
        }

        [TestMethod]
        public void Multiply99And99() {
            Computer computer = new Computer(new long[] { 2, 4, 4, 5, 99, 0 });
            computer.Calculate();

            Assert.AreEqual(computer.Memory[5], 9801);
        }

        [TestMethod]
        public void SomethingThatBecomes30() {
            Computer computer = new Computer(new long[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 });
            computer.Calculate();

            Assert.AreEqual(computer.Memory[0], 30);
        }

        /*[TestMethod]
        public void InputsProduce19690720() {            
            for (int x = 0; x < 100; x++) {
                for (int y = 0; y < 100; y++) {
                    Computer computer = new Computer(new long[] { 1, x, y, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 1, 6, 19, 1, 9, 19, 23, 2, 23, 10, 27, 1, 27, 5, 31, 1, 31, 6, 35, 1, 6, 35, 39, 2, 39, 13, 43, 1, 9, 43, 47, 2, 9, 47, 51, 1, 51, 6, 55, 2, 55, 10, 59, 1, 59, 5, 63, 2, 10, 63, 67, 2, 9, 67, 71, 1, 71, 5, 75, 2, 10, 75, 79, 1, 79, 6, 83, 2, 10, 83, 87, 1, 5, 87, 91, 2, 9, 91, 95, 1, 95, 5, 99, 1, 99, 2, 103, 1, 103, 13, 0, 99, 2, 14, 0, 0 });
                    computer.Calculate();

                    if (computer.Memory[0] == 19690720) {
                        Assert.AreEqual((100 * x) + y, 6979);
                        return;
                    }
                }
            }
        }*/
    }
}
