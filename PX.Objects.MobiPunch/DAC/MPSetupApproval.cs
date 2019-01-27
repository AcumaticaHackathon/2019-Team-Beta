using PX.Data;
using PX.Objects.EP;
using PX.Objects.IN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Objects.MobiPunch
{
    [Serializable]
    [PXCacheName("MPSetupApproval")]
    public partial class MPSetupApproval : IBqlTable, IAssignedMap
    {
        #region ApprovalID
        public abstract class approvalID : IBqlField { }
        protected int? _ApprovalID;
        [PXDBIdentity(IsKey = true)]
        public virtual int? ApprovalID
        {
            get
            {
                return this._ApprovalID;
            }
            set
            {
                this._ApprovalID = value;
            }
        }
        #endregion
        #region AssignmentMapID
        public abstract class assignmentMapID : IBqlField { }
        protected int? _AssignmentMapID;
        [PXDefault]
        [PXDBInt()]
        [PXSelector(
            typeof(Search<
                EPAssignmentMap.assignmentMapID,
                Where<
                    EPAssignmentMap.entityType, Equal<AssignmentMapType.AssignmentMapTypeSalesOrder>,
                    And<EPAssignmentMap.mapType, NotEqual<EPMapType.assignment>>>>),
            DescriptionField = typeof(EPAssignmentMap.name))]
        [PXUIField(DisplayName = "Approval Map")]
        public virtual int? AssignmentMapID
        {
            get
            {
                return this._AssignmentMapID;
            }
            set
            {
                this._AssignmentMapID = value;
            }
        }
        #endregion
        #region AssignmentNotificationID
        public abstract class assignmentNotificationID : IBqlField { }
        protected int? _AssignmentNotificationID;
        [PXDBInt]
        [PXSelector(typeof(PX.SM.Notification.notificationID), SubstituteKey = typeof(PX.SM.Notification.name))]
        [PXUIField(DisplayName = "Pending Approval Notification")]
        public virtual int? AssignmentNotificationID
        {
            get
            {
                return this._AssignmentNotificationID;
            }
            set
            {
                this._AssignmentNotificationID = value;
            }
        }
        #endregion
        #region tstamp
        public abstract class Tstamp : IBqlField { }
        protected Byte[] _tstamp;
        [PXDBTimestamp()]
        public virtual Byte[] tstamp
        {
            get
            {
                return this._tstamp;
            }
            set
            {
                this._tstamp = value;
            }
        }
        #endregion
        #region CreatedByID
        public abstract class createdByID : IBqlField { }
        protected Guid? _CreatedByID;
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID
        {
            get
            {
                return this._CreatedByID;
            }
            set
            {
                this._CreatedByID = value;
            }
        }
        #endregion
        #region CreatedByScreenID
        public abstract class createdByScreenID : IBqlField { }
        protected String _CreatedByScreenID;
        [PXDBCreatedByScreenID()]
        public virtual String CreatedByScreenID
        {
            get
            {
                return this._CreatedByScreenID;
            }
            set
            {
                this._CreatedByScreenID = value;
            }
        }
        #endregion
        #region CreatedDateTime
        public abstract class createdDateTime : IBqlField { }
        protected DateTime? _CreatedDateTime;
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime
        {
            get
            {
                return this._CreatedDateTime;
            }
            set
            {
                this._CreatedDateTime = value;
            }
        }
        #endregion
        #region LastModifiedByID
        public abstract class lastModifiedByID : IBqlField { }
        protected Guid? _LastModifiedByID;
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID
        {
            get
            {
                return this._LastModifiedByID;
            }
            set
            {
                this._LastModifiedByID = value;
            }
        }
        #endregion
        #region LastModifiedByScreenID
        public abstract class lastModifiedByScreenID : IBqlField { }
        protected String _LastModifiedByScreenID;
        [PXDBLastModifiedByScreenID()]
        public virtual String LastModifiedByScreenID
        {
            get
            {
                return this._LastModifiedByScreenID;
            }
            set
            {
                this._LastModifiedByScreenID = value;
            }
        }
        #endregion
        #region LastModifiedDateTime
        public abstract class lastModifiedDateTime : IBqlField { }
        protected DateTime? _LastModifiedDateTime;
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime
        {
            get
            {
                return this._LastModifiedDateTime;
            }
            set
            {
                this._LastModifiedDateTime = value;
            }
        }
        #endregion
        #region NonExistence
        public abstract class nonExistence : IBqlField { }
        protected bool? _NonExistence = false;
        [PXNonExistence()]
        public virtual bool? NonExistence
        {
            get
            {
                return this._NonExistence;
            }
            set
            {

                this._NonExistence = value;
            }
        }
        #endregion
        #region IsActive
        public abstract class isActive : IBqlField { }
        protected Boolean? _IsActive;
        [PXDBBool()]
        [PXDefault(1, PersistingCheck = PXPersistingCheck.Nothing)]
        public virtual Boolean? IsActive
        {
            get
            {
                return this._IsActive;
            }
            set
            {
                this._IsActive = value;
            }
        }
        #endregion
    }
}
