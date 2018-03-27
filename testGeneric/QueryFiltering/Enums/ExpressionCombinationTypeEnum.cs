using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryFiltering.Enums
{
    /// <summary>
    /// And - Works like classic where clause.
    /// Or - if results from And are null then and only takes Or takes.
    /// 
    /// By default And is used.
    /// </summary>
    public enum ExpressionCombinationTypeEnum
    {
        And = 1,
        Or,
    }
}
