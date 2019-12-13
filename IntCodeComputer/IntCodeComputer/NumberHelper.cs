using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntCodeComputer {
    public static class NumberHelper {
        public static int GetDigitAt(this long num, int nth) {
            return (int)(num / Math.Pow(10, nth - 1)) % 10;
        }

        public static long GetDigitsFromPlace(this long number, int nth) {
            return number % nth;
        }
    }
}
