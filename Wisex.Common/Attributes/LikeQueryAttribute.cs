using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisex.Common.Attributes
{
    public class LikeQueryAttribute : Attribute
    {
        public bool LikeQueryField { get; }
        public LikeQueryAttribute()
        {
            LikeQueryField = true;
        }
        public LikeQueryAttribute(bool likeQueryField)
        {
            LikeQueryField = likeQueryField;
        }
    }
}
