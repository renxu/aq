using System;

namespace AlgorithmQuestions
{
    public class IntegerToString
    {
        public static String itoa(int n, int radix)
        {
            if (0 == n)
                return "0";

            var index = 10;
            var buffer = new char[1 + index];
            var xlat = "0123456789abcdefghijklmnopqrstuvwxyz";

            int remain = n;
            while (remain != 0)
            {
                int digit;
                remain = Math.DivRem(remain, radix, out digit); // e.g. -3 % 10 = -3
                digit = Math.Abs(digit);
                buffer[index] = xlat[digit];
                index--;
            }

            if (n < 0)
            {
                buffer[index] = '-';
                index--;
            }

            index++;
            return new String(buffer, index, buffer.Length - index);
        }
    }
}
