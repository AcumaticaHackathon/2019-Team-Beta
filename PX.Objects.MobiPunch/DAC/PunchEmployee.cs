using System;
using PX.Data;

namespace PX.Objects.MobiPunch
{
    [Serializable]
    public class PunchEmployee : IBqlTable
    {
        #region EmployeeID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Employee ID")]
        public virtual int? EmployeeID { get; set; }
        public abstract class employeeID : IBqlField { }
        #endregion

        #region Status
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Status")]
        public virtual string Status { get; set; }
        public abstract class status : IBqlField { }
        #endregion

        #region PunchInDateTime
        [PXDBDate]
        [PXUIField(DisplayName = "Punch In Date Time")]
        public virtual DateTime? PunchInDateTime { get; set; }
        public abstract class punchInDateTime : IBqlField { }
        #endregion

        #region PunchInGPSLatitude
        [PXDBDecimal]
        [PXUIField(DisplayName = "Punch In GPSLatitude")]
        public virtual Decimal? PunchInGPSLatitude { get; set; }
        public abstract class punchInGPSLatitude : IBqlField { }
        #endregion

        #region PunchInGPSLongitude
        [PXDBDecimal]
        [PXUIField(DisplayName = "Punch In GPSLongitude")]
        public virtual Decimal? PunchInGPSLongitude { get; set; }
        public abstract class punchInGPSLongitude : IBqlField { }
        #endregion

        #region Description
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        public abstract class description : IBqlField { }
        #endregion

        #region ProjectID
        [PXDBInt]
        [PXUIField(DisplayName = "Project ID")]
        public virtual int? ProjectID { get; set; }
        public abstract class projectID : IBqlField { }
        #endregion

        #region ProjectTaskID
        [PXDBInt]
        [PXUIField(DisplayName = "Project Task ID")]
        public virtual int? ProjectTaskID { get; set; }
        public abstract class projectTaskID : IBqlField { }
        #endregion

        #region LabourItemID
        [PXDBInt]
        [PXUIField(DisplayName = "Labour Item ID")]
        public virtual int? LabourItemID { get; set; }
        public abstract class labourItemID : IBqlField { }
        #endregion

        #region EarningTypeID
        [PXDBString(2, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Earning Type ID")]
        public virtual string EarningTypeID { get; set; }
        public abstract class earningTypeID : IBqlField { }
        #endregion

        #region IsBillable
        [PXDBBool]
        [PXUIField(DisplayName = "Is Billable")]
        public virtual bool? IsBillable { get; set; }
        public abstract class isBillable : IBqlField { }
        #endregion
    }
}