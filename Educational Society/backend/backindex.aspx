<%@ Page Title="" Language="C#" MasterPageFile="~/backend/backmon.Master" AutoEventWireup="true" CodeBehind="backindex.aspx.cs" Inherits="Educational_Society.backend.backindex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery-1.11.1.min.js"></script>
    <script src="../js/backindex.js"></script>
    <link href="../style/back_index.css" rel="stylesheet" />
    <div id="body">
        <div id="content">
            <div id="title">
                当前位置：<asp:Label ID="Label1" runat="server" Text="Label">新入会会员管理</asp:Label>
            </div>
            <table id="tb_menu">
                <tr>
                    <td>申请单位：<asp:TextBox ID="TextBox1" CssClass="txt" runat="server"></asp:TextBox></td>
                    <td>所在地区：<asp:DropDownList ID="DropDownList1" CssClass="drop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList><asp:DropDownList ID="DropDownList2" CssClass="drop" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                    <td>申请状态：<asp:DropDownList ID="DropDownList3" CssClass="drop" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>待审核</asp:ListItem>
                        <asp:ListItem>驳回</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>单位类型：<asp:DropDownList ID="DropDownList4" CssClass="drop" runat="server"></asp:DropDownList></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btn_search" runat="server" Text="搜索" CssClass="btn_search" OnClick="Button1_Click" /></td>
                </tr>
            </table>
            <asp:GridView ID="tb_user" CssClass="tb_user" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="tb_user_PageIndexChanging" OnRowCommand="tb_user_RowCommand">
                <Columns>
                    <asp:BoundField DataField="xuhao" HeaderText="序号" />
                    <asp:BoundField DataField="unitname" HeaderText="申请单位" />
                    <asp:BoundField DataField="unitType" HeaderText="单位类型" />
                    <asp:BoundField DataField="unitmanager" HeaderText="单位负责人" />
                    <asp:BoundField DataField="location" HeaderText="所在地区" />
                    <asp:BoundField DataField="result" HeaderText="申请状态" />
                    <asp:TemplateField>

                        <HeaderTemplate>操作</HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="more" Text="查看详情" CommandArgument='<%#Eval("id")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <h2 style="color: #1b83da">暂无数据</h2>
                </EmptyDataTemplate>
            </asp:GridView>
            <%--<table id="tb_user" border="1">
            <tr>
                <td>序号</td>
                <td>申请单位</td>
                <td>单位类型</td>
                <td>单位负责人</td>
                <td>所在地区</td>
                <td>申请状态</td>
                <td>操作</td>
            </tr>
            <tr>
                <td>1</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a></td>
            </tr>
            <tr>
                <td>2</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a></td>
            </tr>
                <tr>
                <td>3</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a></td>
            </tr>
                <tr>
                <td>4</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a></td>
            </tr>
                <tr>
                <td>5</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a></td>
            </tr>
                <tr>
                <td>6</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a></td>
            </tr>
                <tr>
                <td>7</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a></td>
            </tr>
                <tr>
                <td>8</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a></td>
            </tr>
                <tr>
                <td>9</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a></td>
            </tr>
                <tr>
                <td>10</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a></td>
            </tr>
        </table>--%>
        </div>
    </div>
</asp:Content>
