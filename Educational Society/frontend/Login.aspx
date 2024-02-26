<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Educational_Society.frontend.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../style/LoginCss.css" rel="stylesheet" />
</head>
<body style="overflow-y:hidden">
    <form id="form1" runat="server">
        <div id="all">
            <div id="topmain"></div>
            <div id="main">
                <div id="iconAndTitle">
                    <img src="../img/书.png" class="bookControl" /><h2 class="h"><font color="white">欢迎登陆</font></h2>
                </div>
                <table id="tb_user">
                    <tr class="tatr">
                        <td class="td1"><h3><font color="#fff">用户名：</font></h3>
                        </td>
                        <td>
                            <asp:TextBox ID="txtuser" runat="server" class="textboxcss" />
                            <asp:Label ID="lblPleaseInputUser" Text="请输入用户名！" runat="server" Visible="false" ForeColor="Red"/>
                        </td>
                    </tr>
                    <tr class="tatr">
                        <td class="td1"><h3><font color="#fff">密码：</font></h3>
                        </td>
                        <td class="tatr">
                            <asp:TextBox ID="txtpassword" runat="server" class="textboxcss" TextMode="Password" />
                            <asp:Label ID="lblPleaseInputPassword" Text="请输入密码！" runat="server" Visible="false" ForeColor="Red"/>
                        </td>
                      
                    </tr>
                    <tr class="tatr">
                        <td></td>
                        <td class="tatr2">
                            <asp:LinkButton Text="找回密码" runat="server" CssClass="a" ID="lbFind" OnClick="lbFind_Click" />
                            <asp:LinkButton Text="没有账户？立即注册" runat="server" CssClass="a" ID="lbCreate" OnClick="lbCreate_Click" />
                        </td>

                    </tr>
                    <tr class="tatr">
                        <td></td>
                        <td style="text-align: center">
                            <asp:Button Text="登录" runat="server" ID="lg" OnClick="lg_Click"  />
                        </td>

                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
