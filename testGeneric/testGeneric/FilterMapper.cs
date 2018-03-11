﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace testGeneric
{
    public static class FilterMapper
    {

        public static IQueryable<T> SetFilters<T, B>(IQueryable<T> query, B filter)
        {
            PropertyInfo[] properties = typeof(B).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(filter);
                var type = property.PropertyType.Name;
                var name = property.Name;
                var handleType = GetPropertyType(type);
                var domainName = Attribute.IsDefined(property, typeof(DescriptionAttribute)) ?
                    (Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute)) as DescriptionAttribute).Description :
                    property.Name;

                switch (handleType)
                {
                    case "number":
                        query = HandleNumber(query, value, name, property, domainName);
                        break;
                    case "text":
                        query = HandleText(query, value, name, property, domainName);
                        break;
                    default:
                        break;
                }

            }

            return query;
        }


        #region Handlers
        private static IQueryable<T> HandleNumber<T>(IQueryable<T> query, object value, string propName, PropertyInfo property, string domainName)
        {
            ParameterExpression pe = Expression.Parameter(property.PropertyType, domainName);
            var param = Expression.Parameter(typeof(T));

            var type = property.PropertyType;

            var condition =
                Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(
                        Expression.Property(param, domainName),
                        Expression.Constant(value, type/*typeof(type.)*/)
                    ), param);

            query = query.Where(condition);
            return query;
        }

        private static IQueryable<T> HandleText<T>(IQueryable<T> query, object value, string propName, PropertyInfo property, string domainName)
        {
            var type = property.PropertyType;
            ParameterExpression pe = Expression.Parameter(property.PropertyType, domainName);
            var param = Expression.Parameter(typeof(T));
            
            var conditionEquals =
                Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(
                        Expression.Property(param, domainName),
                        Expression.Constant(value, type)
                    ), param);
                    

            var conditionContains = GetExpressionContains<T>(domainName, value, type);

            query = query.Where(conditionEquals);
            return query;
        }

        #endregion

        #region Helpers

        private static Expression<Func<T, bool>> GetExpressionContains<T>(string propertyName, object propertyValue, Type type)
	    { 
	        var parameterExp = Expression.Parameter(typeof(T), "type"); 
	        var propertyExp = Expression.Property(parameterExp, propertyName); 
	        MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) }); 
	        var someValue = Expression.Constant(propertyValue, type); 
	        var containsMethodExp = Expression.Call(propertyExp, method, someValue); 
	 	    return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp); 
	    }



        private static string GetPropertyType(string type)
        {
            try
            {
                type = type.ToLower();
                return _propertyDictionary.Where(x => x.Key == type).FirstOrDefault().Value;
            }
            catch (Exception e)
            {
                throw new Exception("Error in FilterMapper -> GetPropertyType.\n Mapping for property: " + type + " not existing");
            }
        }

        private static T? GetValue<T>(object value) where T : struct
        {
            if (value == null || value is DBNull) return null;
            if (value is T) return (T)value;
            return (T)Convert.ChangeType(value, typeof(T));
        }

        private static Dictionary<string, string> _propertyDictionary = new Dictionary<string, string>
        {
            { "int", "number" },
            { "int?", "number" },
            { "int32", "number" },
            { "int64", "number" },
            { "int64?", "number" },
            { "long", "number" },
            { "long?", "number" },
            { "byte", "number" },
            { "nullable`1", "number" },
            { "string", "text" },
            { "string?", "text" },
            { "char?", "text" },
            { "bool", "bool" },
            { "bool?", "bool" }
        };

        #endregion
    }
}