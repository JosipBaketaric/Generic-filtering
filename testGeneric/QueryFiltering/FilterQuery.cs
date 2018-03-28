using LinqKit;
using QueryFiltering.Classes;
using QueryFiltering.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QueryFiltering
{
    /*
     * ToLower za string
     * https://stackoverflow.com/questions/42803007/how-to-convert-binding-expression-left-and-right-to-lower?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
     * 
     * */

    public static class FilterQuery
    {

        /// <summary>
        /// Filters query based on filterDTO that must abbey certain rules.
        /// Every property from filter has to have 
        /// </summary>
        /// <typeparam name="T">Domain class</typeparam>
        /// <typeparam name="B">Filter class</typeparam>
        /// <param name="query">Query on which filtering will be applied</param>
        /// <param name="filter">Filter that contains filtering info that will be applied on query</param>
        /// <param name="settingsList">Custom optional setting that allow changing default filtering settings for different parameter</param>
        /// <returns></returns>
        public static IQueryable<T> SetFilters<T, B>(IQueryable<T> query, B filter, List<FilterSettings> settingsList = null)
        {
            if (filter == null)
                throw new ArgumentNullException("Parameter query is null");
            if (filter == null)
                throw new ArgumentNullException("Parameter filter is null");

            var predicate = PredicateBuilder.New<T>();

            List<PropertyInfo> properties = GetOrderedPropertyInfoArray<B>(settingsList);

            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(filter);
                var customComparison = PropertyComparisonTypeEnum.Equals;
                var customCombination = ExpressionCombinationTypeEnum.And;
                var name = property.Name;
                var handleType = GetPropertyType(property);
                string domainName = "";
                FilterSettings settings = null;
                bool toLower = true;

                if (settingsList != null)
                    settings = settingsList.Where(x => x.FilterName == name).ToList().FirstOrDefault();

                if(settings != null)
                {
                    //if yes then skip this prop
                    if (settings.ExcludeFromFiltering.HasValue && settings.ExcludeFromFiltering.Value == true)
                        continue;
                }


                try
                {
                    domainName = Attribute.IsDefined(property, typeof(DescriptionAttribute)) ?
                        (Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute)) as DescriptionAttribute).Description :
                        property.Name;

                    if (string.IsNullOrEmpty(domainName))
                        throw new Exception();
                }
                catch(Exception e)
                {
                    throw new Exception("Property (" + name + ") from filter class (" + typeof(B).FullName + ") doesn't have a description");
                }

                if (!CheckIfPropertyWithNameExists<T>(domainName))
                {
                    throw new Exception("Property from DTO (" + name + ") has a description (" + domainName + ") that doesn't match any property from class (" + typeof(T).FullName + "). Either set description to match target property from domain class or set in FilterSettings ExcludeFromFiltering flag to true for this property");
                }


                if (settings != null)
                {
                    if (settings.PropertyComparison != null)
                        customComparison = settings.PropertyComparison.Value;

                    if(settings.ExpressionCombination != null)
                        customCombination = settings.ExpressionCombination.Value;

                    toLower = settings.ToLower;
                }

                predicate = SwitchOnType(handleType, predicate, value, domainName, customComparison, customCombination, property.PropertyType, toLower);
            }


            if (predicate.IsStarted)
            {
                query = query
                    .Where(predicate)
                    .AsExpandable();
            }
            else
            {
                query = query
                    .AsExpandable();
            }

            return query;
        }

        private static ExpressionStarter<T> SwitchOnType<T>(string handleType, ExpressionStarter<T> predicate, object value, string domainName,
            PropertyComparisonTypeEnum propertyComparison, ExpressionCombinationTypeEnum customCombination, Type type, bool toLower)
        {
            switch (handleType)
            {
                case "number":
                    predicate = HandleNumber(predicate, value, domainName, propertyComparison, customCombination, type);
                    break;
                case "text":
                    predicate = HandleText(predicate, value, domainName, propertyComparison, customCombination, type, toLower);
                    break;
                case "date":
                    predicate = HandleDate(predicate, value, domainName, propertyComparison, customCombination, type);
                    break;
                case "bool":
                    predicate = HandleBool(predicate, value, domainName, propertyComparison, customCombination);
                    break;
                default:
                    break;
            }

            return predicate;
        }

        #region Handlers
        private static ExpressionStarter<T> HandleBool<T>(ExpressionStarter<T> predicate, object value, string domainName, 
            PropertyComparisonTypeEnum propertyComparison, ExpressionCombinationTypeEnum expressionCombination)
        {
            if (value == null)
                return predicate;

            value = (bool)value;

            Expression<Func<T, bool>> condition = null;

            switch (propertyComparison)
            {
                case PropertyComparisonTypeEnum.Equals:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.NotEqual:
                    condition = GetExpressionNotEqual<T>(domainName, value);
                    break;
                default:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
            }

            switch (expressionCombination)
            {
                case ExpressionCombinationTypeEnum.And:
                    predicate.And(condition);
                    break;
                case ExpressionCombinationTypeEnum.Or:
                    predicate.Or(condition);
                    break;
                default:
                    predicate.And(condition);
                    break;
            }

            return predicate;
        }

        private static ExpressionStarter<T> HandleNumber<T>(ExpressionStarter<T> predicate, object value, string domainName, 
            PropertyComparisonTypeEnum propertyComparison, ExpressionCombinationTypeEnum expressionCombination, Type type)
        {
            if (value == null)
                return predicate;

            if (CheckIfDefaultValue(value, type))
                return predicate;

            Expression<Func<T, bool>> condition = null; ;

            switch (propertyComparison)
            {
                case PropertyComparisonTypeEnum.Equals:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.Greater:
                    condition = GetExpressionGreater<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.Less:
                    condition = GetExpressionLess<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.GreaterOrEqual:
                    condition = GetExpressionGreaterOrEqual<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.LessOrEqual:
                    condition = GetExpressionLessOrEqual<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.NotEqual:
                    condition = GetExpressionNotEqual<T>(domainName, value);
                    break;
                default:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
            }

            switch (expressionCombination)
            {
                case ExpressionCombinationTypeEnum.And:
                    predicate.And(condition);
                    break;
                case ExpressionCombinationTypeEnum.Or:
                    predicate.Or(condition);
                    break;
                default:
                    predicate.And(condition);
                    break;
            }

            return predicate;
        }

        private static ExpressionStarter<T> HandleDate<T>(ExpressionStarter<T> predicate, object value, string domainName, 
            PropertyComparisonTypeEnum propertyComparison, ExpressionCombinationTypeEnum expressionCombination, Type type)
        {
            if (value == null)
                return predicate;


            if (CheckIfDefaultValue(value, type))
                return predicate;

            Expression<Func<T, bool>> condition = null;

            switch (propertyComparison)
            {
                case PropertyComparisonTypeEnum.Equals:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.Greater:
                    condition = GetExpressionGreater<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.Less:
                    condition = GetExpressionLess<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.GreaterOrEqual:
                    condition = GetExpressionGreaterOrEqual<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.LessOrEqual:
                    condition = GetExpressionLessOrEqual<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.NotEqual:
                    condition = GetExpressionNotEqual<T>(domainName, value);
                    break;
                default:
                    condition = GetExpressionEqual<T>(domainName, value);
                    break;
            }

            switch (expressionCombination)
            {
                case ExpressionCombinationTypeEnum.And:
                    predicate.And(condition);
                    break;
                case ExpressionCombinationTypeEnum.Or:
                    predicate.Or(condition);
                    break;
                default:
                    predicate.And(condition);
                    break;
            }

            return predicate;
        }

        private static ExpressionStarter<T> HandleText<T>(ExpressionStarter<T> predicate, object value, string domainName,
            PropertyComparisonTypeEnum propertyComparison, ExpressionCombinationTypeEnum expressionCombination, Type type, bool toLower)
        {
            if (value == null)
                return predicate;

            if (CheckIfDefaultValue(value, type))
                return predicate;

            Expression<Func<T, bool>> condition = null;

            switch (propertyComparison)
            {
                case PropertyComparisonTypeEnum.Equals:
                    if (type.Name.ToLower().Contains("char"))
                        condition = GetExpressionEqual<T>(domainName, value);
                    else
                        condition = toLower == true ? GetExpressionEqualWithToLower<T>(domainName, value) : GetExpressionEqual<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.Contains:
                    if (type.Name.ToLower().Contains("char"))
                        condition = GetExpressionContains<T>(domainName, value);
                    else
                        condition = toLower == true ? GetExpressionContainsWithToLower<T>(domainName, value) : GetExpressionContains<T>(domainName, value);
                    break;
                case PropertyComparisonTypeEnum.NotEqual:
                    condition = GetExpressionNotEqual<T>(domainName, value);
                    break;
                default:
                    if (type.Name.ToLower().Contains("char"))
                        condition = GetExpressionEqual<T>(domainName, value);
                    else
                        condition = toLower == true ? GetExpressionEqualWithToLower<T>(domainName, value) : GetExpressionEqual<T>(domainName, value);
                    break;
            }

            switch (expressionCombination)
            {
                case ExpressionCombinationTypeEnum.And:
                    predicate.And(condition);
                    break;
                case ExpressionCombinationTypeEnum.Or:
                    predicate.Or(condition);
                    break;
                default:
                    predicate.And(condition);
                    break;
            }

            return predicate;
        }

        #endregion

        #region expressions
        private static Expression<Func<T, bool>> GetExpressionContains<T>(string propertyName, object propertyValue)
        {
            /*
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var propType = parameterExp.Type.GetProperty(propertyName).PropertyType;

            var propertyExp = Expression.Property(parameterExp, propertyName);
            MethodInfo method = propType.GetMethod("Contains", new[] { propType });
            var someValue = Expression.Convert(Expression.Constant(propertyValue), propType);
            var containsMethodExp = Expression.Call(propertyExp, method, someValue);
            return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
            */

            Expression<Func<T, bool>> condition = null;
            var param = Expression.Parameter(typeof(T));
            var propType = param.Type.GetProperty(propertyName).PropertyType;
            ParameterExpression pe = Expression.Parameter(propType, propertyName);
            MethodInfo method = propType.GetMethod("Contains", new[] { propType });

            var left = Expression.Property(param, propertyName);
            var right = Expression.Convert(Expression.Constant(propertyValue), propType);

            var nullCheckLeft = Expression.Equal(left, Expression.Constant(null, left.Type));
            var nullCheckRight = Expression.Equal(right, Expression.Constant(null, right.Type));
            var nullCheckBoth = Expression.OrElse(nullCheckLeft, nullCheckRight);

            var methodBasic = Expression.Equal(left, right);
            var methodContains = Expression.Call(left, method, right);

            var workingMethod = Expression.Condition(nullCheckBoth, methodBasic, methodContains);

            condition = Expression.Lambda<Func<T, bool>>(workingMethod, param);

            return condition;
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
        private static Expression<Func<T, bool>> GetExpressionNotEqual<T>(string propertyName, object propertyValue)
        {
            Expression<Func<T, bool>> condition = null;
            var param = Expression.Parameter(typeof(T));
            var propType = param.Type.GetProperty(propertyName).PropertyType;

            ParameterExpression pe = Expression.Parameter(propType, propertyName);

            condition =
            Expression.Lambda<Func<T, bool>>(
                Expression.NotEqual(
                    Expression.Property(param, propertyName),
                    Expression.Convert(Expression.Constant(propertyValue), propType)
                ), param);

            return condition;
        }

        private static Expression<Func<T, bool>> GetExpressionEqualWithToLower<T>(string propertyName, object propertyValue)
        {
            Expression<Func<T, bool>> condition = null;
            var param = Expression.Parameter(typeof(T));
            var propType = param.Type.GetProperty(propertyName).PropertyType;
            ParameterExpression pe = Expression.Parameter(propType, propertyName);

            var left = Expression.Property(param, propertyName);
            var right = Expression.Convert(Expression.Constant(propertyValue), propType);

            var nullCheckLeft = Expression.Equal(left, Expression.Constant(null, left.Type));
            var nullCheckRight = Expression.Equal(right, Expression.Constant(null, right.Type));
            var nullCheckBoth = Expression.OrElse(nullCheckLeft, nullCheckRight);

            var leftToLower = Expression.Call(left, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
            var rightToLower = Expression.Call(right, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));

            var methodEqual = Expression.Equal(leftToLower,rightToLower);
            var methodEqualBasic = Expression.Equal(left, right);

            var workingMethod = Expression.Condition(nullCheckBoth, methodEqualBasic, methodEqual);

            condition = Expression.Lambda<Func<T, bool>>(workingMethod, param);

            return condition;
        }

        private static Expression<Func<T, bool>> GetExpressionContainsWithToLower<T>(string propertyName, object propertyValue)
        {
            Expression<Func<T, bool>> condition = null;
            var param = Expression.Parameter(typeof(T));
            var propType = param.Type.GetProperty(propertyName).PropertyType;
            ParameterExpression pe = Expression.Parameter(propType, propertyName);
            MethodInfo method = propType.GetMethod("Contains", new[] { propType });

            var left = Expression.Property(param, propertyName);
            var right = Expression.Convert(Expression.Constant(propertyValue), propType);

            var nullCheckLeft = Expression.Equal(left, Expression.Constant(null, left.Type));
            var nullCheckRight = Expression.Equal(right, Expression.Constant(null, right.Type));
            var nullCheckBoth = Expression.OrElse(nullCheckLeft, nullCheckRight);

            var leftToLower = Expression.Call(left, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
            var rightToLower = Expression.Call(right, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));

            var methodBasic = Expression.Equal(left, right);
            var methodContains = Expression.Call(leftToLower, method, rightToLower);

            var workingMethod = Expression.Condition(nullCheckBoth, methodBasic, methodContains);

            condition = Expression.Lambda<Func<T, bool>>(workingMethod, param);

            return condition;
        }


        #endregion

        #region Helpers
        private static List<PropertyInfo> GetOrderedPropertyInfoArray<T>(List<FilterSettings> settingsList)
        {
            var resultList = new List<PropertyInfo>();
            var properties = typeof(T).GetProperties();
            List<PropertyInfo> itemsToPlaceOnEndOfList = new List<PropertyInfo>();

            foreach (PropertyInfo property in properties)
            {
                resultList.Add(property);
            }

            if (settingsList == null)
                return resultList;


            foreach(var prop in resultList)
            {
                FilterSettings settings = null;

                if (settingsList != null)
                    settings = settingsList.Where(x => x.FilterName == prop.Name).ToList().FirstOrDefault();

                if(settings != null)
                {
                    if (settings.ExpressionCombination != null && settings.ExpressionCombination.Value == ExpressionCombinationTypeEnum.Or)
                    {
                        itemsToPlaceOnEndOfList.Add(prop);
                    }
                }
            }

            itemsToPlaceOnEndOfList.ForEach(x => {
                resultList.Remove(x);
            });

            resultList.AddRange(itemsToPlaceOnEndOfList);
            return resultList;
        }
        private static bool CheckIfPropertyWithNameExists<T>(string name)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var domainName = property.Name;
                if(domainName == name)
                {
                    return true;
                }
            }

            return false;
        }
        private static bool CheckIfDefaultValue(object value, Type propertyType)
        {
            try
            {
                object defaultValToCompare = Activator.CreateInstance(propertyType);

                if (value.ToString() == defaultValToCompare?.ToString())
                    return true;

                return false;
            }
            catch (Exception e)
            {
                if (value == null)
                    return true;

                if (string.IsNullOrEmpty(value.ToString()))
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

                if (prop == "nullable")
                {
                    var fullNameType = propertyInfo.PropertyType.FullName;
                    var split = fullNameType.Split(new string[] { "," }, StringSplitOptions.None);
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
            { "double", "number" },
            { "double?", "number" },
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
