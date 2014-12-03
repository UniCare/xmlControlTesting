<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceMaster.aspx.cs" Inherits="DeviceMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvTemp" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="2" OnRowDataBound="gvTemp_RowDataBound" OnRowEditing="gvTemp_RowEditing" OnRowCancelingEdit="gvTemp_RowCancelingEdit" OnRowUpdating="gvTemp_RowUpdating">
                        <AlternatingRowStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                        <Columns>
                            <asp:TemplateField HeaderText="Control Title">
                                <EditItemTemplate>
                                   <asp:TextBox ID="txtControlTitle" Text='<%# XPath("Title") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTitle" Text='<%# XPath("Title") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ControlName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtControlName" Text='<%# XPath("FieldKeyName") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblControlName" Text='<%# XPath("FieldKeyName") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Control Type">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlControl"  runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblControlType" Text='<%# XPath("ControlType") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data Type">
                                <EditItemTemplate>
                                    <asp:DropDownList  ID="ddlDataType" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDataType" Text='<%# XPath("DataType") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data Source">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlDataSource" runat="server">
                                        <asp:ListItem Text="None"></asp:ListItem>
                                         <asp:ListItem Text="DB"></asp:ListItem>
                                         <asp:ListItem Text="INLINE"></asp:ListItem>
                                    </asp:DropDownList>
                                     <asp:Label ID="hDataSource" Visible="false" Text='<%# XPath("Source/SourceInfo/SourceType") %>' runat="server"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDataSource" Text='<%# XPath("Source/SourceInfo/SourceType") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Procedure Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtProcName"  Text='<%# XPath("Source/SourceInfo/Caption") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblProcName" Text='<%# XPath("Source/SourceInfo/Caption") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Key Name">
                                <EditItemTemplate>
                                    <table>
                                        <tr>
                                            <td style="font-weight: bold; width: 50px">Key:</td>
                                            <td>
                                                <asp:TextBox ID="txtKeyName" Text='<%# XPath("Source/SourceInfo/Key") %>' runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 50px">Value:</td>
                                            <td>
                                                <asp:TextBox ID="txtValueName"  Text='<%# XPath("Source/SourceInfo/Value") %>' runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>

                                </EditItemTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td style="font-weight: bold; width: 50px">Key:</td>
                                            <td>
                                                <asp:Label ID="lblKeyName" Text='<%# XPath("Source/SourceInfo/Key") %>' runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 50px">Value:</td>
                                            <td>
                                                <asp:Label ID="lblValueName" Text='<%# XPath("Source/SourceInfo/Value") %>' runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Parameter">
                                <EditItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtParameterName" Text='<%# XPath("//SQLParameter") %>'  runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>

                                </EditItemTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                               
                                                    <asp:Label ID="lblParameterName" Text='<%# XPath("//SQLParameter") %>' runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:CommandField ShowDeleteButton="True" />
                            <asp:CommandField ShowEditButton="True" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Font-Size="10pt" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />

                    </asp:GridView>
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
