using System;
using System.Collections.Generic;
using System.Linq;

namespace IntCodeComputer {
    public class Computer {
        public long Pointer;
        public long RelativeBase;

        public long[] Memory;
        private readonly int _allocatedMemory = 8000000;

        private int OpCode;

        public Dictionary<int, Operation> ComputerOperations = new Dictionary<int, Operation>() {
            { (int)Operations.Add, new Operation(3, true) },
            { (int)Operations.Multiply, new Operation(3, true) },
            { (int)Operations.OutputValue, new Operation(1, false) },
            { (int)Operations.ReadInput, new Operation(1, true) },
            { (int)Operations.JumpIfTrue, new Operation(2, false) },
            { (int)Operations.JumpIfFalse, new Operation(2, false) },
            { (int)Operations.LessThan, new Operation(3, true) },
            { (int)Operations.Equals, new Operation(3, true) },
            { (int)Operations.AdjustRelativeBase, new Operation(1, false) },
            { (int)Operations.Stop, new Operation(0, false) }
        };

        public Computer(long[] memory) {
            
            Memory = new long[_allocatedMemory];

            for (int i = 0; i < memory.Length; i++) {
                this.Memory[i] = memory[i];
            }
        }

        public CalculationResult Calculate(List<int> userInput = null, bool returnOnOutPut = false) {
            var finished = false;

            long output = 0;

            while (!finished) {
                var modes = GetModes(Memory[Pointer]);

                OpCode = (int)GetOpcode(Memory[Pointer]);


                var operation = ComputerOperations[OpCode];

                var parameters = GetParameters(operation.NumberOfParameters, operation.WillWrite, modes);

                switch (OpCode) {
                    case (int)Operations.Add:
                        Memory[parameters.Last()] = parameters[0] + parameters[1];
                        break;

                    case (int)Operations.Multiply:
                        Memory[parameters.Last()] = parameters[0] * parameters[1];
                        break;

                    case (int)Operations.ReadInput:
                        if (userInput == null || !userInput.Any()) {
                            Console.WriteLine("Input: ");
                            Memory[parameters.Last()] = long.Parse(Console.ReadLine());
                        } else {
                            Memory[parameters.Last()] = userInput.First();
                            userInput.RemoveAt(0);
                        }
                        break;

                    case (int)Operations.OutputValue:
                        //Console.WriteLine(parameters[0]);
                        output = parameters[0];
                        if (returnOnOutPut) {
                            return new CalculationResult(output, false);
                        }
                        break;

                    case (int)Operations.JumpIfTrue:
                        if (parameters[0] != 0) Pointer = parameters[1];
                        break;

                    case (int)Operations.JumpIfFalse:
                        if (parameters[0] == 0) Pointer = parameters[1];

                        break;

                    case (int)Operations.LessThan:
                        var valueToStore = 0;
                        if (parameters[0] < parameters[1]) {
                            valueToStore = 1;
                        }
                        Memory[parameters[2]] = valueToStore;
                        break;

                    case (int)Operations.Equals:
                        var equalsValue = 0;
                        if (parameters[0] == parameters[1]) {
                            equalsValue = 1;
                        }
                        Memory[parameters[2]] = equalsValue;
                        break;

                    case (int)Operations.AdjustRelativeBase:
                        RelativeBase += (int)parameters[0];
                        break;

                    case (int)Operations.Stop:
                        finished = true;
                        break;
                }
            }

            return new CalculationResult(output, true);
        }

        private int GetOpcode(long fromNumber) {
            Pointer++;
            
            return (int)fromNumber.GetDigitsFromPlace(100);
        }

        private List<long> GetParameters(int amount, bool willWrite, List<long> modes) {
            var parameters = new List<long>();

            for (int i = 0; i < amount; i++) {
                if (willWrite && i == amount - 1) {
                    if (modes[i] != 2) {
                        parameters.Add(Memory[Pointer]); // Output is always in immidiate mode
                    } else {
                        parameters.Add(Memory[Pointer] + RelativeBase); // except when in relative mode...
                    }
                }
                else {
                    if (modes[i] == 0) {
                        parameters.Add(Memory[Memory[Pointer]]); // Position mode
                    } else if(modes[i] == 1) {
                        parameters.Add(Memory[Pointer]); // Immidiate mode
                    } else if(modes[i] == 2) {
                        parameters.Add(Memory[Memory[Pointer] + RelativeBase]); // Relative mode
                    }
                }
                Pointer++;
            }

            return parameters;
        }

        private List<long> GetModes(long instruction) {
            List<long> modes = new List<long>();

            modes.Add(instruction.GetDigitAt(3));
            modes.Add(instruction.GetDigitAt(4));
            modes.Add(instruction.GetDigitAt(5));
            

            return modes;
        }
    }

    public class CalculationResult {
        public long output;
        public bool finished;

        public CalculationResult(long output, bool finished) {
            this.output = output;
            this.finished = finished;
        }
    }
}
