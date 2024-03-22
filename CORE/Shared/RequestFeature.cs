using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Shared
{
    public abstract class RequestFeature
    {
        public int PageNumber { get; set; } = 1;

        const int MaxPageSize = 50;
        private int _pageSize=5;
        public int PageSize
        {
            get { 
              return _pageSize;
            }
            set { 
             _pageSize = (value>MaxPageSize)?MaxPageSize:value;
            }
        }
    }
}
