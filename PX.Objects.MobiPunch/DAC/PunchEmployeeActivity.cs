using System;
using PX.Data;
using PX.Data.EP;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.EP;
using PX.Objects.GL;
using PX.Objects.PM;
using PX.SM;

namespace PX.Objects.MobiPunch
{
    [PXEMailSource]
    [Serializable]
    public class PunchEmployeeActivity : IBqlTable, PX.Data.EP.IAssign
    {
        #region NoteID
        public abstract class noteID : IBqlField { }

        [PXSequentialNote(new Type[0], SuppressActivitiesCount = true, IsKey = true)]
        [PXUIField(DisplayName = "ID")]
        [PXTimeTag(typeof(noteID))]
        [CRActivityStatisticFormulas]
        [PXSelector(typeof(noteID),
            new[] { typeof(noteID) })]
        public virtual Guid? NoteID { get; set; }
        #endregion

        #region RefNoteID
        public abstract class refNoteID : IBqlField { }

        [PXDBGuid]
        [PXParent(typeof(Select<CRActivityStatistics, Where<CRActivityStatistics.noteID, Equal<Current<refNoteID>>>>), LeaveChildren = true, ParentCreate = true)]
        [PXUIField(DisplayName = "References Nbr.")]
        public virtual Guid? RefNoteID { get; set; }
        #endregion

        #region EmployeeID
        public abstract class employeeID : IBqlField { }

        //TODO: Add PXParent relationship?
        [PXDBInt]
        [PXDefault(typeof(Search<EPEmployee.bAccountID, Where<EPEmployee.userID, Equal<Current<AccessInfo.userID>>>>))]
        [PXUIField(DisplayName = "Employee")]
        [PXSubordinateAndWingmenSelector]
        [PXFieldDescription]
        public virtual Int32? EmployeeID { get; set; }
        #endregion

        #region Status

        [PXDBString(1)]
        [PXDefault(PunchEmployeeActivityStatusAttribute.HoldStatus)]
        [PunchEmployeeActivityStatus]
        [PXUIField(DisplayName = "Status", Enabled = false)]
        public virtual String Status { get; set; }
        #endregion

        #region IsApproved

        public abstract class isApproved : IBqlField { }

        [PXDBBool]
        [PXDefault(false)]
        [PXUIField(Visible = false)]
        public virtual Boolean? IsApproved { get; set; }

        #endregion
        #region IsRejected

        public abstract class isRejected : IBqlField { }

        [PXDBBool]
        [PXDefault(false)]
        [PXUIField(Visible = false)]
        public virtual Boolean? IsRejected { get; set; }

        #endregion
        
        #region PunchInDateTime
        public abstract class punchInDateTime : IBqlField { }

        [EPAllDaySupportDateTime(DisplayNameDate = "Punch In Date", DisplayNameTime = "Punch In Time")]
        [PXFormula(typeof(TimeZoneNow))]
        [PXUIField(DisplayName = "Punch In Date Time")]
        public virtual DateTime? PunchInDateTime { get; set; }
        #endregion

        #region PunchInGPSLatitude
        public abstract class punchInGPSLatitude : PX.Data.IBqlField
        {
        }

        [PXDBDecimal(6)]
        [PXUIField(DisplayName = "Punch In Latitude", Enabled = false)]
        public virtual decimal? PunchInGPSLatitude { get; set; }
        #endregion

        #region PunchInGPSLongitude
        public abstract class punchInGPSLongitude : PX.Data.IBqlField
        {
        }

        [PXDBDecimal(6)]
        [PXUIField(DisplayName = "Punch In Longitude", Enabled = false)]
        public virtual decimal? PunchInGPSLongitude { get; set; }
        #endregion

        #region PunchOutDateTime
        public abstract class punchOutDateTime : IBqlField { }

        [EPAllDaySupportDateTime(DisplayNameDate = "Punch Out Date", DisplayNameTime = "Punch Out Time")]
        [PXFormula(typeof(TimeZoneNow))]
        [PXUIField(DisplayName = "Punch Out Date Time")]
        public virtual DateTime? PunchOutDateTime { get; set; }
        #endregion

        public abstract class timeSpentCalc : IBqlField { }
        [PXTimeList(30, 335, ExclusiveValues = false)]
        [TimePunched(typeof(punchInDateTime), typeof(punchOutDateTime))]
        [PXUIField(DisplayName = "Time Spent", Enabled = false)]
        public virtual Int32? TimeSpentCalc { get; set; }

        #region PunchOutGPSLatitude
        public abstract class punchOutGPSLatitude : PX.Data.IBqlField
        {
        }

        [PXDBDecimal(6)]
        [PXUIField(DisplayName = "Punch Out Latitude", Enabled = false)]
        public virtual decimal? PunchOutGPSLatitude { get; set; }
        #endregion

        #region PunchOutGPSLongitude
        public abstract class punchOutGPSLongitude : PX.Data.IBqlField
        {
        }

        [PXDBDecimal(6)]
        [PXUIField(DisplayName = "Punch Out Longitude", Enabled = false)]
        public virtual decimal? PunchOutGPSLongitude { get; set; }
        #endregion

        #region RequireApproval
        [PXDBBool]
        [PXUIField(DisplayName = "Require Approval")]
        [PXDefault(false)]
        public virtual bool? RequireApproval { get; set; }
        public abstract class requireApproval : IBqlField { }
        #endregion

        #region Description
        public abstract class description : IBqlField { }

        [PXDBString(Common.Constants.TranDescLength, InputMask = "", IsUnicode = true)]
        [PXUIField(DisplayName = "Description", Visibility = PXUIVisibility.SelectorVisible)]
        [PXFieldDescription]
        [PXNavigateSelector(typeof(description))]
        public virtual string Description { get; set; }
        #endregion

        #region ProjectID
        public abstract class projectID : IBqlField { }

        [ProjectDefault(PersistingCheck = PXPersistingCheck.Nothing)]
        [ActiveProjectOrContractBase]
        [PXFormula(typeof(
            Switch<
                Case<Where<Not<FeatureInstalled<FeaturesSet.projectModule>>>, DefaultValue<projectID>,
                Case<Where<isBillable, Equal<True>, And<Current2<projectID>, Equal<NonProject>>>, Null,
                Case<Where<isBillable, Equal<False>, And<Current2<projectID>, IsNull>>, DefaultValue<projectID>>>>,
            projectID>))]
        public virtual int? ProjectID { get; set; }
        #endregion

        #region ProjectTaskID
        public abstract class projectTaskID : IBqlField { }
        [PXDefault(typeof(Search<PMTask.taskID, Where<PMTask.projectID, Equal<Current<projectID>>, And<PMTask.isDefault, Equal<True>>>>), PersistingCheck = PXPersistingCheck.Nothing)]
        [ProjectTask(typeof(projectID), BatchModule.TA, DisplayName = "Project Task")]
        [PXFormula(typeof(Switch<
            Case<Where<Current2<projectID>, Equal<NonProject>>, Null>,
            projectTaskID>))]
        public virtual int? ProjectTaskID { get; set; }
        #endregion

        #region LabourItemID
        public abstract class labourItemID : IBqlField { }

        [PXDBInt(BqlField = typeof(PMTimeActivity.labourItemID))]
        [PXUIField(Visible = false)]
        public virtual int? LabourItemID { get; set; }
        #endregion

        #region EarningTypeID
        public abstract class earningTypeID : IBqlField { }

        [PXDBString(2, IsFixed = true, IsUnicode = false, InputMask = ">LL")]
        [PXDefault("RG", typeof(Search<EPSetup.regularHoursType>), PersistingCheck = PXPersistingCheck.Null)]
        [PXRestrictor(typeof(Where<EPEarningType.isActive, Equal<True>>), EP.Messages.EarningTypeInactive, typeof(EPEarningType.typeCD))]
        [PXSelector(typeof(EPEarningType.typeCD), DescriptionField = typeof(EPEarningType.description))]
        [PXUIField(DisplayName = "Earning Type")]
        public virtual string EarningTypeID { get; set; }
        #endregion

        #region IsBillable
        public abstract class isBillable : IBqlField { }

        [PXDBBool]
        [PXUIField(DisplayName = "Billable", FieldClass = "BILLABLE")]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXFormula(typeof(Switch<
            Case<Where<IsNull<Current<CRActivity.classID>, Current<CRSMEmail.classID>>, Equal<CRActivityClass.task>,
                Or<IsNull<Current<CRActivity.classID>, Current<CRSMEmail.classID>>, Equal<CRActivityClass.events>>>, False,
            Case<Where<FeatureInstalled<FeaturesSet.timeReportingModule>>,
                IsNull<Selector<earningTypeID, EPEarningType.isbillable>, False>>>,
            False>))]
        public virtual bool? IsBillable { get; set; }
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
        [PXDBCreatedDateTime]
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
        [PXDBLastModifiedDateTime]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : IBqlField { }
        #endregion

        #region Tstamp
        [PXDBTimestamp]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : IBqlField { }
        #endregion

        #region Hold
        public abstract class hold : IBqlField { }
        protected Boolean? _Hold;
        [PXDBBool]
        [PXDefault(true)]
        [PXUIField(DisplayName = "Hold")]
        public virtual Boolean? Hold
        {
            get
            {
                return this._Hold;
            }
            set
            {
                this._Hold = value;
            }
        }
        #endregion
        #region OwnerID
        public abstract class ownerID : IBqlField { }
        protected Guid? _OwnerID;
        [PXDBGuid]
        //[PXDefault(typeof(Coalesce<
        //    Search<CREmployee.userID, Where<CREmployee.userID, Equal<Current<AccessInfo.userID>>, And<CREmployee.status, NotEqual<BAccount.status.inactive>>>>,
        //    Search<BAccount.ownerID, Where<BAccount.bAccountID, Equal<Current<SOOrder.customerID>>>>>),
        //    PersistingCheck = PXPersistingCheck.Nothing)]
        [PX.TM.PXOwnerSelector]
        [PXUIField(DisplayName = "Owner")]
        public virtual Guid? OwnerID
        {
            get
            {
                return this._OwnerID;
            }
            set
            {
                this._OwnerID = value;
            }
        }
        #endregion
        #region WorkgroupID
        public abstract class workgroupID : IBqlField { }
        protected int? _WorkgroupID;
        [PXDBInt]
        //[PXDefault(typeof(Customer.workgroupID), PersistingCheck = PXPersistingCheck.Nothing)]
        [PX.TM.PXCompanyTreeSelector]
        [PXUIField(DisplayName = "Workgroup", Enabled = false)]
        public virtual int? WorkgroupID
        {
            get
            {
                return this._WorkgroupID;
            }
            set
            {
                this._WorkgroupID = value;
            }
        }
        #endregion


        public static implicit operator PunchEmployeeActivity(PunchEmployee row)
        {
            return new PunchEmployeeActivity
            {
                EmployeeID = row?.EmployeeID,
                PunchInDateTime = row?.PunchInDateTime,
                PunchInGPSLatitude = row?.PunchInGPSLatitude,
                PunchInGPSLongitude = row?.PunchInGPSLongitude,
                ProjectID = row?.ProjectID,
                ProjectTaskID = row?.ProjectTaskID,
                EarningTypeID = row?.EarningTypeID,
                LabourItemID = row?.LabourItemID,
                IsBillable = row?.IsBillable,
                Description = row?.Description
            };
        }
    }
}