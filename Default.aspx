<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <link href="StyleSheet.css" rel="stylesheet" />
    <script src="scripts/Script.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainContainer">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Post" OnClick="Button1_Click" />
            <br />
            <ul class="displayContainer">
                <%=words%>
            </ul>
        </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
