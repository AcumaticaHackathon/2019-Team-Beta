using PX.Data;
using PX.Data.EP;
using PX.Objects.EP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Objects.MobiPunch
{
    public class MPApprovalAutomation<SourceAssign, Approved, Rejected, Hold, SetupApproval>
            : EPApprovalAutomation<SourceAssign, Approved, Rejected, Hold, SetupApproval>
            where SourceAssign : class, IAssign, IBqlTable, new()
            where Approved : class, IBqlField
            where Rejected : class, IBqlField
            where Hold : class, IBqlField
            where SetupApproval : class, IBqlTable, new()
    {
        public MPApprovalAutomation(PXGraph graph, Delegate @delegate)
            : base(graph, @delegate)
        {

        }

        public MPApprovalAutomation(PXGraph graph)
            : base(graph)
        {

        }

        protected override void Hold_FieldDefaulting(PXCache cache, PXFieldDefaultingEventArgs e)
        {
        }

        public override List<ApprovalMap> GetAssignedMaps(SourceAssign doc, PXCache cache)
        {
            PXResultset<SetupApproval> setups = PXSetup<SetupApproval>.SelectMultiBound(cache.Graph, new object[] { doc });

            int count = setups.Count;
            var list = new List<ApprovalMap>();
            for (int i = 0; i < count; i++)
            {
                SetupApproval setup = (SetupApproval)setups[i];
                IAssignedMap map = (IAssignedMap)setup;
                if (map.IsActive == true && map.AssignmentMapID != null)
                {
                    list.Add(new ApprovalMap(map.AssignmentMapID.Value, map.AssignmentNotificationID));
                }
            }
            return list;
        }
    }
}
