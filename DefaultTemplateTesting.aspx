<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultTemplateTesting.aspx.cs" Inherits="DefaultTemplateTesting" %>

<%@ Register src="DefaultDeviceTemplateControl.ascx" tagname="DefaultDeviceTemplateControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:DefaultDeviceTemplateControl ID="DefaultDeviceTemplateControl1" runat="server" />
    
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        &nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Restore" />
        </p>
    </form>
</body>
</html>
