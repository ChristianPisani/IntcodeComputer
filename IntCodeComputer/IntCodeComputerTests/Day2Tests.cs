using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntCodeComputer;
using System.Collections.Generic;

namespace IntCodeComputerTests {
    [TestClass]
    public class Day2Tests {
        [TestMethod]
        public void Multiply33And3WithImmidiate() {
            Computer computer = new Computer(new long[] { 1002, 4, 3, 4, 33 });
            computer.Calculate();

            Assert.AreEqual(computer.Memory[4], 99);
        }

        [TestMethod]
        public void Day2DiagnosticCode1() {
            Computer computer = new Computer(new long[] { 3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1102, 16, 13, 225, 1001, 88, 68, 224, 101, -114, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 2, 224, 1, 223, 224, 223, 1101, 8, 76, 224, 101, -84, 224, 224, 4, 224, 102, 8, 223, 223, 101, 1, 224, 224, 1, 224, 223, 223, 1101, 63, 58, 225, 1102, 14, 56, 224, 101, -784, 224, 224, 4, 224, 102, 8, 223, 223, 101, 4, 224, 224, 1, 223, 224, 223, 1101, 29, 46, 225, 102, 60, 187, 224, 101, -2340, 224, 224, 4, 224, 102, 8, 223, 223, 101, 3, 224, 224, 1, 224, 223, 223, 1102, 60, 53, 225, 1101, 50, 52, 225, 2, 14, 218, 224, 101, -975, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 3, 224, 1, 223, 224, 223, 1002, 213, 79, 224, 101, -2291, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 2, 224, 1, 223, 224, 223, 1, 114, 117, 224, 101, -103, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 4, 224, 224, 1, 224, 223, 223, 1101, 39, 47, 225, 101, 71, 61, 224, 101, -134, 224, 224, 4, 224, 102, 8, 223, 223, 101, 2, 224, 224, 1, 224, 223, 223, 1102, 29, 13, 225, 1102, 88, 75, 225, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 1107, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 329, 1001, 223, 1, 223, 108, 677, 677, 224, 1002, 223, 2, 223, 1005, 224, 344, 101, 1, 223, 223, 1008, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 359, 1001, 223, 1, 223, 1107, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 374, 1001, 223, 1, 223, 8, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 389, 101, 1, 223, 223, 8, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 404, 101, 1, 223, 223, 7, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 419, 101, 1, 223, 223, 7, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 434, 101, 1, 223, 223, 1108, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 449, 1001, 223, 1, 223, 108, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 464, 101, 1, 223, 223, 1108, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 479, 101, 1, 223, 223, 1007, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 494, 1001, 223, 1, 223, 107, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 509, 1001, 223, 1, 223, 1008, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 524, 1001, 223, 1, 223, 1007, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 539, 101, 1, 223, 223, 1108, 677, 677, 224, 102, 2, 223, 223, 1005, 224, 554, 1001, 223, 1, 223, 1008, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 569, 101, 1, 223, 223, 1107, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 584, 1001, 223, 1, 223, 7, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 599, 101, 1, 223, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 614, 101, 1, 223, 223, 107, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 629, 1001, 223, 1, 223, 107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 644, 101, 1, 223, 223, 1007, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 659, 101, 1, 223, 223, 8, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 674, 1001, 223, 1, 223, 4, 223, 99, 226 });
            var output = computer.Calculate(new List<int>() { 1 });

            Assert.AreEqual(output.output, 4601506);
        }

        [TestMethod]
        public void Day2DiagnosticCode5() {
            Computer computer = new Computer(new long[] { 3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1102, 16, 13, 225, 1001, 88, 68, 224, 101, -114, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 2, 224, 1, 223, 224, 223, 1101, 8, 76, 224, 101, -84, 224, 224, 4, 224, 102, 8, 223, 223, 101, 1, 224, 224, 1, 224, 223, 223, 1101, 63, 58, 225, 1102, 14, 56, 224, 101, -784, 224, 224, 4, 224, 102, 8, 223, 223, 101, 4, 224, 224, 1, 223, 224, 223, 1101, 29, 46, 225, 102, 60, 187, 224, 101, -2340, 224, 224, 4, 224, 102, 8, 223, 223, 101, 3, 224, 224, 1, 224, 223, 223, 1102, 60, 53, 225, 1101, 50, 52, 225, 2, 14, 218, 224, 101, -975, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 3, 224, 1, 223, 224, 223, 1002, 213, 79, 224, 101, -2291, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 2, 224, 1, 223, 224, 223, 1, 114, 117, 224, 101, -103, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 4, 224, 224, 1, 224, 223, 223, 1101, 39, 47, 225, 101, 71, 61, 224, 101, -134, 224, 224, 4, 224, 102, 8, 223, 223, 101, 2, 224, 224, 1, 224, 223, 223, 1102, 29, 13, 225, 1102, 88, 75, 225, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 1107, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 329, 1001, 223, 1, 223, 108, 677, 677, 224, 1002, 223, 2, 223, 1005, 224, 344, 101, 1, 223, 223, 1008, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 359, 1001, 223, 1, 223, 1107, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 374, 1001, 223, 1, 223, 8, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 389, 101, 1, 223, 223, 8, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 404, 101, 1, 223, 223, 7, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 419, 101, 1, 223, 223, 7, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 434, 101, 1, 223, 223, 1108, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 449, 1001, 223, 1, 223, 108, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 464, 101, 1, 223, 223, 1108, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 479, 101, 1, 223, 223, 1007, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 494, 1001, 223, 1, 223, 107, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 509, 1001, 223, 1, 223, 1008, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 524, 1001, 223, 1, 223, 1007, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 539, 101, 1, 223, 223, 1108, 677, 677, 224, 102, 2, 223, 223, 1005, 224, 554, 1001, 223, 1, 223, 1008, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 569, 101, 1, 223, 223, 1107, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 584, 1001, 223, 1, 223, 7, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 599, 101, 1, 223, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 614, 101, 1, 223, 223, 107, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 629, 1001, 223, 1, 223, 107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 644, 101, 1, 223, 223, 1007, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 659, 101, 1, 223, 223, 8, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 674, 1001, 223, 1, 223, 4, 223, 99, 226 });
            var output = computer.Calculate(new List<int>() { 5 });

            Assert.AreEqual(output.output, 5525561);
        }

        [TestMethod]
        public void InputIsEqualTo8PositionMode() {
            var input = new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };

            Computer computer = new Computer(input);
            var outputLess = computer.Calculate(new List<int>() { 1 });

            computer = new Computer(input);
            var outputEqual = computer.Calculate(new List<int>() { 8 });

            computer = new Computer(input);
            var outputMore = computer.Calculate(new List<int>() { 9 });

            Assert.AreEqual(outputLess.output, 0);
            Assert.AreEqual(outputEqual.output, 1);
            Assert.AreEqual(outputMore.output, 0);
        }

        [TestMethod]
        public void InputIsLessThan8PositionMode() {
            var input = new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };

            Computer computer = new Computer(input);
            var outputLess = computer.Calculate(new List<int>() { 1 });

            computer = new Computer(input);
            var outputLess2 = computer.Calculate(new List<int>() { 7 });

            computer = new Computer(input);
            var outputEqual = computer.Calculate(new List<int>() { 8 });

            computer = new Computer(input);
            var outputMore = computer.Calculate(new List<int>() { 9 });

            Assert.AreEqual(outputLess.output, 1);
            Assert.AreEqual(outputLess2.output, 1);
            Assert.AreEqual(outputEqual.output, 0);
            Assert.AreEqual(outputMore.output, 0);
        }

        [TestMethod]
        public void InputIsEqualTo8ImmidiateMode() {
            var input = new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };

            Computer computer = new Computer(input);
            var outputLess = computer.Calculate(new List<int>() { 1 });

            computer = new Computer(input);
            var outputEqual = computer.Calculate(new List<int>() { 8 });

            computer = new Computer(input);
            var outputMore = computer.Calculate(new List<int>() { 9 });

            Assert.AreEqual(outputLess.output, 0);
            Assert.AreEqual(outputEqual.output, 1);
            Assert.AreEqual(outputMore.output, 0);
        }

        [TestMethod]
        public void InputIsLessThan8ImmidiateMode() {
            var input = new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };

            Computer computer = new Computer(input);
            var outputLess = computer.Calculate(new List<int>() { 1 });

            computer = new Computer(input);
            var outputLess2 = computer.Calculate(new List<int>() { 7 });

            computer = new Computer(input);
            var outputEqual = computer.Calculate(new List<int>() { 8 });

            computer = new Computer(input);
            var outputMore = computer.Calculate(new List<int>() { 9 });

            Assert.AreEqual(outputLess.output, 1);
            Assert.AreEqual(outputLess2.output, 1);
            Assert.AreEqual(outputEqual.output, 0);
            Assert.AreEqual(outputMore.output, 0);
        }

        [TestMethod]
        public void InputIsLessThan8BigTest() {
            var input = new long[] { 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 };

            Computer computer = new Computer(input);
            var outputLess = computer.Calculate(new List<int>() { 1 });

            computer = new Computer(input);
            var outputLess2 = computer.Calculate(new List<int>() { 7 });

            computer = new Computer(input);
            var outputEqual = computer.Calculate(new List<int>() { 8 });

            computer = new Computer(input);
            var outputMore = computer.Calculate(new List<int>() { 9 });

            Assert.AreEqual(outputLess.output, 999);
            Assert.AreEqual(outputLess2.output, 999);
            Assert.AreEqual(outputEqual.output, 1000);
            Assert.AreEqual(outputMore.output, 1001);
        }
    }
}
