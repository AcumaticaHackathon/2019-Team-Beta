using System;
using PX.Data;

namespace PX.Objects.MobiPunch
{
    public class PunchEntry : PXGraph<PunchEntry>
    {
        public PXSelect<PunchEmployee> Document;
        public PXSelect<PunchEmployeeActivity> PunchActivity;
        
        public PXAction<PunchEmployee> Punch;

        public static DateTime PunchDateTime => PX.Common.PXTimeZoneInfo.Now;

        [PXButton]
        [PXUIField(DisplayName = "Punch")]
        public virtual void punch()
        {
            var row = this.Document.Current;

            if(row.Status == PunchEmployeeStatusAttribute.PunchedOut)
            {
                //TODO: Define condition for conditional punch
                row.Status = PunchEmployeeStatusAttribute.PunchedIn;
                row.PunchInDateTime = PunchDateTime;
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

            activity.PunchOutDateTime = PunchDateTime;
            activity.RequireApproval = punchEmployee.Status == PunchEmployeeStatusAttribute.ConditionallyPunchedIn;

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