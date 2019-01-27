using System;
using PX.Data;

namespace PX.Objects.MobiPunch
{
    public class PunchEntry : PXGraph<PunchEntry>
    {
        public PXSelect<PunchEmployee> Document;
        
        public PXAction<PunchEmployee> Punch;

        [PXButton]
        [PXUIField(DisplayName = "Punch")]
        public virtual void punch()
        {
            var row = this.Document.Current;

            if(row.Status == PunchEmployeeStatusAttribute.PunchedOut)
            {
                //TODO: Define condition for conditional punch
                row.Status = PunchEmployeeStatusAttribute.PunchedIn;
                row.PunchInDateTime = DateTime.Now;
            }
            else
            {
                row.Status = PunchEmployeeStatusAttribute.PunchedOut;
                row.PunchInDateTime = null;
            }

            this.Document.Update(row);
            this.Actions.PressSave();
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