using System;
using System.Collections;
using PX.Data;

namespace PX.Objects.MobiPunch
{
    public class PunchEntry : PXGraph<PunchEntry>
    {
        public PXSelect<PunchEmployee> Document;
        public PXSelect<PunchEmployeeActivity> PunchActivity;
        
        public PXAction<PunchEmployee> Punch;

        public PunchEntry()
        {
            PunchActivity.AllowInsert = false;
            PunchActivity.AllowUpdate = false;
            PunchActivity.AllowDelete = false;
        }

        public PXAction<PunchEmployee> viewPunchInGPSOnMap;
        [PXUIField(DisplayName = "View on Map", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select)]
        [PXButton]
        public virtual IEnumerable ViewPunchInGPSOnMap(PXAdapter adapter)
        {
            if (Document.Current?.PunchInGPSLatitude == null ||
                Document.Current.PunchInGPSLongitude == null)
            {
                return adapter.Get();
            }

            RedirectToMap(Document.Current.PunchInGPSLatitude, Document.Current.PunchInGPSLongitude);

            return adapter.Get();
        }

        public PXAction<PunchEmployee> viewPunchActivityInGPSOnMap;
        [PXUIField(DisplayName = "View on Map", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select, Visible = false)]
        [PXButton]
        public virtual IEnumerable ViewPunchActivityInGPSOnMap(PXAdapter adapter)
        {
            if (PunchActivity.Current?.PunchInGPSLatitude == null ||
                PunchActivity.Current.PunchInGPSLongitude == null)
            {
                return adapter.Get();
            }

            RedirectToMap(PunchActivity.Current.PunchInGPSLatitude, PunchActivity.Current.PunchInGPSLongitude);

            return adapter.Get();
        }

        public PXAction<PunchEmployee> viewPunchActivityOutGPSOnMap;
        [PXUIField(DisplayName = "View on Map", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select, Visible = false)]
        [PXButton]
        public virtual IEnumerable ViewPunchActivityOutGPSOnMap(PXAdapter adapter)
        {
            if (PunchActivity.Current?.PunchOutGPSLatitude == null ||
                PunchActivity.Current.PunchOutGPSLongitude == null)
            {
                return adapter.Get();
            }

            RedirectToMap(PunchActivity.Current.PunchOutGPSLatitude, PunchActivity.Current.PunchOutGPSLongitude);

            return adapter.Get();
        }

        protected virtual void RedirectToMap(decimal? latitude, decimal? longitude)
        {
            new PX.Data.GoogleMapLatLongRedirector().ShowAddressByLocation(latitude, longitude);
        }

        [PXButton]
        [PXUIField(DisplayName = "Punch")]
        public virtual void punch()
        {
            var row = this.Document.Current;

            if(row.Status == PunchEmployeeStatusAttribute.PunchedOut)
            {
                //TODO: Define condition for conditional punch
                row.Status = PunchEmployeeStatusAttribute.PunchedIn;
                row.PunchInDateTime = TimePunchedAttribute.PunchDateTime;
                if (IsMobile)
                {
                    string[] parts = row.Mem_GPSLatitudeLongitude.Split(':');
                    row.PunchInGPSLatitude = decimal.Parse(parts[0]);
                    row.PunchInGPSLongitude = decimal.Parse(parts[1]);
                }
            }
            else
            {
                var punchActivity = CreatePunchOutActivity(row);
                if (punchActivity?.EmployeeID != null)
                {
                    PunchActivity.Insert(punchActivity);
                }
                row.Status = PunchEmployeeStatusAttribute.PunchedOut;
                row.PunchInDateTime = null;
            }

            this.Document.Update(row);
            this.Actions.PressSave();
        }

        protected virtual PunchEmployeeActivity CreatePunchOutActivity(PunchEmployee punchEmployee)
        {
            if (punchEmployee?.EmployeeID == null)
            {
                return null;
            }

            var activity = (PunchEmployeeActivity) punchEmployee;
            if (activity?.EmployeeID == null)
            {
                return activity;
            }

            activity.PunchOutDateTime = TimePunchedAttribute.PunchDateTime;
            activity.RequireApproval = punchEmployee.Status == PunchEmployeeStatusAttribute.ConditionallyPunchedIn;

            if (IsMobile)
            {
                string[] parts = punchEmployee.Mem_GPSLatitudeLongitude.Split(':');
                activity.PunchOutGPSLatitude = decimal.Parse(parts[0]);
                activity.PunchOutGPSLongitude = decimal.Parse(parts[1]);
            }

            return activity;
        }

        public void PunchEmployee_RowSelected(PXCache sender, PXRowSelectedEventArgs e)
        {
            var row = (PunchEmployee)e.Row;

            if (row == null)
                return;
            
            this.Punch.SetCaption(row.Status == PunchEmployeeStatusAttribute.PunchedOut ? "Punch In" : "Punch Out");
        }
    }
}