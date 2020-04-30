<%@ Page Title="Ultimate Task List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsDemo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="well">
        <h2>Add Task</h2>

        <asp:Panel runat="server" CssClass="form" DefaultButton="AddTask">
            <div class="form-group">
                <label>Task</label>
                <div>
                    <asp:TextBox ID="NewTaskName" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <label>Categories</label>
                <div>
                    <asp:CheckBoxList ID="NewTaskCategories" runat="server"
                        DataTextField="CategoryName" DataValueField="Id"
                        RepeatDirection="Horizontal" />
                </div>
            </div>

            <div class="form-group">
                <asp:Button ID="AddTask" runat="server" Text="Add Task"
                    CssClass="btn btn-primary" OnClick="AddTask_Click" />
            </div>
        </asp:Panel>
    </div>

    <asp:Repeater ID="Tasks" runat="server" OnItemDataBound="Tasks_ItemDataBound">
        <HeaderTemplate>
            <div class="list-group">
        </HeaderTemplate>
        
        <ItemTemplate>
            <div class="list-group-item">
                <%#: Eval("TaskName") %>

                <asp:Repeater ID="TaskCategories" runat="server">
                    <ItemTemplate>
                        <span class="<%# "badge badge-" + (string)Eval("CategoryColor") %>">
                            <%#: Eval("CategoryName") %>
                        </span>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>

        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
