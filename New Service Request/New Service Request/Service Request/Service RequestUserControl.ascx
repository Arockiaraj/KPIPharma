﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Service RequestUserControl.ascx.cs"
    Inherits="New_Service_Request.Service_Request.Service_RequestUserControl" %>
<link href="../../../_layouts/New%20Service%20Request/Stylesheet1.css" rel="stylesheet"
    type="text/css" />
<div>

    <table>
        <tr>
            <td style="width: 200px; height: 40px" valign="middle">
                Service Request ID
            </td>
            <td valign="middle">
                <asp:Label ID="lblDatetimesec" runat="server" Width="250px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 40px" valign="middle">
                Service Request Title
            </td>
            <td style="width: 200px; height: 40px" valign="middle">
                <asp:TextBox ID="txtTitle" runat="server" Width="320px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 40px" valign="middle">
                Service Request Detail
            </td>
            <td style="width: 200px; height: 40px" valign="middle">
                <asp:TextBox ID="txtDetails" runat="server" Height="50px" TextMode="MultiLine" Width="320px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 40px" valign="middle">
                Issues/Risks
            </td>
            <td style="width: 200px; height: 40px" valign="middle">
                <asp:TextBox ID="txtIssueRisk" runat="server" Width="320px" Height="50px"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 40px" valign="middle">
                Keywords
            </td>
            <td style="width: 200px; height: 40px" valign="middle">
                <asp:DropDownList ID="ddlkeyword" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 40px" valign="middle">
                Priority
            </td>
            <td style="width: 200px; height: 40px" valign="middle">
                <asp:DropDownList ID="ddlPriority" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 40px" valign="middle">
                Requestor
            </td>
            <td style="width: 200px; height: 40px" valign="middle">
                <%--<SharePoint:PeopleEditor ID="PPRequestor" Width="355px" Visible="true" AllowEmpty="false"
                    ValidatorEnabled="true" SelectionSet="User" MultiSelect="false" runat="server"
                    CssClass="NoBorder"></SharePoint:PeopleEditor>--%>
                <asp:TextBox ID="txtRequestor" runat="server" Width="320px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 40px" valign="middle">
                Phone Number
            </td>
            <td style="width: 200px; height: 40px" valign="middle">
                <asp:TextBox ID="txtPhoneNO" runat="server" Width="320px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 40px" valign="middle">
                Email Address
            </td>
            <td style="width: 200px; height: 40px" valign="middle">
                <asp:TextBox ID="txtEmail" runat="server" Width="320px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Reset" onclick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" >
                <asp:Label CssClass="body" Visible="False" ID="lblerror" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</div>
