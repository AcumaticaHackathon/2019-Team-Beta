using System;
using PX.Data;
using PX.Data.EP;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.EP;
using PX.Objects.GL;
using PX.Objects.IN;
using PX.Objects.PM;
using static PX.Objects.CR.CRActivity;

namespace PX.Objects.MobiPunch
{
    [Serializable]
    public class PunchEmployee : IBqlTable
    {
        #region EmployeeID
        public abstract class employeeID : IBqlField { }

        [PXDBInt(IsKey = true)]
        [PXDefault(typeof(Search<EPEmployee.bAccountID, Where<EPEmployee.userID, Equal<Current<AccessInfo.userID>>>>))]
        [PXUIField(DisplayName = "Employee")]
        [PXSubordinateAndWingmenSelector]
        [PXFieldDescription]
        public virtual Int32? EmployeeID { get; set; }
        #endregion

        #region Status
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [PunchEmployeeStatus]
        [PXDefault(PunchEmployeeStatusAttribute.PunchedOut)]
        [PXUIField(DisplayName = "Status")]
        public virtual string Status { get; set; }
        public abstract class status : IBqlField { }
        #endregion

        #region PunchInDateTime
        public abstract class punchInDateTime : IBqlField { }

        [EPAllDaySupportDateTime(DisplayNameDate = "Punch In Date", DisplayNameTime = "Punch In Time")]
        [PXUIField(DisplayName = "Punch In Date Time", Enabled = false)]
        public virtual DateTime? PunchInDateTime { get; set; }
        #endregion
        
        public abstract class timeSpentCalc : IBqlField { }
        [PXInt]
        [PXTimeList(30, 335, ExclusiveValues = false)]
        [PXUIField(DisplayName = "Time Spent", Enabled = false)]
        public virtual Int32? TimeSpentCalc { get; set; }

        #region PunchInGPSLatitude
        public abstract class punchInGPSLatitude : PX.Data.IBqlField
        {
        }

        [PXDBDecimal(6)]
        [PXUIField(DisplayName = "Latitude", Enabled = false)]
        public virtual decimal? PunchInGPSLatitude { get; set; }
        #endregion

        #region PunchInGPSLongitude
        public abstract class punchInGPSLongitude : PX.Data.IBqlField
        {
        }

        [PXDBDecimal(6)]
        [PXUIField(DisplayName = "Longitude", Enabled = false)]
        public virtual decimal? PunchInGPSLongitude { get; set; }
        #endregion

        #region Subject
        public abstract class description : IBqlField { }

        [PXDBString(Common.Constants.TranDescLength, InputMask = "", IsUnicode = true)]
        [PXUIField(DisplayName = "Description", Visibility = PXUIVisibility.SelectorVisible)]
        [PXFieldDescription]
        [PXNavigateSelector(typeof(description))]
        public virtual string Description { get; set; }
        #endregion

        #region ProjectID
        public abstract class projectID : IBqlField { }

        [EPActivityProjectDefault(typeof(isBillable))]
        [EPProject(typeof(ownerID), FieldClass = ProjectAttribute.DimensionName)]
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

        [PMLaborItem(typeof(projectID), typeof(earningTypeID), typeof(Select<EPEmployee, Where<EPEmployee.bAccountID, Equal<Current<employeeID>>>>))]
        [PXForeignReference(typeof(Field<labourItemID>.IsRelatedTo<InventoryItem.inventoryID>))]
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
        public virtual bool? IsBillable { get; set; }
        #endregion
    }
}