<%@ Assembly Name="Service Request, Version=1.0.0.0, Culture=neutral, PublicKeyToken=58c2cd10e016c498" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Service Request TasksUserControl.ascx.cs" Inherits="Service_Request.Service_Request_Tasks.Service_Request_TasksUserControl" %>
<style type="text/css">
    .tdwitdh
    {
       width: 255px;
    }
</style>
<table style="vertical-align:middle;background-color:Gray" width="50%" >
<tr>
<th colspan="2">Submit Service Request</th>
</tr>
    <tr>
        <td class="tdwitdh"> <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
        </td>
        <td class="tdwitdh">
            <asp:DropDownList ID="ddlTitle" runat="server" 
                onselectedindexchanged="ddlTitle_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="tdwitdh">
            <asp:Label ID="Detail" runat="server" Text="Detail"></asp:Label>
        </td>
        <td class="tdwitdh">
            <asp:TextBox ID="txtDetail" runat="server" Width="359px" Height="80px" 
                MaxLength="1000" ReadOnly="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdwitdh">
            <asp:Label ID="lblPriority" runat="server" Text="Priority"></asp:Label>
        </td>
        <td class="tdwitdh">
            <asp:TextBox ID="txtPriority" Width="359px" ReadOnly="false" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdwitdh">
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtName" Width="359px" runat="server" ReadOnly="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdwitdh">
            <asp:Label ID="lblPno" runat="server" Text="Phone#"></asp:Label>
        </td>
        <td class="tdwitdh">
            <asp:TextBox ID="txtpno" runat="server" Width="359px" ReadOnly="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdwitdh">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        </td>
        <td class="tdwitdh">
            <asp:TextBox ID="txtemail" runat="server" Width="359px" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdwitdh">
           Assigned To</td>
           
        <td class="tdwitdh">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="tdwitdh">
            Additional Infromation</td>
        <td class="tdwitdh">
            <asp:TextBox ID="TextBox1" Width="359px" Height="80px" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnSave" runat="server" Text="Assign"  />
            <asp:Button ID="btnReset" runat="server" Text="Close" />
        </td>
        
    </tr>
    
</table>
<p>
    &nbsp;</p>
