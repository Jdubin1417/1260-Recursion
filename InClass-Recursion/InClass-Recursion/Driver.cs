using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InClass_Recursion
{
    public class Driver
    {
        public static void Main()
        {
            //long result = FactorialIterative(5);
            //Console.WriteLine(result);

            //long result2 = FactorialRecursiveBad(5);
            //Console.WriteLine(result2);

            //long result3 = FactorialRecursive(3);
            //Console.WriteLine(result3);

            //int result4 = SumIterative(5);
            //Console.WriteLine(result4);

            //int result5 = SumRecursive(5);
            //Console.WriteLine(result5);

            //int result6 = FibonacciNaive(45);
            //Console.WriteLine(result6);

            //int result7 = FibonacciIterative(45);
            //Console.WriteLine(result7);

            SolveTowerOfHanoi(3, 1, 3, 2);
        }

        public static long FactorialIterative(int number)
        {
            long result = 1;
            for(int i = number; i > 0; i--) //5 4 3 2 1
            {
                result = result * i;
            }

            return result;

            /* another approach - also works
            long result = 1;
            for(int i = 1; i <= number; i++) //1 2 3 4 5
            {
                result = result * i;
            }
            return result;
            */
        }

        //Missing base case - it will call itself infinitely
        public static long FactorialRecursiveBad(int number)
        {
            return number * FactorialRecursiveBad(number - 1);
        }

        public static long FactorialRecursive(int number)
        {
            if(number < 0) //invalid data - cannot procede
            {
                throw new Exception("Cannot take the factorial of a negative number.");
            }
            else if(number == 0 | number == 1) //base case
            {
                return 1; //0! = 1, 1! = 1
            }
            else
            {
                return number * FactorialRecursive(number - 1); //n! = n * (n-1)!
            }
        }

        public static int SumIterative(int n)
        {
            //n = 5
            // 1 + 2 + 3 + 4 + 5

            int sum = 0;

            for(int i = 1; i <= n; i++) //1 2 3 4 5
            {
                sum += i;
            }

            return sum;
        }

        public static int SumRecursive(int n)
        { 
            if(n == 1)
            {
                return 1;
            }
            else
            {
                // 1 + 2 + 3 + 4 + 5
                // Sum() + something else
                return n + SumRecursive(n - 1);
            }
        }

        //very straightforward to code
        //repeats calls a lot -> very slow
        public static int FibonacciNaive(int num)
        {
            if(num == 0 || num == 1)
            {
                return num;
            }
            else
            {
                return FibonacciNaive(num - 1) + FibonacciNaive(num - 2);
            }
        }

        public static int FibonacciIterative(int num)
        {
            int[] alreadyCalculated = new int[num + 2];
            alreadyCalculated[0] = 0;
            alreadyCalculated[1] = 1;

            for(int i = 2; i <= num; i++)
            {
                alreadyCalculated[i] = alreadyCalculated[i - 1] + alreadyCalculated[i - 2];
            }

            return alreadyCalculated[num];
        }

        public static void SolveTowerOfHanoi(int numDisks, int sourcePeg, int destPeg, int tempPeg)
        {
            //Base case - only one disk to move
            if (numDisks == 1)
            {
                Console.WriteLine($"{sourcePeg} --> {destPeg}");
                return;
            }

            //Recursion step - move (disks - 1) disks from source to temp peg using destination peg
            SolveTowerOfHanoi(numDisks - 1, sourcePeg, tempPeg, destPeg);

            //Move lask disk from source to destination peg
            Console.WriteLine($"{sourcePeg} --> {destPeg}");

            //Move (disks - 1) disks from temp to destination peg
            SolveTowerOfHanoi(numDisks - 1, tempPeg, destPeg, sourcePeg);
        }
    }
}
