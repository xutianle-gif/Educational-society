<%@ Page Title="" Language="C#" MasterPageFile="~/backend/backmon.Master" AutoEventWireup="true" CodeBehind="voucher.aspx.cs" Inherits="Educational_Society.backend.voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../style/voucher.css" rel="stylesheet" />
    <script src="../js/jquery.js"></script>
    <script src="../js/voucher.js"></script>
    <div id="body">
        <div id="content">
            <div id="content2">
                <div id="new_year">
                    <div id="new_title">凭证退回</div>
                    <table id="tb_new">
                        <tr>
                            <td class="new1">缴费年份：</td>
                            <td><span id="lb_year">565</span><input name="test" id="test" style="display: none" class="test" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="new1">会员名称：</td>
                            <td><span id="lb_name">656</span></td>
                        </tr>
                        <tr>
                            <td class="new1">通知内容：</td>
                            <td>
                                <textarea id="txt_art" runat="server" class="textarea" cols="20" rows="2"></textarea></td>
                        </tr>
                    </table>
                    <div class="new_div">
                        <asp:Button ID="btn_add" CssClass="new_btn" runat="server" Text="确认" OnClick="btn_add_Click" /></div>
                    <div class="new_div">
                        <div class="new_btn" id="btn_back" style="float: left; margin-left: 30px; line-height: 40px;">取消</div>
                    </div>
                </div>
            </div>
            <div id="title">
                当前位置：<asp:Label ID="Label1" runat="server" Text="Label">凭证管理</asp:Label>
            </div>
            <table id="tb_menu">
                <tr>
                    <td>缴费年份：<asp:DropDownList ID="DropDownList1" CssClass="drop" runat="server"></asp:DropDownList><asp:Button ID="Button1" runat="server" Text="搜索" CssClass="btn_search" OnClick="Button1_Click" /></td>
                </tr>
            </table>
            <asp:GridView ID="tb_user" CssClass="tb_user" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnRowCreated="tb_user_RowCreated" OnRowCommand="tb_user_RowCommand" OnSelectedIndexChanged="tb_user_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="voucherid" HeaderText="缴费编号" />
                    <asp:BoundField DataField="xuhao" HeaderText="序号" />
                    <asp:BoundField DataField="payyear" HeaderText="缴费年份" />
                    <asp:BoundField DataField="unitname" HeaderText="会员名称" />
                    <asp:BoundField DataField="unitType" HeaderText="单位类型" />
                    <asp:BoundField DataField="unitmanager" HeaderText="单位负责人" />
                    <asp:BoundField DataField="addtime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="入会时间" />
                    <asp:BoundField DataField="paymoney" HeaderText="缴费金额" />
                    <asp:ImageField DataImageUrlField="voucherimg" HeaderText="转账凭证">
                    </asp:ImageField>
                    <asp:TemplateField>

                        <HeaderTemplate>操作</HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="pass" Text="审核通过" CommandArgument='<%#Eval("voucherid")%>'></asp:LinkButton>
                            <asp:Label Text="|" runat="server" style="color:black"/>
                                <span class="btn_th" id='<%#Eval("voucherid") %>'>退回</span>
                            <span id="getyear" style="display: none"><%#Eval("payyear") %></span>
                            <span id="getname" style="display: none"><%#Eval("unitname") %></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <h2 style="color: #1b83da">暂无数据</h2>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <img src="" id="bigg" alt="" class="bigimg" />
    <div class="mask">
    </div>
</asp:Content>
