<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditBook.aspx.cs" Inherits="BookManagement_ADO_NET.AddEditBook" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Book</title>
    <link rel="stylesheet" href="Assert/CSS/Styles.css"/> 
</head>
<body>
    <form id="form1" runat="server">
             <h1> Book Bank Management</h1>
        <div class="Cointainer">
            <div class="Main-Content">
                <label for="txtUser">UserName:</label>
                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox><br/>
            </div>

            <div class="Main-Content">
                <label for="txtTitle">Title:</label>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />
            </div>

            <div class="Main-Content">
                <label for="txtAuthor">Author:</label>
                <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox><br />
            </div>

            <div class="Main-Content">
                <label for="txtISBN">ISBN:</label>
                <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox><br />
            </div>
        <div class="btn">
            <asp:Button class="btnSave" runat="server" Text="Exit" OnClick="btn_Click" />
            <asp:Button class="btnSave" runat="server" Text="Add Book" OnClick="btnSave_Click" />
        </div>
            
        </div>
    </form>
</body>
</html>

