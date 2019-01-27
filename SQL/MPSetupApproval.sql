

/****** Object:  Table [dbo].[MPSetupApproval]    Script Date: 1/7/2019 9:57:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MPSetupApproval](
	[CompanyID] [int] NOT NULL,
	[ApprovalID] [int] IDENTITY(1,1) NOT NULL,
	[AssignmentMapID] [int] NOT NULL,
	[AssignmentNotificationID] [int] NULL,
	[CreatedByID] [uniqueidentifier] NOT NULL,
	[CreatedByScreenID] [char](8) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByID] [uniqueidentifier] NOT NULL,
	[LastModifiedByScreenID] [char](8) NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[tstamp] [timestamp] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [MPSetupApproval_PK] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[ApprovalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



