using LinqKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericFiltering
{

    public enum PropertyComparison{
        Equals = 1,
        Greater,
        Less,
        GreaterOrEqual,
        LessOrEqual,
        Contains,
    }

    public static class FilterQuery
    {
        /// <summary>
        /// Method that returns filtered IQueryable<T>.
        /// </summary>
        /// <typeparam name="T">Domain class.</typeparam>
        /// <typeparam name="B"></typeparam>
        /// <param name="query"></param>
        /// <param name="filter">Properties must have description decoration that point to domain parameters.</param>
        /// <param name="propertiesNotIncluded">To exclude some properties from filter in filtering query.</param>
        /// <param name="customFiltering">ex. Key: StartDate; Value: PropertyComparison.Greater . ex2. Key: EndDate; Value:PropertyComparison.Less. Contains only use with strings  </param>
        /// <returns></returns>
        public static IQueryable<T> SetFilters<T, B>(IQueryable<T> query, B filter, List<string> propertiesNotIncluded = null, List<KeyValuePair<string, PropertyComparison>> customFiltering = null)
        {
            if (filter == null)
                return query;

            PropertyInfo[] properties = typeof(B).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(filter);
                var type = property.PropertyType.Name;
                var name = property.Name;


                if(propertiesNotIncluded != null)
                {
                    if (propertiesNotIncluded.Where(x => x == name).ToList().Count > 0)
                        continue;
                }
                var customComparison = PropertyComparison.Equals;

                if (customFiltering != null)
                {
                    var tempDateComparison = customFiltering.Where(x => x.Key == name).ToList();
                    if (tempDateComparison != null && tempDateComparison.Count > 0)
                        customComparison = tempDateComparison.FirstOrDefault().Value;
                }

                var handleType = GetPropertyType(type);
                var domainName = Attribute.IsDefined(property, typeof(DescriptionAttribute)) ?
                    (Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute)) as DescriptionAttribute).Description :
                    property.Name;

                switch (handleType)
                {
                    case "number":
                        query = HandleNumber(query, value, name, property, domainName, customComparison);
                        break;
                    case "text":
                        query = HandleText(query, value, name, property, domainName, customComparison);
                        break;
                    case "date":
                        query = HandleDate(query, value, name, property, domainName, customComparison);
                        break;
                    default:
                        break;
                }

            }

            return query;
        }


    #region Handlers
        private static IQueryable<T> HandleNumber<T>(IQueryable<T> query, object value, string propName, PropertyInfo property, string domainName, PropertyComparison propertyComparison)
        {
            if (value == null)
                return query;

            object defaultValToCompare = 0;

            if (value == defaultValToCompare)
                return query;

            Expression<Func<T, bool>> condition = null; ;

            switch (propertyComparison)
            {
                case PropertyComparison.Equals:
                    condition = GetExpressionEqual<T>(domainName, value, property.PropertyType);
                    break;
                case PropertyComparison.Greater:
                    condition = GetExpressionGreater<T>(domainName, value, property.PropertyType);
                    break;
                case PropertyComparison.Less:
                    condition = GetExpressionLess<T>(domainName, value, property.PropertyType);
                    break;
                case PropertyComparison.GreaterOrEqual:
                    condition = GetExpressionGreaterOrEqual<T>(domainName, value, property.PropertyType);
                    break;
                case PropertyComparison.LessOrEqual:
                    condition = GetExpressionLessOrEqual<T>(domainName, value, property.PropertyType);
                    break;
                default:
                    condition = GetExpressionEqual<T>(domainName, value, property.PropertyType);
                    break;
            }

            query = query.Where(condition);
            return query;
        }

        private static IQueryable<T> HandleDate<T>(IQueryable<T> query, object value, string propName, PropertyInfo property, string domainName, PropertyComparison propertyComparison)
        {
            if (value == null)
                return null;

            Expression<Func<T, bool>> condition = null;

            switch (propertyComparison)
            {
                case PropertyComparison.Equals:
                    condition = GetExpressionEqual<T>(domainName, value, property.PropertyType);
                    break;
                case PropertyComparison.Greater:
                    condition = GetExpressionGreater<T>(domainName, value, property.PropertyType);
                    break;
                case PropertyComparison.Less:
                    condition = GetExpressionLess<T>(domainName, value, property.PropertyType);
                    break;
                case PropertyComparison.GreaterOrEqual:
                    condition = GetExpressionGreaterOrEqual<T>(domainName, value, property.PropertyType);
                    break;
                case PropertyComparison.LessOrEqual:
                    condition = GetExpressionLessOrEqual<T>(domainName, value, property.PropertyType);
                    break;
                default:
                    condition = GetExpressionEqual<T>(domainName, value, property.PropertyType);
                    break;
            }


            query = query.Where(condition);
            return query;
        }

        private static IQueryable<T> HandleText<T>(IQueryable<T> query, object value, string propName, PropertyInfo property, string domainName, PropertyComparison propertyComparison)
        {
            if (value == null)
                return query;
            try
            {
                Expression<Func<T, bool>> condition = null;

                switch (propertyComparison)
                {
                    case PropertyComparison.Equals:
                        condition = GetExpressionEqual<T>(domainName, value, property.PropertyType);
                        break;
                    case PropertyComparison.Contains:
                        condition = GetExpressionContains<T>(domainName, value, property.PropertyType);
                        break;
                    default:
                        condition = GetExpressionEqual<T>(domainName, value, property.PropertyType);
                        break;
                }

                query = query.Where(condition);
                return query;
            }
            catch(Exception e)
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

                query = query.Where(conditionEquals);
                return query;
            }

        }

    #endregion

    #region expressions
        private static Expression<Func<T, bool>> GetExpressionContains<T>(string propertyName, object propertyValue, Type type)
	    { 
	        var parameterExp = Expression.Parameter(typeof(T), "type"); 
	        var propertyExp = Expression.Property(parameterExp, propertyName); 
	        MethodInfo method = type.GetMethod("Contains", new[] { type }); 
	        var someValue = Expression.Constant(propertyValue, type); 
	        var containsMethodExp = Expression.Call(propertyExp, method, someValue); 
	 	    return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp); 
	    }
        private static Expression<Func<T, bool>> GetExpressionGreater<T>(string propertyName, object propertyValue, Type type)
        {
            ParameterExpression pe = Expression.Parameter(type, propertyName);
            var param = Expression.Parameter(typeof(T));


            var condition =
                Expression.Lambda<Func<T, bool>>(
                    Expression.GreaterThan(
                        Expression.Property(param, propertyName),
                        Expression.Constant(propertyValue, type)
                    ), param);


            return condition;
        }
        private static Expression<Func<T, bool>> GetExpressionGreaterOrEqual<T>(string propertyName, object propertyValue, Type type)
        {
            ParameterExpression pe = Expression.Parameter(type, propertyName);
            var param = Expression.Parameter(typeof(T));


            var condition =
                Expression.Lambda<Func<T, bool>>(
                    Expression.GreaterThanOrEqual(
                        Expression.Property(param, propertyName),
                        Expression.Constant(propertyValue, type)
                    ), param);


            return condition;
        }
        private static Expression<Func<T, bool>> GetExpressionLess<T>(string propertyName, object propertyValue, Type type)
        {
            ParameterExpression pe = Expression.Parameter(type, propertyName);
            var param = Expression.Parameter(typeof(T));


            var condition =
                Expression.Lambda<Func<T, bool>>(
                    Expression.LessThan(
                        Expression.Property(param, propertyName),
                        Expression.Constant(propertyValue, type)
                    ), param);


            return condition;
        }
        private static Expression<Func<T, bool>> GetExpressionLessOrEqual<T>(string propertyName, object propertyValue, Type type)
        {
            ParameterExpression pe = Expression.Parameter(type, propertyName);
            var param = Expression.Parameter(typeof(T));


            var condition =
                Expression.Lambda<Func<T, bool>>(
                    Expression.LessThanOrEqual(
                        Expression.Property(param, propertyName),
                        Expression.Constant(propertyValue, type)
                    ), param);


            return condition;
        }
        private static Expression<Func<T, bool>> GetExpressionEqual<T>(string propertyName, object propertyValue, Type type)
        {
            ParameterExpression pe = Expression.Parameter(type, propertyName);
            var param = Expression.Parameter(typeof(T));


            var condition =
                Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(
                        Expression.Property(param, propertyName),
                        Expression.Constant(propertyValue, type)
                    ), param);


            return condition;
        }
    #endregion

    #region Helpers
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
            { "bool?", "bool" },
            { "datetime", "date" },
        };

    #endregion

    }
}
