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

                if (value == null)
                    continue;

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

                var handleType = GetPropertyType(property);
                var domainName = Attribute.IsDefined(property, typeof(DescriptionAttribute)) ?
                    (Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute)) as DescriptionAttribute).Description :
                    property.Name;

                switch (handleType)
                {
                    case "number":
                        query = HandleNumber(query, value, name, property, domainName, customComparison, property.PropertyType);
                        break;
                    case "text":
                        query = HandleText(query, value, name, property, domainName, customComparison, property.PropertyType);
                        break;
                    case "date":
                        query = HandleDate(query, value, name, property, domainName, customComparison, property.PropertyType);
                        break;
                    case "bool":
                        query = HandleBool(query, value, name, property, domainName, customComparison, property.PropertyType);
                        break;
                    default:
                        break;
                }

            }

            return query;
        }


        #region Handlers
        private static IQueryable<T> HandleBool<T>(IQueryable<T> query, object value, string propName, PropertyInfo property, string domainName, PropertyComparison propertyComparison, Type type)
        {
            if (value == null)
                return query;

            //Bools default is false so it has to be nullable
            /*
            if (CheckIfDefaultValue(value, property.PropertyType))
                return query;
                */

            value = (bool)value;
            type = typeof(bool);

            Expression<Func<T, bool>> condition = null;

            switch (propertyComparison)
            {
                case PropertyComparison.Equals:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
                default:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
            }

            query = query.Where(condition);
            return query;
        }

        private static IQueryable<T> HandleNumber<T>(IQueryable<T> query, object value, string propName, PropertyInfo property, string domainName, PropertyComparison propertyComparison, Type type)
        {
            if (value == null)
                return query;

            if (CheckIfDefaultValue(value, type))
                return query;

            Expression<Func<T, bool>> condition = null; ;

            switch (propertyComparison)
            {
                case PropertyComparison.Equals:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
                case PropertyComparison.Greater:
                    condition = GetExpressionGreater<T>(domainName, value);
                    break;
                case PropertyComparison.Less:
                    condition = GetExpressionLess<T>(domainName, value);
                    break;
                case PropertyComparison.GreaterOrEqual:
                    condition = GetExpressionGreaterOrEqual<T>(domainName, value);
                    break;
                case PropertyComparison.LessOrEqual:
                    condition = GetExpressionLessOrEqual<T>(domainName, value);
                    break;
                default:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
            }

            query = query.Where(condition);
            return query;
        }

        private static IQueryable<T> HandleDate<T>(IQueryable<T> query, object value, string propName, PropertyInfo property, string domainName, PropertyComparison propertyComparison, Type type)
        {
            if (value == null)
                return null;


            if (CheckIfDefaultValue(value, type))
                return query;

            Expression<Func<T, bool>> condition = null;

            switch (propertyComparison)
            {
                case PropertyComparison.Equals:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
                case PropertyComparison.Greater:
                    condition = GetExpressionGreater<T>(domainName, value);
                    break;
                case PropertyComparison.Less:
                    condition = GetExpressionLess<T>(domainName, value);
                    break;
                case PropertyComparison.GreaterOrEqual:
                    condition = GetExpressionGreaterOrEqual<T>(domainName, value);
                    break;
                case PropertyComparison.LessOrEqual:
                    condition = GetExpressionLessOrEqual<T>(domainName, value);
                    break;
                default:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
            }


            query = query.Where(condition);
            return query;
        }

        private static IQueryable<T> HandleText<T>(IQueryable<T> query, object value, string propName, PropertyInfo property, string domainName, PropertyComparison propertyComparison, Type type)
        {
            if (value == null)
                return query;


            if (CheckIfDefaultValue(value, type))
                return query;

            try
            {
                Expression<Func<T, bool>> condition = null;

                switch (propertyComparison)
                {
                    case PropertyComparison.Equals:
                        condition = GetExpressionEqual<T>(domainName, value);
                        break;
                    case PropertyComparison.Contains:
                        condition = GetExpressionContains<T>(domainName, value);
                        break;
                    default:
                        condition = GetExpressionEqual<T>(domainName, value);
                        break;
                }

                query = query.Where(condition);
                return query;
            }
            catch(Exception e)
            {
                ParameterExpression pe = Expression.Parameter(type, domainName);
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
        private static Expression<Func<T, bool>> GetExpressionContains<T>(string propertyName, object propertyValue)
	    { 
	        var parameterExp = Expression.Parameter(typeof(T), "type");
            var propType = parameterExp.Type.GetProperty(propertyName).PropertyType;

            var propertyExp = Expression.Property(parameterExp, propertyName); 
	        MethodInfo method = propType.GetMethod("Contains", new[] { propType });
            var someValue = Expression.Convert(Expression.Constant(propertyValue), propType);
            var containsMethodExp = Expression.Call(propertyExp, method, someValue); 
	 	    return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp); 
	    }
        private static Expression<Func<T, bool>> GetExpressionGreater<T>(string propertyName, object propertyValue)
        {
            var param = Expression.Parameter(typeof(T));
            var propType = param.Type.GetProperty(propertyName).PropertyType;

            ParameterExpression pe = Expression.Parameter(propType, propertyName);


            var condition =
                Expression.Lambda<Func<T, bool>>(
                    Expression.GreaterThan(
                        Expression.Property(param, propertyName),
                       Expression.Convert(Expression.Constant(propertyValue), propType)
                    ), param);


            return condition;
        }
        private static Expression<Func<T, bool>> GetExpressionGreaterOrEqual<T>(string propertyName, object propertyValue)
        {
            var param = Expression.Parameter(typeof(T));
            var propType = param.Type.GetProperty(propertyName).PropertyType;

            ParameterExpression pe = Expression.Parameter(propType, propertyName);


            var condition =
                Expression.Lambda<Func<T, bool>>(
                    Expression.GreaterThanOrEqual(
                        Expression.Property(param, propertyName),
                       Expression.Convert(Expression.Constant(propertyValue), propType)
                    ), param);


            return condition;
        }
        private static Expression<Func<T, bool>> GetExpressionLess<T>(string propertyName, object propertyValue)
        {
            var param = Expression.Parameter(typeof(T));
            var propType = param.Type.GetProperty(propertyName).PropertyType;

            ParameterExpression pe = Expression.Parameter(propType, propertyName);


            var condition =
                Expression.Lambda<Func<T, bool>>(
                    Expression.LessThan(
                        Expression.Property(param, propertyName),
                       Expression.Convert(Expression.Constant(propertyValue), propType)
                    ), param);


            return condition;
        }
        private static Expression<Func<T, bool>> GetExpressionLessOrEqual<T>(string propertyName, object propertyValue)
        {
            var param = Expression.Parameter(typeof(T));
            var propType = param.Type.GetProperty(propertyName).PropertyType;

            ParameterExpression pe = Expression.Parameter(propType, propertyName);

            var condition =
                Expression.Lambda<Func<T, bool>>(
                    Expression.LessThanOrEqual(
                        Expression.Property(param, propertyName),
                       Expression.Convert(Expression.Constant(propertyValue), propType)
                    ), param);


            return condition;
        }
        private static Expression<Func<T, bool>> GetExpressionEqual<T>(string propertyName, object propertyValue)
        {
            Expression<Func<T, bool>> condition = null;
            var param = Expression.Parameter(typeof(T));
            var propType = param.Type.GetProperty(propertyName).PropertyType;

            ParameterExpression pe = Expression.Parameter(propType, propertyName);

            condition =
            Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    Expression.Property(param, propertyName),
                    Expression.Convert(Expression.Constant(propertyValue), propType)
                ), param);

            return condition;
        }
        #endregion

        #region Helpers
        private static bool CheckIfDefaultValue(object value, Type propertyType)
        {
            try
            {
                object defaultValToCompare = Activator.CreateInstance(propertyType);

                if (value.ToString() == defaultValToCompare?.ToString())
                    return true;

                return false;
            }
            catch(Exception e)
            {
                if (value == null)
                    return true;

                return false;
            }
        }
        private static string GetPropertyType(PropertyInfo propertyInfo)
        {
            var type = propertyInfo.PropertyType.Name;

            try
            {
                type = type.ToLower();
                var prop = _propertyDictionary.Where(x => x.Key == type).FirstOrDefault().Value;

                if(prop == "nullable")
                {
                    var fullNameType = propertyInfo.PropertyType.FullName;
                    var split = fullNameType.Split(new string[] { "," }, StringSplitOptions.None );
                    var innerType = split[0].Split(new string[] { "." }, StringSplitOptions.None)[2];
                    prop = _propertyDictionary.Where(x => x.Key == innerType.ToLower()).FirstOrDefault().Value;
                }

                return prop;
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
            { "decimal", "number" },
            { "decimal?", "number" },
            { "int32", "number" },
            { "int64", "number" },
            { "int64?", "number" },
            { "long", "number" },
            { "long?", "number" },
            { "byte", "number" },
            { "nullable`1", "nullable" },
            { "string", "text" },
            { "string?", "text" },
            { "char?", "text" },
            { "char", "text" },
            { "bool", "bool" },
            { "bool?", "bool" },
            { "boolean?", "bool" },
            { "boolean", "bool" },
            { "datetime", "date" },
        };

    #endregion

    }
}
