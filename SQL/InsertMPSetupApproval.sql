IF NOT EXISTS (
SELECT * FROM MPSetupApproval
)
BEGIN

INSERT INTO [dbo].[MPSetupApproval]
           ([CompanyID]
           ,[AssignmentMapID]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
           ,[isActive])
SELECT 2, assignmentmapid, createdbyid, 'EP205000', getdate(), createdbyid, 'EP205000', getdate(), 1 from EPAssignmentMap where [name] = 'Punch Employee Activity'
END          
GO


