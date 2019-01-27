using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Objects.MobiPunch
{


    public class PunchEmployeeActivityStatusAttribute : PXStringListAttribute
    {
        public const string HoldStatus = "H";
        public const string ApprovedStatus = "A";
        public const string RejectedStatus = "C";
        
        public const string ReleasedStatus = "R"; //Corresponding Timecard activity created
        public const string OpenStatus = "O"; //Corresponding timecard activity not created

        public PunchEmployeeActivityStatusAttribute()
            : base(
                new[] { OpenStatus, ApprovedStatus, RejectedStatus, ReleasedStatus, HoldStatus },
                new[] {"Pending Approval", "Approved", "Rejected", "Released", "Hold" })
        { }
    }
}
