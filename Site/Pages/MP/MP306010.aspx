<%@ Page Language="C#" MasterPageFile="~/MasterPages/TabView.master" AutoEventWireup="true"
	ValidateRequest="false" CodeFile="MP306010.aspx.cs" Inherits="Page_MP306010"
	Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/TabView.master" %>
<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" PrimaryView="Activities"
		TypeName="PX.Objects.MobiPunch.MPActivityMaint">
		<CallbackCommands>
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Activities" NoteIndicator="True"
		FilesIndicator="True" DefaultControlID="edSubject" Width="100%" AllowCollapse="true">
				<Template>
					<px:PXPanel ID="PXPanel1" runat="server" RenderStyle="Simple" ContentLayout-OuterSpacing="Around">
                        <px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartColumn="True" LabelsWidth="S"
							ControlSize="M" />
                        <px:PXSelector ID="edEmployeeID" runat="server" DataField="EmployeeID"></px:PXSelector>
                        <px:PXDropDown ID="edStatus" runat="server" AllowNull="False" DataField="Status" CommitChanges="True" />
                        <px:PXLayoutRule ID="PXLayoutRule3" runat="server" Merge="True" />
                        <px:PXDateTimeEdit ID="edPunchInDateTime_Date" runat="server" DataField="PunchInDateTime"
							CommitChanges="True" />
                        <px:PXDateTimeEdit ID="edPunchInDateTime_Time" TimeMode="True" SuppressLabel="true" runat="server" DataField="PunchInDateTime"
							CommitChanges="True" />
                        <px:PXLayoutRule ID="PXLayoutRule2" runat="server" Merge="True" />
                        <px:PXDateTimeEdit ID="edPunchOutDateTime_Date" runat="server" DataField="PunchOutDateTime"
							CommitChanges="True" />
                        <px:PXDateTimeEdit ID="edPunchOutDateTime_Time" TimeMode="True" runat="server" SuppressLabel="true" DataField="PunchOutDateTime"
							CommitChanges="True" />
                        <px:PXLayoutRule ID="PXLayoutRule4" runat="server" />
                        <px:PXCheckBox ID="edRequireApproval" runat="server" DataField="RequireApproval" />    
                        <px:PXTextEdit ID="edDescription" runat="server" DataField="Description" />
                        <px:PXSelector ID="edProjectID" runat="server" DataField="ProjectID"></px:PXSelector>
                        <px:PXSelector ID="edProjectTaskID" runat="server" DataField="ProjectTaskID"></px:PXSelector>
                        <px:PXSelector ID="edLabourItemID" runat="server" DataField="LabourItemID"></px:PXSelector>
                        <px:PXSelector ID="edEarningTypeID" runat="server" DataField="EarningTypeID"></px:PXSelector>
                        <px:PXCheckBox ID="edIsBillable" runat="server" DataField="IsBillable" />    
					</px:PXPanel>
<%--                    <px:PXGrid ID="gridApproval" runat="server" DataSourceID="ds" Width="100%" SkinID="DetailsInTab" NoteIndicator="True">
                        <AutoSize Enabled="true" />
                        <Mode AllowAddNew="false" AllowDelete="false" AllowUpdate="false" />
                        <ActionBar>
                            <Actions>
                                <AddNew Enabled="false" />
                                <EditRecord Enabled="false" />
                                <Delete Enabled="false" />
                            </Actions>
                        </ActionBar>
                        <Levels>
                            <px:PXGridLevel DataMember="Approval" DataKeyNames="ApprovalID,AssignmentMapID">
                                <Columns>
                                    <px:PXGridColumn DataField="WorkgroupID" Width="80px" />
                                    <px:PXGridColumn DataField="ApproverEmployee__AcctCD" Width="160px" />
                                    <px:PXGridColumn DataField="ApproverEmployee__AcctName" Width="160px" />
                                    <px:PXGridColumn DataField="ApprovedByEmployee__AcctCD" Width="100px" />
                                    <px:PXGridColumn DataField="ApprovedByEmployee__AcctName" Width="160px" />
                                    <px:PXGridColumn DataField="ApproveDate" Width="90px" />
                                    <px:PXGridColumn AllowNull="False" AllowUpdate="False" DataField="Status" RenderEditorText="True" />
									<px:PXGridColumn DataField="AssignmentMapID"  Visible="false" SyncVisible="false" Width="160px"/>
									<px:PXGridColumn DataField="RuleID" Visible="false" SyncVisible="false" Width="160px" />
									<px:PXGridColumn DataField="CreatedDateTime" Visible="false" SyncVisible="false" Width="100px" />
                                </Columns>
                                <Layout FormViewHeight="" />
                            </px:PXGridLevel>
                        </Levels>
                    </px:PXGrid>--%>
                </Template>
	</px:PXFormView>


</asp:Content>
