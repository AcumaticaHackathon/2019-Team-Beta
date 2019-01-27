<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="MP301000.aspx.cs" Inherits="Page_MP301000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="PX.Objects.MobiPunch.PunchEntry" PrimaryView="Document">
		<CallbackCommands>
            <px:PXDSCallbackCommand Name="ViewPunchInGPSOnMap" PopupCommand="" PopupCommandTarget="" PopupPanel="" Text="" Visible="False" />
            <px:PXDSCallbackCommand Name="viewPunchActivityInGPSOnMap" PopupCommand="" PopupCommandTarget="" PopupPanel="" Text="" Visible="False" />
            <px:PXDSCallbackCommand Name="viewPunchActivityOutGPSOnMap" PopupCommand="" PopupCommandTarget="" PopupPanel="" Text="" Visible="False" />
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" Style="z-index: 100" Width="100%" DataMember="Document">
		<Template>
			<px:PXLayoutRule runat="server" StartRow="True"/>
            <px:PXSelector CommitChanges="True" ID="edEmployeeID" runat="server" DataField="EmployeeID" TextField="AcctCD" ValueField="AcctCD" TextMode="Search" NullText="<SELECT>"
                DataSourceID="ds" />
            <px:PXDropDown ID="edStatus" runat="server" DataField="Status" Enabled="False" />
            <px:PXLayoutRule ID="PXLayoutRule3" runat="server" Merge="True" />
            <px:PXDateTimeEdit ID="edPunchInDateTime_Date" runat="server" DataField="PunchInDateTime_Date"
							CommitChanges="True" />
			<px:PXDateTimeEdit ID="edPunchInDateTime_Time" runat="server" DataField="PunchInDateTime_Time"
				TimeMode="true" SuppressLabel="true" Width="84" CommitChanges="True" />
            <px:PXLayoutRule ID="PXLayoutRule1" runat="server" />          
            <px:PXTimeSpan runat="server" DataField="TimeSpentCalc" ID="RegularTime" Enabled="False" Size="s" LabelWidth="55" InputMask="hh:mm" MaxHours="99" SummaryMode="true"/>
            <px:PXTextEdit ID="edDescription" runat="server" DataField="Description" />
            <px:PXLayoutRule runat="server" StartColumn="True"/>
            <px:PXLayoutRule StartGroup="True" GroupCaption="Punch Location" runat="server"/>
            <px:PXNumberEdit ID="edPunchInGPSLatitudet" runat="server" DataField="PunchInGPSLatitude" CommitChanges = "True"/>
            <px:PXNumberEdit ID="edPunchInGPSLongitudet" runat="server" DataField="PunchInGPSLongitude" CommitChanges = "True"/>
            <px:PXButton ID="btnViewPunchInGPSOnMap" runat="server" Height="24px"
                Text="View on Map" Width="100px">
                <AutoCallBack Command="ViewPunchInGPSOnMap" Target="ds">
                </AutoCallBack>
            </px:PXButton>
            <px:PXTextEdit ID="edMem_GPSLatitudeLongitude" runat="server"
                           DataField="Mem_GPSLatitudeLongitude" AlignLeft="True" Enabled = "False">
            </px:PXTextEdit>
            <px:PXLayoutRule runat="server" StartColumn="True"/>
            <px:PXLayoutRule StartGroup="True" GroupCaption="Activity" runat="server"/>
            <px:PXSegmentMask ID="edProjectID" runat="server" DataField="ProjectID"></px:PXSegmentMask>
            <px:PXSegmentMask ID="edProjectTaskID" runat="server" DataField="ProjectTaskID"></px:PXSegmentMask>
            <px:PXTextEdit ID="edLabourItemID" runat="server" DataField="LabourItemID"></px:PXTextEdit>
            <px:PXSelector ID="edEarningTypeID" runat="server" DataField="EarningTypeID"></px:PXSelector>
            <px:PXCheckBox ID="edIsBillable" runat="server" DataField="IsBillable" />  
		</Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXGrid ID="grid" runat="server" DataSourceID="ds" Height="250px" Style="z-index: 100; left: 0px;
						top: 0px;" Width="100%" SkinID="DetailsInTab" SyncPosition="True">
		<AutoSize Enabled="True" MinHeight="150" Container="Window" />
		<Mode />
        <ActionBar/>
		    <Levels>
			    <px:PXGridLevel DataMember="PunchActivity">
				    <RowTemplate>
					    <px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartColumn="True" LabelsWidth="S"
							ControlSize="M" />
                        <px:PXDropDown ID="edDetailStatus" runat="server" AllowNull="False" DataField="Status" CommitChanges="True" />
                        <px:PXLayoutRule ID="PXLayoutRule3" runat="server" Merge="True" />
                        <px:PXDateTimeEdit ID="edDetailPunchInDateTime_Date" runat="server" DataField="PunchInDateTime"
							CommitChanges="True" />
                        <px:PXDateTimeEdit ID="edDetailPunchInDateTime_Time" TimeMode="True" SuppressLabel="true" runat="server" DataField="PunchInDateTime"
							CommitChanges="True" />
                        <px:PXLayoutRule ID="PXLayoutRule2" runat="server" Merge="True" />
                        <px:PXDateTimeEdit ID="edDetailPunchOutDateTime_Date" runat="server" DataField="PunchOutDateTime"
							CommitChanges="True" />
                        <px:PXDateTimeEdit ID="edDetailPunchOutDateTime_Time" TimeMode="True" runat="server" SuppressLabel="true" DataField="PunchOutDateTime"
							CommitChanges="True" />
                        <px:PXTimeSpan runat="server" DataField="TimeSpentCalc" ID="RegularTime" Enabled="False" Size="s" LabelWidth="55" InputMask="hh:mm" MaxHours="99" SummaryMode="true"/>
                        <px:PXLayoutRule ID="PXLayoutRule4" runat="server" />
                        <px:PXCheckBox ID="edDetailRequireApproval" runat="server" DataField="RequireApproval" />    
                        <px:PXTextEdit ID="edDetailDescription" runat="server" DataField="Description" />
                        <px:PXSegmentMask ID="edDetailProjectID" runat="server" DataField="ProjectID"></px:PXSegmentMask>
                        <px:PXSegmentMask ID="edDetailProjectTaskID" runat="server" DataField="ProjectTaskID"></px:PXSegmentMask>
                        <px:PXTextEdit ID="edDetailLabourItemID" runat="server" DataField="LabourItemID"></px:PXTextEdit>
                        <px:PXSelector ID="edDetailEarningTypeID" runat="server" DataField="EarningTypeID"></px:PXSelector>
                        <px:PXCheckBox ID="edDetailIsBillable" runat="server" DataField="IsBillable" />  
				    </RowTemplate>
				    <Columns>
                        <px:PXGridColumn DataField="Status" />
                        <px:PXGridColumn DataField="PunchInDateTime_Date" />
                        <px:PXGridColumn DataField="PunchInDateTime_Time" />
                        <px:PXGridColumn DataField="PunchOutDateTime_Date" />
                        <px:PXGridColumn DataField="PunchOutDateTime_Time" />
                        <px:PXGridColumn DataField="TimeSpentCalc" Label="TimeSpentCalc" Width="81px" RenderEditorText="True" />
                        <px:PXGridColumn DataField="PunchInGPSLatitude" LinkCommand="viewPunchActivityInGPSOnMap" />
                        <px:PXGridColumn DataField="PunchInGPSLongitude" LinkCommand="viewPunchActivityInGPSOnMap" />
                        <px:PXGridColumn DataField="PunchOutGPSLatitude" LinkCommand="viewPunchActivityOutGPSOnMap" />
                        <px:PXGridColumn DataField="PunchOutGPSLongitude" LinkCommand="viewPunchActivityOutGPSOnMap" />
                        <px:PXGridColumn DataField="Description" />
                        <px:PXGridColumn DataField="ProjectID" />
                        <px:PXGridColumn DataField="ProjectTaskID" />
                        <px:PXGridColumn DataField="LabourItemID" />
                        <px:PXGridColumn DataField="EarningTypeID" />
                        <px:PXGridColumn DataField="IsBillable" TextAlign="Center" Type="CheckBox" />
				    </Columns>
			    </px:PXGridLevel>
		    </Levels>
	    </px:PXGrid>
</asp:Content>
