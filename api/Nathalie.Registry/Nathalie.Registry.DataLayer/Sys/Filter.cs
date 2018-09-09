﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.DataLayer.Sys
{
    public class Filter<T> where T : DocumentBase
    {
        public Expression<Func<T, bool>> FilterExpression { get; set; }
        
        public int PageSize { get; set; } = 10;
        
        public List<ColumnSort> Sorting { get; set; }

        public int PageIndex { get; set; }

        public int PageNumber => PageIndex + 1;
    }
}