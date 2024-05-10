using System;

namespace OOP_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            NumericalExpression numericalExpression = new NumericalExpression(2);
            Console.WriteLine("numerical expression: " + numericalExpression.ToString());
        }
    }
}
