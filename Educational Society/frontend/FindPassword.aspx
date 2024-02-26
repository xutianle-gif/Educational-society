<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPassword.aspx.cs" Inherits="Educational_Society.frontend.FindPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../style/FindPasswordCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div id="belowtop">
            <div>
                <div id="head">
                    <div id="bookdiv">
                        <img src="../img/blackbook.png" class="bookControl" />
                    </div>
                    <div id="title">
                        <font><h3>找回密码</h3></font>
                    </div>
                </div>
                <div id="line"></div>
                <div id="middle">
                    <table id="middletable">
                        <tr class="tatr">
                            <td>用户名：
                            </td>
                            <td>
                                <asp:TextBox ID="txtuser" runat="server" class="textboxcss" /></td>
                        </tr>
                        <tr class="tatr">
                            <td>电子邮箱：
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" class="textboxcss" /></td>
                            <td>
                                <asp:LinkButton Text="发送验证码" runat="server" ID="lbFind" OnClick="lbFind_Click" /></td>
                        </tr>
                        <tr class="tatr">
                            <td>验证码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtCode" runat="server" class="textboxcss" OnTextChanged="txtCode_TextChanged" AutoPostBack="true" /></td>

                        </tr>
                        <tr class="tatr">
                            <td>新密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewpassword" runat="server" class="textboxcss" TextMode="Password" /></td>

                        </tr>
                        <tr class="tatr">
                            <td>重复新密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtRepeatNewpassword" runat="server" class="textboxcss" TextMode="Password" /></td>

                        </tr>
                        <tr class="tatr">
                            <td></td>
                            <td>
                                <asp:Button Text="确定" runat="server" ID="btnConfirm" Class="btn" OnClick="btnConfirm_Click" />

                                <asp:Button Text="返回" runat="server" ID="btnback" class="btn" OnClick="btnback_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="footer">
                    <div id="footer_a"><a href="#">关于我们</a>|<a href="#">联系我们</a>|<a href="#">客服解答</a>|<a href="#">风险监测</a>|<a href="#">协会社区</a>|<a href="#">协会风采</a>|<a href="#">合作联系</a>|<a href="#">English site</a></div>
                    <div id="footer_nr">
                        <label>请使用1024*768 IE7.0 或更高版本浏览器浏览本站点，以保证最佳阅读效果</label><br />
                        <label>◎Copyright 2020江苏职教学会版权所有A11 Rights Reserved</label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
