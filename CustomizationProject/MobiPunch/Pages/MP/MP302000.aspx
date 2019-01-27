<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="MP302000.aspx.cs" Inherits="Page_MP302000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" PrimaryView="Filter" TypeName="PX.Objects.MobiPunch.PunchReview">
		<CallbackCommands>
            <px:PXDSCallbackCommand Name="ViewPunchInGPSOnMap" PopupCommand="" PopupCommandTarget="" PopupPanel="" Text="" Visible="False"></px:PXDSCallbackCommand>
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" Style="z-index: 100" 
		Width="100%" DataMember="Filter" TabIndex="100">
        <Template>
            <px:PXLayoutRule runat="server" StartRow="True"/>
            <px:PXSelector ID="edEmployeeID" runat="server" DataField="EmployeeID" AllowEdit="True" AutoRefresh="True" />
        </Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Style="z-index: 100" 
		Width="100%" Height="150px" SkinID="Details" TabIndex="700" FilesIndicator="False" NoteIndicator="True" SyncPosition="True" AdjustPageSize="Auto" AllowPaging="True" >
		<Levels>
			<px:PXGridLevel DataKeyNames="NoteID" DataMember="EmployeeActivity" >
			    <RowTemplate>
                    <px:PXLayoutRule runat="server" StartRow="True"/>
                    <px:PXSelector CommitChanges="True" ID="edEmployeeID" runat="server" DataField="EmployeeID" TextField="AcctCD" ValueField="AcctCD" TextMode="Search" NullText="<SELECT>"
                                   DataSourceID="ds" AllowEdit="True"/>
                    <px:PXDropDown ID="edStatus" runat="server" DataField="Status" Enabled="False" />
                    <px:PXLayoutRule ID="PXLayoutRule3" runat="server" Merge="True" />
                    <px:PXDateTimeEdit ID="edPunchInDateTime_Date" runat="server" DataField="PunchInDateTime_Date"
                                       CommitChanges="True" />
                    <px:PXDateTimeEdit ID="edPunchInDateTime_Time" runat="server" DataField="PunchInDateTime_Time"
                                       TimeMode="true" SuppressLabel="true" Width="84" CommitChanges="True" />
                    <px:PXTimeSpan runat="server" DataField="TimeSpentCalc" ID="RegularTime" Enabled="False" Size="XS" LabelWidth="55" InputMask="hh:mm" MaxHours="99" SummaryMode="true"/>
                    <px:PXLayoutRule runat="server" StartColumn="True"/>
                    <px:PXLayoutRule StartGroup="True" GroupCaption="Punch Location" runat="server"/>
                    <px:PXNumberEdit ID="edPunchInGPSLatitudet" runat="server" DataField="PunchInGPSLatitude" />
                    <px:PXNumberEdit ID="edPunchInGPSLongitudet" runat="server" DataField="PunchInGPSLongitude" />
                    <px:PXButton ID="btnViewPunchInGPSOnMap" runat="server" Height="24px"
                                 Text="View on Map" Width="100px">
                        <AutoCallBack Command="ViewPunchInGPSOnMap" Target="ds">
                        </AutoCallBack>
                    </px:PXButton>
                    <px:PXTextEdit ID="edDescription" runat="server" DataField="Description" />
                </RowTemplate>
                <Columns>
                    <px:PXGridColumn DataField="EmployeeID" />
                    <px:PXGridColumn DataField="Status" />
                    <px:PXGridColumn DataField="PunchInDateTime_Date" />
                    <px:PXGridColumn DataField="PunchInDateTime_Time" />
                    <px:PXGridColumn DataField="TimeSpentCalc" />
                    <px:PXGridColumn DataField="PunchInGPSLatitude" LinkCommand="ViewPunchInGPSOnMap" />
                    <px:PXGridColumn DataField="PunchInGPSLongitude" LinkCommand="ViewPunchInGPSOnMap" />
                    <px:PXGridColumn DataField="Description" />
                    <px:PXGridColumn DataField="ProjectID" />
                    <px:PXGridColumn DataField="ProjectTaskID" />
                    <px:PXGridColumn DataField="LabourItemID" />
                    <px:PXGridColumn DataField="EarningTypeID" />
                    <px:PXGridColumn DataField="IsBillable" TextAlign="Center" Type="CheckBox" />
                </Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
        <ActionBar/>
	    <Mode InitNewRow="True" AutoInsert="False" />
	</px:PXGrid>
</asp:Content>
