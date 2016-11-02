//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace Practice_5
//{
//    public static class Differentiation
//    {
//        private static ParameterExpression parameter = Expression.Parameter(typeof(double), "x");

//        public static Expression<Func<double, double>> Differentiate(this Expression<Func<double, double>> expression)
//        {
//            var expressionType = expression.Body.NodeType;

//            if (expressionType == ExpressionType.Constant)
//                return x => 0;
//            if (expressionType == ExpressionType.Parameter)
//                return x => 1;

//            if (expressionType == ExpressionType.Add)
//                return Add(((BinaryExpression)expression.Body).Left, ((BinaryExpression)expression.Body).Right);
//            if (expressionType == ExpressionType.Multiply)
//                return Multiply(((BinaryExpression)expression.Body).Left, ((BinaryExpression)expression.Body).Right);

//            throw new ArgumentException("Wrong input expression");
//        }

//        private static Expression<Func<double, double>> Add(Expression v, Expression u)
//        {
//            return Expression.Lambda<Func<double, double>>(
//                Expression.Add(
//                    Expression.Constant(DifferentianteIntermediateResult(v).Invoke(0)),
//                    Expression.Constant(DifferentianteIntermediateResult(u).Invoke(0))),
//                parameter);
//        }

//        private static Expression<Func<double, double>> Multiply(Expression v, Expression u)
//        {
//            var vDiffU = MultiplyDifferentialAndVariable(v, u);
//            var uDiffV = MultiplyDifferentialAndVariable(u, v);
//            return Expression.Lambda<Func<double, double>>(
//                Expression.Add(
//                    vDiffU,
//                    uDiffV),
//                parameter);
//        }
//        private static Func<double, double> DifferentianteIntermediateResult(Expression x)
//        {
//            return Expression.Lambda<Func<double, double>>(x, parameter).Differentiate().Compile();
//        }

//        private static Expression MultiplyDifferentialAndVariable(Expression variable, Expression differential) // differential' * variable
//        {
//            var result = Expression.Multiply(Expression.Constant(DifferentianteIntermediateResult(differential).Invoke(0)), variable);
//            if (result.Right.NodeType == ExpressionType.Constant && result.Left.NodeType == ExpressionType.Constant)
//                return Expression.Constant(Expression.Lambda<Func<double, double>>(result, parameter).Compile().Invoke(0));
//            else return result;
//        }
        
//    }
//}
