
#region Region - Using Statements

using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;

#endregion Region - Using Statements

namespace ConverttoAnyBase
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Convert Integer to string of various base...\n");
            Console.WriteLine("Pleas Enter an Integer...\n");
            int x = (int)Convert.ToUInt32(Console.ReadLine());

            Console.Write("\n\t" + x.ToString() + " to binary \t\t\t\t\t- ");

            // Convert to Binary
            string binary = InttoString(x, new char[] { '0', '1' });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(binary);
            Console.ResetColor();

            Console.Write("\t" + x.ToString() + " to hex \t\t\t\t\t- ");

            // Convert to Hex
            string hex = InttoString(x, new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(hex);
            Console.ResetColor();

            Console.Write("\t" + x.ToString() + " to hexavigesimal (A-Z) \t\t\t- ");

            // Convert to Hexavigesimal (base 26, A-Z)
            string hexavigesimal = InttoString(x, Enumerable.Range('A', 26).Select(x => (char)x).ToArray());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(hexavigesimal);
            Console.ResetColor();

            Console.Write("\t" + x.ToString() + " to sexagesimal (0-9,A-Z,a-z) \t\t- ");

            // Convert to sexagesimal
            string xx = InttoString(x, new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'X', 'W', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 't', 'u', 'v', 'x', 'w', 'y', 'z' });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(xx);
            Console.ResetColor();
            Console.WriteLine();

            // Pause for half a second
            Thread.Sleep(500);

            int y = 0;
            Console.CursorVisible = false;

            // Start timer 
            Stopwatch stopw = new Stopwatch();
            stopw.Start();

            //char[] baseCharsEx = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
            char[] charArrAZ = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'X', 'W', 'Y', 'Z' };

            // Show every representation of given integer from 0 up to given integer
            for (int t = 0; t < x; t++)
            {
                string hex1 = InttoStringFastEx(t, charArrAZ);
                Console.Write("\r\ty = ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(hex1);
                Console.ResetColor();
            }
            stopw.Stop();

            TimeSpan ts = stopw.Elapsed;

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            Console.WriteLine();
            Console.WriteLine("\n\tRunTime (h:m:s:ms): " + elapsedTime);

        }

        // Original slower conversion algorithm
        public static string InttoString(int value, char [] baseChars)
        {
            string result = string.Empty;
            int targetBase = baseChars.Length;

            do
            {
                result = baseChars[value % targetBase] + result;
                value = value / targetBase;
            }
            while (value > 0);

            return result;

        }

        // Fast conversion algorithm
        public static string InttoStringFastEx(int value, char[] baseChars)
        {
            int i = baseChars.Length;
            char[] buffer = new char[i];
            int targetBase = baseChars.Length;

            do
            {
                buffer[--i] = baseChars[value % targetBase];
                value = value / targetBase;
            }
            while (value > 0);

            char[] result = new char[baseChars.Length - i];
            Array.Copy(buffer, i, result, 0, baseChars.Length - i);

            return new string(result);

        }

    }
}
