using System;
using PX.Data;

namespace PX.Objects.MobiPunch
{
    [Serializable]
    public class PunchEmployeeActivity : IBqlTable
    {
        #region EmployeeID
        [PXDBInt]
        [PXUIField(DisplayName = "Employee ID")]
        public virtual int? EmployeeID { get; set; }
        public abstract class employeeID : IBqlField { }
        #endregion

        #region Noteid
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Noteid")]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : IBqlField { }
        #endregion

        #region RefNoteID
        [PXDBGuid]
        [PXUIField(DisplayName = "Ref Note ID")]
        public virtual Guid? RefNoteID { get; set; }
        public abstract class refNoteID : IBqlField { }
        #endregion

        #region Status
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Status")]
        public virtual string Status { get; set; }
        public abstract class status : IBqlField { }
        #endregion

        #region IsApproved
        [PXDBBool]
        [PXUIField(DisplayName = "Is Approved")]
        public virtual bool? IsApproved { get; set; }
        public abstract class isApproved : IBqlField { }
        #endregion

        #region IsRejected
        [PXDBBool]
        [PXUIField(DisplayName = "Is Rejected")]
        public virtual bool? IsRejected { get; set; }
        public abstract class isRejected : IBqlField { }
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

        #region PunchOutDateTime
        [PXDBDate]
        [PXUIField(DisplayName = "Punch Out Date Time")]
        public virtual DateTime? PunchOutDateTime { get; set; }
        public abstract class punchOutDateTime : IBqlField { }
        #endregion

        #region PunchOutGPSLatitude
        [PXDBDecimal]
        [PXUIField(DisplayName = "Punch Out GPSLatitude")]
        public virtual Decimal? PunchOutGPSLatitude { get; set; }
        public abstract class punchOutGPSLatitude : IBqlField { }
        #endregion

        #region PunchOutGPSLongitude
        [PXDBDecimal]
        [PXUIField(DisplayName = "Punch Out GPSLongitude")]
        public virtual Decimal? PunchOutGPSLongitude { get; set; }
        public abstract class punchOutGPSLongitude : IBqlField { }
        #endregion

        #region RequireApproval
        [PXDBBool]
        [PXUIField(DisplayName = "Require Approval")]
        public virtual bool? RequireApproval { get; set; }
        public abstract class requireApproval : IBqlField { }
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

        #region CreatedByID
        [PXDBCreatedByID]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : IBqlField { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : IBqlField { }
        #endregion

        #region CreatedDateTime
        [PXDBDate]
        [PXUIField(DisplayName = "Created Date Time")]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : IBqlField { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : IBqlField { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : IBqlField { }
        #endregion

        #region LastModifiedDateTime
        [PXDBDate]
        [PXUIField(DisplayName = "Last Modified Date Time")]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : IBqlField { }
        #endregion

        #region Tstamp
        [PXDBTimestamp]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : IBqlField { }
        #endregion
    }
}