<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register src="DeviceTemplateControl.ascx" tagname="DeviceTemplateControl" tagprefix="uc2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:DropDownList ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server">
                <asp:ListItem Text="1"></asp:ListItem>
                <asp:ListItem Text="2"></asp:ListItem>
                <asp:ListItem Text="3"></asp:ListItem>
            </asp:DropDownList>
            <br />
        </p>
    <div>
        
        <uc2:DeviceTemplateControl ID="DeviceTemplateControl1" runat="server" />
        
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRestore" runat="server" OnClick="btnRestore_Click" Text="Restore" />
        </p>
    </form>
</body>
</html>
