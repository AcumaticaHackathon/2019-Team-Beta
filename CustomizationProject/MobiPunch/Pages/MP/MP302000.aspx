<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="MP302000.aspx.cs" Inherits="Page_MP302000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" PrimaryView="Filter" TypeName="PX.Objects.MobiPunch.PunchReview">
		<CallbackCommands>
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" Style="z-index: 100" 
		Width="100%" DataMember="Filter" TabIndex="100">
        <Template>
 
        </Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Style="z-index: 100" 
		Width="100%" Height="150px" SkinID="Details" TabIndex="700" FilesIndicator="False" NoteIndicator="True" SyncPosition="True"  AdjustPageSize="Auto" AllowPaging="True" >
		<Levels>
			<px:PXGridLevel DataKeyNames="NoteID" DataMember="EmployeeActivity" >
			    <RowTemplate>
					
                </RowTemplate>
                <Columns>
                    
                </Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
	    <ActionBar/>
	    <Mode InitNewRow="True" AutoInsert="False" />
	</px:PXGrid>
</asp:Content>
