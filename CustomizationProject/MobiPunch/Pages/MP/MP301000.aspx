<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="MP301000.aspx.cs" Inherits="Page_MP301000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="PX.Objects.MobiPunch.PunchEntry" PrimaryView="Document">
		<CallbackCommands>
            <px:PXDSCallbackCommand Name="ViewPunchInGPSOnMap" PopupCommand=""
                PopupCommandTarget="" PopupPanel="" Text="" Visible="False" />
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
            <px:PXTimeSpan runat="server" DataField="TimeSpentCalc" ID="RegularTime" Enabled="False" Size="XS" LabelWidth="55" InputMask="hh:mm" MaxHours="99" SummaryMode="true"/>
            <px:PXLayoutRule runat="server" StartColumn="True">
            </px:PXLayoutRule>
            <px:PXLayoutRule StartGroup="True" GroupCaption="Punch Location" runat="server">
            </px:PXLayoutRule>
            <px:PXNumberEdit ID="edPunchInGPSLatitudet" runat="server" DataField="PunchInGPSLatitude" CommitChanges = "True">
            </px:PXNumberEdit>
            <px:PXNumberEdit ID="edPunchInGPSLongitudet" runat="server" DataField="PunchInGPSLongitude" CommitChanges = "True">
            </px:PXNumberEdit>
            <px:PXButton ID="btnViewPunchInGPSOnMap" runat="server" Height="24px"
                Text="View on Map" Width="100px">
                <AutoCallBack Command="ViewPunchInGPSOnMap" Target="ds">
                </AutoCallBack>
            </px:PXButton>
		</Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXTab ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds">
		<Items>
			<px:PXTabItem Text="Tab item 1">
			</px:PXTabItem>
			<px:PXTabItem Text="Tab item 2">
			</px:PXTabItem>
		</Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
	</px:PXTab>
</asp:Content>
