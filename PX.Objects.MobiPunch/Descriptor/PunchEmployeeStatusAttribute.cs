using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Objects.MobiPunch
{
    public class PunchEmployeeStatusAttribute : PXStringListAttribute
    {
        public const string PunchedIn = "I";
        public const string PunchedOut = "O";
        public const string ConditionallyPunchedIn = "C";

        public PunchEmployeeStatusAttribute()
            : base(
                new[] { PunchedIn, PunchedOut, ConditionallyPunchedIn },
                new[] { Messages.PunchedIn, Messages.PunchedOut, Messages.ConditionallyPunchedIn })
        { }
    }
}
