using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryFiltering.Enums
{
    /// <summary>
    /// Equals - equivalent to =. Domain property must exactly match filter property in order to be included in result.
    /// Greater - equivalent to <![CDATA[>]]>. Domain property must have greater value than matching filter property in order to be included in result.
    /// Less - equivalent to sign <![CDATA[<]]> domain property must have smaller value than matching filter property in order to be included in result.
    /// GreaterOrEqual - equivalent to sign <![CDATA[>=]]> domain property must have greater or equal value than matching filter property in order to be included in result.
    /// LessOrEqual - equivalent to sign <![CDATA[<=]]> domain property must have smaller or equal value than matching filter property in order to be included in result.
    /// Less - equivalent to sign <![CDATA[!=]]> domain property must have different value than matching filter property in order to be included in result.
    /// Contains - equivalent to <![CDATA[string.contains]]> method.
    /// 
    /// By default Equals is used.
    /// </summary>
    public enum PropertyComparisonTypeEnum
    {
        Equals = 1,
        Greater,
        Less,
        GreaterOrEqual,
        LessOrEqual,
        NotEqual,
        Contains,
    }
}
