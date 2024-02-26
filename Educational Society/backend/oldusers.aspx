<%@ Page Title="" Language="C#" MasterPageFile="~/backend/backmon.Master" AutoEventWireup="true" CodeBehind="oldusers.aspx.cs" Inherits="Educational_Society.backend.oldusers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../style/oldusers.css" rel="stylesheet" />
    <div id="body">
        <div id="content">
        <div id="title">
            当前位置：<asp:Label ID="Label1" runat="server" Text="Label">已入会会员管理</asp:Label>
        </div>
            <table id="tb_menu">
                <tr>
                    <td>会员名称：<asp:TextBox ID="TextBox1" CssClass="txt" runat="server"></asp:TextBox></td>
                    <td>单位类型：<asp:DropDownList ID="DropDownList4" CssClass="drop" runat="server"></asp:DropDownList></td>
                    <td>所在地区：<asp:DropDownList ID="DropDownList1" CssClass="drop" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><asp:DropDownList ID="DropDownList2" CssClass="drop" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2">入会时间：<input id="date1" type="date" class="txt_date" runat="server" />至 <input id="date2" style="margin-left:50px" class="txt_date" type="date" runat="server" /></td>
                    <td>会员状态：<asp:DropDownList ID="DropDownList3" CssClass="drop" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>启用</asp:ListItem>
                        <asp:ListItem>冻结</asp:ListItem>
                        </asp:DropDownList><asp:Button ID="Button1" runat="server" Text="搜索" CssClass="btn_search" OnClick="Button1_Click" /></td>
                </tr>
            </table>
            <asp:GridView ID="tb_user" CssClass="tb_user" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="tb_user_PageIndexChanging" OnRowCommand="tb_user_RowCommand">
                <Columns>
                    <asp:BoundField DataField="xuhao" HeaderText="序号" />
                    <asp:BoundField DataField="unitname" HeaderText="申请单位" />
                    <asp:BoundField DataField="unitType" HeaderText="单位类型" />
                    <asp:BoundField DataField="unitmanager" HeaderText="单位负责人" />
                    <asp:BoundField DataField="location" HeaderText="所在地区" />
                    <asp:BoundField DataField="addtime" HeaderText="入会时间" DataFormatString="{0:yyyy-MM-dd}" />
                     <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <asp:Label ID="lblPaymentStatus" runat="server" Text='<%# Eval ("state") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>

                            <HeaderTemplate>操作</HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="more"  Text="查看详情" CommandArgument='<%#Eval("id")%>' ></asp:LinkButton>
                                <asp:Label Text="|" runat="server" style="color:#000;"/>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="ice"  Text="冻结" CommandArgument='<%#Eval("id")%>' Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="start"  Text="启用" CommandArgument='<%#Eval("id")%>' ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                        <h2 style="color:#1b83da">暂无数据</h2>
                    </EmptyDataTemplate>
            </asp:GridView>
            <%--<table id="tb_user" border="1">
            <tr>
                <td>序号</td>
                <td>申请单位</td>
                <td>单位类型</td>
                <td>单位负责人</td>
                <td>所在地区</td>
                <td>入会时间</td>
                <td>状态</td>
                <td>操作</td>
            </tr>
            <tr>
                <td>1</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>2000-0-0</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a>|<a href="#">冻结</a></td>
            </tr>
            <tr>
                <td>2</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                <td>2000-0-0</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a>|<a href="#">冻结</a></td>
            </tr>
                <tr>
                <td>3</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                    <td>2000-0-0</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a>|<a href="#">冻结</a></td>
            </tr>
                <tr>
                <td>4</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                    <td>2000-0-0</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a>|<a href="#">冻结</a></td>
            </tr>
                <tr>
                <td>5</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                    <td>2000-0-0</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a>|<a href="#">冻结</a></td>
            </tr>
                <tr>
                <td>6</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                    <td>2000-0-0</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a>|<a href="#">冻结</a></td>
            </tr>
                <tr>
                <td>7</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                    <td>2000-0-0</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a>|<a href="#">冻结</a></td>
            </tr>
                <tr>
                <td>8</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                    <td>2000-0-0</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a>|<a href="#">冻结</a></td>
            </tr>
                <tr>
                <td>9</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                    <td>2000-0-0</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a>|<a href="#">冻结</a></td>
            </tr>
                <tr>
                <td>10</td>
                <td>申请单位测试数据</td>
                <td>类型测试</td>
                <td>负责人测试</td>
                <td>地区测试</td>
                    <td>2000-0-0</td>
                <td>申请状态测试</td>
                <td><a href="#">查看详情</a>|<a href="#">冻结</a></td>
            </tr>
        </table>--%>
        </div>
        </div>
</asp:Content>
