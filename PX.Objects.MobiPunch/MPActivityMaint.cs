using PX.Objects.EP;
using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Objects.MobiPunch
{
    public class MPActivityMaint : PXGraph<MPActivityMaint, PunchEmployeeActivity>
    {
        public PXSelect<PunchEmployeeActivity> Activities;
        [PXViewName(EP.Messages.Approval)]
        public EPApprovalAction<EPTimeCard, EPTimeCard.isApproved, EPTimeCard.isRejected> Approval;
    }
}
