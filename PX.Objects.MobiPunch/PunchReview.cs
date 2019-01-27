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
            Where<Where<PunchEmployee.employeeID, Equal<Current<PunchEmployeeFilter.employeeID>>,
                Or<Current<PunchEmployeeFilter.employeeID>, IsNull>>>> Documents;

        public PunchReview()
        {
            Documents.AllowInsert = false;
            Documents.AllowDelete = false;
        }

        protected virtual void PunchEmployee_RowSelected(PXCache cache, PXRowSelectedEventArgs e)
        {
            var row = (PunchEmployee) e.Row;
            if (row == null)
            {
                return;
            }

            PXUIFieldAttribute.SetEnabled<PunchEmployee.employeeID>(cache, row, false);
            PXUIFieldAttribute.SetEnabled<PunchEmployee.status>(cache, row, false);
            PXUIFieldAttribute.SetEnabled<PunchEmployee.punchInDateTime>(cache, row, row.Status != PunchEmployeeStatusAttribute.PunchedOut);
        }

        public PXAction<PunchEmployeeFilter> PunchOut;
        [PXUIField(DisplayName = "Punch Out", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        [PXButton]
        public virtual IEnumerable punchOut(PXAdapter adapter)
        {
            if (Documents.Current?.Status == null || Documents.Current?.Status == PunchEmployeeStatusAttribute.PunchedOut)
            {
                return adapter.Get();
            }

            var punch = CreateInstance<PunchEntry>();
            punch.Document.Current = Documents.Current;
            punch.PunchInOut.Press();

            return adapter.Get();
        }

        public PXAction<PunchEmployeeFilter> viewPunchInGPSOnMap;
        [PXUIField(DisplayName = "View on Map", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select, Visible = false)]
        [PXButton]
        public virtual IEnumerable ViewPunchInGPSOnMap(PXAdapter adapter)
        {
            if (Documents.Current?.PunchInGPSLatitude == null ||
                Documents.Current.PunchInGPSLongitude == null)
            {
                return adapter.Get();
            }

            new PX.Data.GoogleMapLatLongRedirector().ShowAddressByLocation(Documents.Current.PunchInGPSLatitude, Documents.Current.PunchInGPSLongitude);

            return adapter.Get();
        }

        [Serializable]
        public class PunchEmployeeFilter : IBqlTable
        {
            #region EmployeeID

            public abstract class employeeID : IBqlField { }

            [PXDBInt(IsKey = true)]
            [PXUIField(DisplayName = "Employee")]
            [PXSubordinateAndWingmenSelector]
            [PXFieldDescription]
            public virtual Int32? EmployeeID { get; set; }

            #endregion

            #region ShowPunchIn
            public abstract class showPunchIn : IBqlField { }

            [PXBool]
            [PXUIField(DisplayName = "Punch In")]
            [PXUnboundDefault(true)]
            public virtual bool? ShowPunchIn { get; set; }
            #endregion

            #region ShowPunchOut
            public abstract class showPunchOut : IBqlField { }

            [PXBool]
            [PXUIField(DisplayName = "Punch Out")]
            [PXUnboundDefault(true)]
            public virtual bool? ShowPunchOut { get; set; }
            #endregion
        }
    }
}