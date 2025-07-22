using System;
using System.Linq.Expressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Calculator !");
            Console.WriteLine("Please Write your expression: ");

            var expression = Console.ReadLine();

            Expression expression1 = new Expression(expression);
            
            expression1.Print();
        }
    }
}