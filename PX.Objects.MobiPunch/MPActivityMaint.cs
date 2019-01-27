using PX.Objects.EP;
using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PX.Objects.MobiPunch
{
    public class MPActivityMaint : PXGraph<MPActivityMaint, PunchEmployeeActivity>
    {
        public PXSelect<PunchEmployeeActivity> Activities;
        public PXSelect<MPSetupApproval> SetupApproval;

        [PXViewName(PX.Objects.EP.Messages.Approval)]
        public MPApprovalAutomation<PunchEmployeeActivity, PunchEmployeeActivity.isApproved, PunchEmployeeActivity.isRejected, PunchEmployeeActivity.hold, MPSetupApproval> Approval;

        #region EP Approval Actions

        public PXAction<PunchEmployeeActivity> hold;
        [PXUIField(DisplayName = "Hold", Visible = false, MapEnableRights = PXCacheRights.Select)]
        protected virtual IEnumerable Hold(PXAdapter adapter)
        {
            IEnumerable<PunchEmployeeActivity> items = adapter.Get<PunchEmployeeActivity>().ToArray();

            Save.Press();

            foreach (PunchEmployeeActivity item in items)
            {
                item.Hold = true;
                item.IsApproved = false;
                item.IsRejected = false;
                Activities.Update(item);

                Save.Press();

                yield return item;
            }
        }

        public PXAction<PunchEmployeeActivity> approve;
        public PXAction<PunchEmployeeActivity> reject;

        [PXUIField(DisplayName = "Approve", Visible = false, MapEnableRights = PXCacheRights.Select)]
        public IEnumerable Approve(PXAdapter adapter)
        {
            IEnumerable<PunchEmployeeActivity> items = adapter.Get<PunchEmployeeActivity>().ToArray();

            Save.Press();

            foreach (PunchEmployeeActivity item in items)
            {
                item.IsApproved = true;
                Activities.Update(item);

                Save.Press();

                yield return item;
            }
        }

        [PXUIField(DisplayName = "Reject", Visible = false, MapEnableRights = PXCacheRights.Select)]
        public IEnumerable Reject(PXAdapter adapter)
        {
            IEnumerable<PunchEmployeeActivity> items = adapter.Get<PunchEmployeeActivity>().ToArray();

            Save.Press();

            foreach (PunchEmployeeActivity item in items)
            {
                item.IsRejected = true;
                Activities.Update(item);

                Save.Press();

                yield return item;
            }
        }

        public PXAction<PunchEmployeeActivity> submit;

        [PXUIField(DisplayName = "Submit", Visible = false, MapEnableRights = PXCacheRights.Select)]
        public IEnumerable Submit(PXAdapter adapter)
        {
            IEnumerable<PunchEmployeeActivity> items = adapter.Get<PunchEmployeeActivity>().ToArray();

            Save.Press();

            foreach (PunchEmployeeActivity item in items)
            {
                item.Hold = false;
                Activities.Update(item);

                Save.Press();

                yield return item;
            }

        }

        public PXAction<PunchEmployeeActivity> ActionDropMenu;
        [PXUIField(DisplayName = EP.Messages.Actions, MapEnableRights = PXCacheRights.Select)]
        [PXButton()]
        protected virtual IEnumerable actionDropMenu(PXAdapter adapter)
        {
            return adapter.Get();
        }
        #endregion

    }
}
