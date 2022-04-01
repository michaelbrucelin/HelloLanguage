using System;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lambda expression used to declare a delegate
            Func<int, bool> isOddDelegate = i => (i & 1) == 1;

            Console.WriteLine("With a lambda expression used to declare a delegate:");
            for (int i = 0; i < 10; i++)
            {
                if (isOddDelegate(i))
                    Console.WriteLine(i + " is odd");
                else
                    Console.WriteLine(i + " is even");
            }

            Console.WriteLine();

            // Lambda expression used to declare an expression tree
            Expression<Func<int, bool>> isOddExpression = i => (i & 1) == 1;

            // Expression tree created by hand
            ParameterExpression param = Expression.Parameter(typeof(int), "i");
            Expression<Func<int, bool>> isOdd = Expression.Lambda<Func<int, bool>>(
                Expression.Equal(Expression.And(param, Expression.Constant(1, typeof(int))), Expression.Constant(1, typeof(int))), new ParameterExpression[] { param });

            // Compiling an expression tree down to a delegate
            Func<int, bool> isOddCompiledExpression = isOddExpression.Compile();

            Console.WriteLine("With a compiled expression tree:");
            for (int i = 0; i < 10; i++)
            {
                if (isOddCompiledExpression(i))
                    Console.WriteLine(i + " is odd");
                else
                    Console.WriteLine(i + " is even");
            }
        }
    }
}