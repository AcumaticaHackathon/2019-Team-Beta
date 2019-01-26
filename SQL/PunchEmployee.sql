/****************************************************************************
DROP TABLE IF EXISTS [dbo].[PunchEmployee]
GO
****************************************************************************/

CREATE TABLE [dbo].[PunchEmployee](
	[CompanyID] [INT] NOT NULL,
	[EmployeeID] [INT] NOT NULL,
	[Status] [CHAR](1) NOT NULL,
	[PunchInDateTime] [DATETIME2](7) NOT NULL,
	[PunchInGPSLatitude] [DECIMAL](9, 6) NULL,
	[PunchInGPSLongitude] [DECIMAL](9, 6) NULL,
	[Description] [NVARCHAR](256) NULL,
	[ProjectID] [INT] NULL,
	[ProjectTaskID] [INT] NULL,
	[LabourItemID] [INT] NULL,
	[EarningTypeID] [CHAR](2) NULL,
	[IsBillable] [BIT] NULL,
 CONSTRAINT [PunchEmployee_PK] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PunchEmployee] ADD  DEFAULT ((0)) FOR [CompanyID]
GO