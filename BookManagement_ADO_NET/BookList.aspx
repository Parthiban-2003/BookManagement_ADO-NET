<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="BookManagement_ADO_NET.BookList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Management</title>
    <link rel="stylesheet" href="Assert/CSS/List.css"/>
</head>
<body>
    <a href="AddEditBook.aspx" id="btn"><</a><br/><br/>
    <form id="form1" runat="server">
            <asp:GridView ID="GridViewed" runat="server" AutoGenerateColumns="False"  OnRowEditing="Edit_Book" OnRowDeleting="Delete_Book" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                    <asp:TemplateField HeaderText="UserName">
                        <ItemTemplate> <%# Eval("UserName") %> </ItemTemplate>

                        <EditItemTemplate>
                             <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("UserName") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Title">
                        <ItemTemplate> <%# Eval("Title") %> </ItemTemplate>

                        <EditItemTemplate> 
                            <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Author">
                        <ItemTemplate> <%# Eval("Author") %> </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtAuthor" runat="server" Text='<%# Bind("Author") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ISBN">
                        <ItemTemplate> <%# Eval("ISBN") %> </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtISBN" runat="server" Text='<%# Bind("ISBN") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Operations">
                            <ItemTemplate>
                           <div class="buttons">
                                <asp:LinkButton class="btn" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' Text="Edit" />
                                <asp:LinkButton class="btn" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' Text="Delete" OnClick="Delete_Book" />
                           </div>
                                    </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
    </form>

</body>
</html>
