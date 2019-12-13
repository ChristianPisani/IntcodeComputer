namespace IntCodeComputer {
    public enum Operations {
        Add = 1,
        Multiply = 2,
        ReadInput = 3,
        OutputValue = 4,
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        AdjustRelativeBase = 9,
        Stop = 99 // IMMIDIATELY HALT
    }    

    public class Operation {
        public int NumberOfParameters;
        public bool WillWrite;

        public Operation(int numberOfParameters, bool willWrite) {
            this.NumberOfParameters = numberOfParameters;
            this.WillWrite = willWrite;
        }
    }
}
