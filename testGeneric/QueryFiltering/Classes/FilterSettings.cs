using QueryFiltering.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryFiltering.Classes
{
    /// <summary>
    /// Optional settings for FilterQuery.SetFilters method.
    /// </summary>
    public class FilterSettings
    {
        /// <summary>
        /// Name of property that current setting are applied (name of filterDTO property)
        /// </summary>
        public string FilterName { get; set; }

        /// <summary>
        /// Different types of comparison for targeted property
        /// </summary>
        public Nullable<PropertyComparisonTypeEnum> PropertyComparison { get; set; }

        /// <summary>
        /// Different types of expression combination for targeted property.
        /// </summary>
        public Nullable<ExpressionCombinationTypeEnum> ExpressionCombination { get; set; }

        /// <summary>
        /// Flag that tells not to include this property in filtering
        /// By default false is used.
        /// </summary>
        public bool? ExcludeFromFiltering { get; set; } = false;

        /// <summary>
        /// Flag that tells if strings will first be set to lower and then evaluated. By default it is set tu true
        /// </summary>
        public bool ToLower { get; set; } = true;

        public FilterSettings()
        {
        }

        public List<FilterSettings> ToList()
        {
            var resultList = new List<FilterSettings>();
            resultList.Add(this);
            return resultList;
        }

    }

}
