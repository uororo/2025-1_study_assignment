/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression (ex. 2 + 3): ");
            string input = Console.ReadLine();

            try
            {
                Parser parser = new Parser();
                (double num1, string op, double num2) = parser.Parse(input);

                Calculator calculator = new Calculator();
                double result = calculator.Calculate(num1, op, num2);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Parser class to parse the input
    public class Parser
    {
        public (double, string, double) Parse(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length != 3)
            {
                throw new FormatException("Input must be in the format: number operator number");
            }

            double num1 = Convert.ToDouble(parts[0]);
            string op = parts[1];
            double num2 = Convert.ToDouble(parts[2]);

            return (num1, op, num2);
        }
    }

    // Calculator class to perform operations
    public class Calculator
    {
        // ---------- TODO ----------
        public double Calculate(double num1, string op, double num2)
        {
            double temp;
            double n;

            switch (op)
            {
                case "+": return (num1 + num2); break;
                case "-": return (num1 - num2); break;
                case "*": return (num1 * num2); break;
                case "/":
                    if (num2 == 0) throw new DivideByZeroException("Division by zero is not allowed");
                    else return (num1 / num2); break;
                case "**":
                    temp = num1;
                    if (num2 > 0)
                    {
                        for (int a = 1; a < num2; a++) num1 *= temp;
                        return num1;
                    }
                    else
                    {
                        for (int a = 1; a < -(num2); a++) num1 *= temp;
                        return 1 / num1;
                    }
                case "G":
                    if (num1 < num2)
                    {
                        temp = num1;
                        num1 = num2;
                        num2 = temp;
                    }
                    while (num2 != 0)
                    {
                        n = num1 % num2;
                        num1 = num2;
                        num2 = n;
                    }
                    return num1;
                case "L":
                    double temp_num1 = num1;
                    double temp_num2 = num2;
                    if (num1 < num2)
                    {
                        temp = num1;
                        num1 = num2;
                        num2 = temp;
                    }
                    while (num2 != 0)
                    {
                        n = num1 % num2;
                        num1 = num2;
                        num2 = n;
                    }
                    return (temp_num1 * temp_num2 / num1);
                case "%":
                    if (num2 > num1) return (num2 % num1);
                    else return (num1 % num2);

                default: throw new InvalidOperationException("Invalid operator");
            }
        }
        // --------------------
    }
}

/* example output

Enter an expression (ex. 2 + 3):
>> 4 * 3
Result: 12

*/


/* example output (CHALLANGE)

Enter an expression (ex. 2 + 3):
>> 4 ** 3
Result: 64

Enter an expression (ex. 2 + 3):
>> 5 ** -2
Result: 0.04

Enter an expression (ex. 2 + 3):
>> 12 G 15
Result: 3

Enter an expression (ex. 2 + 3):
>> 12 L 15
Result: 60

Enter an expression (ex. 2 + 3):
>> 12 % 5
Result: 2

*/