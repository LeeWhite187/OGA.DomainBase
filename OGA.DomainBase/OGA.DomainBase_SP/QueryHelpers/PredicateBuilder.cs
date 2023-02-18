using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace OGA.DomainBase.QueryHelpers
{
    /* Predicate Builder class.
     * This class allows you to dynamically compose a filter predicate that can be passed to methods that query a repository.
     
     * To utilize in code, add a using namespace statement at the top of the file where used:
        using OGA.DomainBase.QueryHelpers;

        Sample usage:
            To build a filter of AND constraints, start with a true, and add each AND, like this...
                // Compose the query we will use to find our objects...
                var filter = NETCore_Common.Queries.PredicateBuilder.True<CentralOrch_DM.RM.MObject_v1>();
                // If the name is specified, we will include it in our query...
                if(!string.IsNullOrEmpty(name))
                filter = filter.And<CentralOrch_DM.RM.MObject_v1>(p => p.Name == name);
                // If the type is specified, we will include it in our query...
                if(!string.IsNullOrEmpty(type))
                filter = filter.And<CentralOrch_DM.RM.MObject_v1>(p => p.ObjType == type);
     
            To build a filter of OR constraints, start with a false, and add each OR, like this...
                // Compose the query we will use to find our objects...
                var filter = NETCore_Common.Queries.PredicateBuilder.True<CentralOrch_DM.RM.MObject_v1>();
                // If the name is specified, we will include it in our query...
                if(!string.IsNullOrEmpty(name))
                filter = filter.And<CentralOrch_DM.RM.MObject_v1>(p => p.Name == name);
                // If the type is specified, we will include it in our query...
                if(!string.IsNullOrEmpty(type))
                filter = filter.And<CentralOrch_DM.RM.MObject_v1>(p => p.ObjType == type);

            To build a filter that includes both AND and OR
                like this:
                    p => p.Price > 100 &&
                    p.Price < 1000 &&
                    (p.Description.Contains ("foo") || p.Description.Contains ("far"))

                You have to compose it in steps, with the OR'd pair parenthesis, as a single element.
                Like this:
                    var inner = PredicateBuilder.False<Product>();
                    inner = inner.Or (p => p.Description.Contains ("foo"));
                    inner = inner.Or (p => p.Description.Contains ("far"));

                    var outer = PredicateBuilder.True<Product>();
                    outer = outer.And (p => p.Price > 100);
                    outer = outer.And (p => p.Price < 1000);
                    outer = outer.And (inner);

     */

    /// <summary>
    /// Predicate Builder.
    /// Adapted from predicate builder examples, including C# 10 in a Nutshell: http://www.albahari.com/nutshell/predicatebuilder.aspx
    /// </summary>
    public static class PredicateBuilder
    {
      public static Expression<Func<T, bool>> True<T> ()  { return f => true;  }
      public static Expression<Func<T, bool>> False<T> () { return f => false; }
 
      public static Expression<Func<T, bool>> Or<T> (this Expression<Func<T, bool>> expr1,
                                                          Expression<Func<T, bool>> expr2)
      {
        var invokedExpr = Expression.Invoke (expr2, expr1.Parameters.Cast<Expression> ());
        return Expression.Lambda<Func<T, bool>>
              (Expression.OrElse (expr1.Body, invokedExpr), expr1.Parameters);
      }
 
      public static Expression<Func<T, bool>> And<T> (this Expression<Func<T, bool>> expr1,
                                                           Expression<Func<T, bool>> expr2)
      {
        var invokedExpr = Expression.Invoke (expr2, expr1.Parameters.Cast<Expression> ());
        return Expression.Lambda<Func<T, bool>>
              (Expression.AndAlso (expr1.Body, invokedExpr), expr1.Parameters);
      }
    }
}
