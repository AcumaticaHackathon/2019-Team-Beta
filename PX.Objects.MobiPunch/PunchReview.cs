using System;
using System.Collections;
using PX.Data;
using PX.Data.EP;
using PX.Objects.EP;

namespace PX.Objects.MobiPunch
{
    public class PunchReview : PXGraph<PunchReview>
    {
        public PXCancel<PunchEmployeeFilter> Cancel;

        public PXFilter<PunchEmployeeFilter> Filter;

        [PXFilterable]
        public PXSelect<
            PunchEmployee,
            Where<PunchEmployee.employeeID, Equal<Current<PunchEmployeeFilter.employeeID>>,
                Or<Current<PunchEmployeeFilter.employeeID>, IsNull>>> EmployeeActivity;

        public PunchReview()
        {
            EmployeeActivity.AllowInsert = false;
            EmployeeActivity.AllowDelete = false;
        }

        protected virtual void PunchEmployee_RowSelected(PXCache cache, PXRowSelectedEventArgs e)
        {
            PXUIFieldAttribute.SetEnabled<PunchEmployee.employeeID>(cache, e.Row, false);
            PXUIFieldAttribute.SetEnabled<PunchEmployee.status>(cache, e.Row, false);
        }

        public PXAction<PunchEmployeeFilter> PunchOut;
        [PXUIField(DisplayName = "Punch Out", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        [PXButton]
        public virtual IEnumerable punchOut(PXAdapter adapter)
        {
            return adapter.Get();
        }

        public PXAction<PunchEmployeeFilter> viewPunchInGPSOnMap;
        [PXUIField(DisplayName = "View on Map", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select, Visible = false)]
        [PXButton]
        public virtual IEnumerable ViewPunchInGPSOnMap(PXAdapter adapter)
        {
            if (EmployeeActivity.Current?.PunchInGPSLatitude == null ||
                EmployeeActivity.Current.PunchInGPSLongitude == null)
            {
                return adapter.Get();
            }

            new PX.Data.GoogleMapLatLongRedirector().ShowAddressByLocation(EmployeeActivity.Current.PunchInGPSLatitude, EmployeeActivity.Current.PunchInGPSLongitude);

            return adapter.Get();
        }

        [Serializable]
        public class PunchEmployeeFilter : IBqlTable
        {
            public abstract class employeeID : IBqlField { }

            [PXDBInt(IsKey = true)]
            [PXUIField(DisplayName = "Employee")]
            [PXSubordinateAndWingmenSelector]
            [PXFieldDescription]
            public virtual Int32? EmployeeID { get; set; }
        }
    }
}