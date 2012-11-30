<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Submit Service RequestUserControl.ascx.cs"
    Inherits="Service_Request.Submit_Service_Request.Submit_Service_RequestUserControl" %>
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
            <asp:TextBox ID="txtTitle" runat="server" Width="359px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdwitdh">
            <asp:Label ID="Detail" runat="server" Text="Detail"></asp:Label>
        </td>
        <td class="tdwitdh">
            <asp:TextBox ID="txtDetail" runat="server" Width="359px" Height="80px" 
                MaxLength="1000"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdwitdh">
            <asp:Label ID="lblPriority" runat="server" Text="Priority"></asp:Label>
        </td>
        <td class="tdwitdh">
            <asp:DropDownList ID="ddlpriority" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="tdwitdh">
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="359px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdwitdh">
            <asp:Label ID="lblPno" runat="server" Text="Phone#"></asp:Label>
        </td>
        <td class="tdwitdh">
            <asp:TextBox ID="txtpno" runat="server" Width="359px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdwitdh">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        </td>
        <td class="tdwitdh">
            <asp:TextBox ID="txtemail" runat="server" Width="359px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnSave" runat="server" Text="Submit" onclick="Button1_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Close" 
                onclick="btnReset_Click" />
        </td>
        
    </tr>
    
</table>
