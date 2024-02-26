<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register3.aspx.cs" Inherits="Educational_Society.frontend.register3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../js/jquery.js"></script>
    <script src="../js/MiniDialog-es5.min.js"></script>
    <script src="../js/register3.js"></script>
    <link href="../style/register.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <span>江苏省职教协会-会员注册</span>
        </div>
        <div id="body">
            <div id="content">
                <asp:ImageButton ID="ImageButton1" CssClass="back" ImageUrl="/img/back.png" runat="server" OnClick="ImageButton1_Click" OnClientClick="javascript:return confirm('你确定要退出注册吗？您的记录将不保存！')" />
                <div id="menu">
                    <div class="get">
                        <div class="getreg" id="reg1">1</div>
                        <span>基本信息</span></div>
                    <div class="get">
                        <div class="getreg" id="reg2">2</div>
                        <span>联系信息</span></div>
                    <div class="get">
                        <div class="getreg" id="reg3">3</div>
                        <span>登录信息</span></div>
                    <div class="get">
                        <div class="getreg" id="reg4">4</div>
                        <span>服务条款</span></div>
                </div>
                <div id="getreg3" class="reg">
                    <div class="jieshao">
                        <span style="float: left">登录信息</span>
                        <span style="font-size: 14px">注意带有*号的必须填写</span>
                    </div>
                    <table class="tb_reg">
                        <tr>
                            <td class="reg1">用户名：</td>
                            <td class="reg2">
                                <asp:TextBox ID="txt_name" runat="server" CssClass="input"></asp:TextBox></td>
                            <td class="reg3">
                                <div id="g1" runat="server" class="reg4">请设置登录网站的用户名 *</div>
                            </td>
                        </tr>

                        <tr>
                            <td class="reg1"><span style="width: 70px">电子邮箱：</span></td>
                            <td class="reg2">
                                <asp:TextBox ID="txt_email" runat="server" CssClass="input"></asp:TextBox><input style="display: none" runat="server" id="test_yzm" value="1" /></td>
                            <td class="reg3">
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" class="getyzm">发送验证码</asp:LinkButton><span id="spanyz" class="yz_span" runat="server" style="color: white">0</span><asp:Label ID="Label1" runat="server" Text="" Class="yztime"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="reg1"><span style="width: 70px">验证码：</span></td>
                            <td class="reg2">
                                <asp:TextBox ID="txt_yzm" runat="server" CssClass="input"></asp:TextBox></td>
                            <td class="reg3">
                                <div id="g2" runat="server" class="reg4">请输入验证码 *</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="reg1">密码：</td>
                            <td class="reg2">
                                <asp:TextBox ID="txt_password" runat="server" CssClass="input" TextMode="Password"></asp:TextBox></td>
                            <td class="reg3">
                                <div id="g3" runat="server" class="reg4">请设置登录网站的密码 *</div>
                            </td>
                        </tr>
                          <tr>
                            <td class="reg1">重复密码：</td>
                            <td class="reg2">
                                <asp:TextBox ID="txt_repeatpassword" runat="server" CssClass="input" TextMode="Password"></asp:TextBox></td>
                            <td class="reg3">
                                <div id="g4" runat="server" class="reg4" style="display:none">两次密码不一致 *</div>
                            </td>
                        </tr>

                        <tr>
                            <td class="reg1"></td>
                            <td class="reg2">
                                <asp:Button Text="下一步" runat="server" ID="btnNext" OnClick="btnNext_Click" /></td>
                            <td class="reg3"></td>
                        </tr>
                    </table>
                </div>
            </div>
    </form>
</body>
</html>
