<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> FormulaOne - WebForm </title>
</head>
<body>
    <form id="form1" runat="server">
            <asp:DropDownList ID="lstTables" runat="server" OnSelectedIndexChanged="changeSelection" AutoPostBack="true">

            </asp:DropDownList>
        <br />
        <div>
            <asp:DataGrid ID="dgvItems" runat="server"></asp:DataGrid>
        </div>
    </form>
</body>
</html>
