/****************************************************************************
DROP TABLE IF EXISTS [dbo].[PunchEmployeeActivity]
GO
****************************************************************************/

CREATE TABLE [dbo].[PunchEmployeeActivity](
	[CompanyID] [INT] NOT NULL,
	[EmployeeID] [INT] NOT NULL,
	[NoteID] [UNIQUEIDENTIFIER] NOT NULL,
	[RefNoteID] [UNIQUEIDENTIFIER] NOT NULL,
	[Status] [CHAR](1) NOT NULL,
	[IsApproved] [BIT] NOT NULL,
	[IsRejected] [BIT] NOT NULL,
	[PunchInDateTime] [DATETIME2](7) NOT NULL,
	[PunchInGPSLatitude] [DECIMAL](9, 6) NULL,
	[PunchInGPSLongitude] [DECIMAL](9, 6) NULL,
	[PunchOutDateTime] [DATETIME2](7) NOT NULL,
	[PunchOutGPSLatitude] [DECIMAL](9, 6) NULL,
	[PunchOutGPSLongitude] [DECIMAL](9, 6) NULL,
	[RequireApproval] [BIT] NOT NULL,
	[Description] [NVARCHAR](256) NULL,
	[ProjectID] [INT] NULL,
	[ProjectTaskID] [INT] NULL,
	[LabourItemID] [INT] NULL,
	[EarningTypeID] [CHAR](2) NULL,
	[IsBillable] [BIT] NULL,
	[CreatedByID] [UNIQUEIDENTIFIER] NOT NULL,
	[CreatedByScreenID] [CHAR](8) NOT NULL,
	[CreatedDateTime] [DATETIME] NOT NULL,
	[LastModifiedByID] [UNIQUEIDENTIFIER] NOT NULL,
	[LastModifiedByScreenID] [CHAR](8) NOT NULL,
	[LastModifiedDateTime] [DATETIME] NOT NULL,
	[tstamp] [TIMESTAMP] NOT NULL,
 CONSTRAINT [PunchEmployeeHistory_PK] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[NoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PunchEmployeeActivity] ADD  DEFAULT ((0)) FOR [CompanyID]
GO


