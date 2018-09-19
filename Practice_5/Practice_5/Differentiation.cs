using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5
{
    public static class Differentiation
    {
        public static Expression<Func<double, double>> Differentiate(this Expression<Func<double, double>> expression)
        {
            var result = Differentiate(expression.Body);
            return Expression.Lambda<Func<double, double>>(result,expression.Parameters[0]);
        }
        private static Expression Differentiate(Expression e)
        {
            if (e.NodeType == ExpressionType.Constant)
                return Expression.Constant(0d);
            if (e.NodeType == ExpressionType.Parameter)
                return Expression.Constant(1d);
            if (e.NodeType == ExpressionType.Call)
                return DifferentiateSin(e);

            var left = ((BinaryExpression)e).Left;
            var right = ((BinaryExpression)e).Right;

            if (e.NodeType == ExpressionType.Add)
                return Add(left, right);
            if (e.NodeType == ExpressionType.Multiply)
                return Multiply(left, right);

            throw new ArgumentException("Wrong input expression");
        }
        private static Expression Add(Expression v, Expression u)
        {
            return Expression.Add(
                Differentiate(v),
                Differentiate(u));
            throw new NotImplementedException();
        }

        private static Expression Multiply(Expression v, Expression u)
        {
            return Expression.Add(
                Expression.Multiply(Differentiate(v), u),
                Expression.Multiply(v, Differentiate(u)));
            throw new NotImplementedException();
        }
        private static Expression DifferentiateSin(Expression e)
        {
            var callExpression = (MethodCallExpression)e;

            if (typeof(Math).GetMethod("Sin") != callExpression.Method)
                throw new ArgumentException("Function is not 'Sin()'");

            var argument = callExpression.Arguments[0];
            if (argument.NodeType == ExpressionType.Parameter || argument.NodeType == ExpressionType.Constant)
                return Expression.Call(null, typeof(Math).GetMethod("Cos"), argument); 

            return Expression.Call(null,typeof(Math).GetMethod("Cos"), Differentiate(callExpression.Arguments[0]));
        }
    }
}
