<%@ Page Title="" Language="C#" MasterPageFile="~/backend/backmon.Master" AutoEventWireup="true" CodeBehind="Payyear.aspx.cs" Inherits="Educational_Society.backend.Payyear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../style/Payyear.css" rel="stylesheet" />
    <script src="../js/jquery.js"></script>
    <script src="../js/payyear.js"></script>
    <div id="body">
        <div id="content">
            <div id="content2">
                <div id="new_year">
                    <div id="new_title">新增缴费年份</div>
                    <table id="tb_new">
                        <tr>
                            <td class="new1">当前缴费年份：</td>
                            <td>
                                <asp:TextBox ID="txt_year" CssClass="new_txt" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="new1">缴费金额：</td>
                            <td>
                                <asp:TextBox ID="txt_money" CssClass="new_txt" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="new1">通知内容：</td>
                            <td>
                                <textarea id="txt_art" runat="server" class="textarea" cols="20" rows="2"></textarea></td>
                        </tr>
                        <tr>
                            <td class="new1">缴费状态</td>
                            <td>启用</td>
                        </tr>
                    </table>
                    <div class="new_div">
                        <asp:Button ID="btn_add" CssClass="new_btn" runat="server" Text="添加" OnClick="btn_add_Click" />
                    </div>
                    <div class="new_div">
                        <div class="new_btn" id="btn_back" style="float: left; margin-left: 30px; line-height: 40px;">取消</div>
                    </div>
                </div>
            </div>
            <div id="title">
                当前位置：<asp:Label ID="Label1" runat="server" Text="Label">会费缴费年份管理</asp:Label>
            </div>
            <div class="btn_new" id="btn_new">新增缴费年份</div>
            <asp:GridView ID="tb_user" CssClass="tb_user" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="tb_user_PageIndexChanging" OnSelectedIndexChanged="tb_user_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="xuhao" HeaderText="序号" />
                    <asp:BoundField DataField="payyear" HeaderText="缴费年份" />
                    <asp:BoundField DataField="paytext" HeaderText="通知内容" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <asp:Label ID="lblPaymentStatus" runat="server" Text='<%# Eval ("paystatus") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>

                        <HeaderTemplate>操作</HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbOpen" runat="server" OnCommand="lkbOpen_Command" CommandArgument='<%# Eval ("payyear") %>' OnClientClick="return confirm('确定启用该缴费年份吗？')" Visible="false">启用</asp:LinkButton>
                            <asp:LinkButton ID="lkbFrozen" runat="server" OnCommand="lkbFrozen_Command" CommandArgument='<%# Eval ("payyear") %>' OnClientClick="return confirm('确定禁用该缴费年份吗？')">禁用</asp:LinkButton>
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
                <td>缴费年份</td>
                <td>通知内容</td>
                <td>禁用</td>
                <td>操作</td>
            </tr>
            <tr>
                <td>1</td>
                <td>2000</td>
                <td>通知内容通知内容通知内容</td>
                <td>禁用</td>
                <td><a href="#">禁用</a></td>
            </tr>
            <tr>
                <td>2</td>
                <td>2000</td>
                <td>通知内容通知内容通知内容</td>
                <td>禁用</td>
                <td><a href="#">禁用</a></td>
            </tr>
                <tr>
                <td>3</td>
                <td>2000</td>
                <td>通知内容通知内容通知内容</td>
                <td>禁用</td>
                <td><a href="#">禁用</a></td>
            </tr>
                <tr>
                <td>4</td>
                <td>2000</td>
                <td>通知内容通知内容通知内容</td>
                <td>禁用</td>
                <td><a href="#">禁用</a></td>
            </tr>
                <tr>
                <td>5</td>
                <td>2000</td>
                <td>通知内容通知内容通知内容</td>
                <td>禁用</td>
                <td><a href="#">禁用</a></td>
            </tr>
                <tr>
                <td>6</td>
                <td>2000</td>
                <td>通知内容通知内容通知内容</td>
                <td>禁用</td>
                <td><a href="#">禁用</a></td>
            </tr>
                <tr>
                <td>7</td>
                <td>2000</td>
                <td>通知内容通知内容通知内容</td>
                <td>禁用</td>
                <td><a href="#">禁用</a></td>
            </tr>
                <tr>
                <td>8</td>
                <td>2000</td>
                <td>通知内容通知内容通知内容</td>
                <td>禁用</td>
                <td><a href="#">禁用</a></td>
            </tr>
                <tr>
                <td>9</td>
                <td>2000</td>
                <td>通知内容通知内容通知内容</td>
                <td>禁用</td>
                <td><a href="#">禁用</a></td>
            </tr>
                <tr>
                <td>10</td>
                <td>2000</td>
                <td>通知内容通知内容通知内容</td>
                <td>禁用</td>
                <td><a href="#">禁用</a></td>
            </tr>
        </table>--%>
        </div>
    </div>
</asp:Content>
