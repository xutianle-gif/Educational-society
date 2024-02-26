<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register2.aspx.cs" Inherits="Educational_Society.frontend.register2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery.js"></script>
    <script src="../js/MiniDialog-es5.min.js"></script>
    <script src="../js/register2.js"></script>
    <link href="../style/register.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="header">
                <span>江苏省职教协会-会员注册</span>
            </div>
            <div id="body">
                <div id="content">
                    <asp:ImageButton ID="ImageButton1" CssClass="back" ImageUrl="/img/back.png" runat="server" OnClick="ImageButton1_Click" OnClientClick="javascript:return confirm('你确定要退出注册吗？您的记录将不保存！')"/>
                    <div id="menu">
                        <div class="get">
                            <div class="getreg" id="reg1">1</div>
                            <span>基本信息</span>
                        </div>
                        <div class="get">
                            <div class="getreg" id="reg2">2</div>
                            <span>联系信息</span>
                        </div>
                        <div class="get">
                            <div class="getreg" id="reg3">3</div>
                            <span>登录信息</span>
                        </div>
                        <div class="get">
                            <div class="getreg" id="reg4">4</div>
                            <span>服务条款</span>
                        </div>
                    </div>
                    <div id="getreg2" class="reg">
                        <div class="jieshao">
                            <span style="float: left">联系人信息</span>
                            <span style="font-size: 14px">注意带有*号的必须填写</span>
                        </div>
                        <table class="tb_reg">
                            <tr>
                                <td class="reg1">联系人姓名：</td>
                                <td class="reg2">
                                    <asp:TextBox ID="txt_tname" runat="server" CssClass="input"></asp:TextBox></td>
                                <td class="reg3">
                                    <div id="g1" class="reg4" runat="server">请输入联系人的姓名 *</div>
                                </td>
                            </tr>
                            <tr>
                                <td class="reg1">联系人电话：</td>
                                <td class="reg2">
                                    <asp:TextBox ID="txt_tel" runat="server" CssClass="input"></asp:TextBox></td>
                                <td class="reg3">
                                    <div id="g2" runat="server" class="reg4">手机号或办公电话 *</div>
                                </td>
                            </tr>
                            <tr>
                                <td class="reg1"><span style="width: 70px">上传联系人身份证<br />
                                    （正面、反面）：</span></td>
                                <td class="reg2">
                                      <asp:FileUpload ID="FileUpload1" onchange="javascript:__doPostBack('lbUploadPhoto','')" runat="server" /><asp:LinkButton ID="lbUploadPhoto" OnClick="lbUploadPhoto_Click" runat="server"></asp:LinkButton> <img src="../img/加.png" id="pic" class="add1" runat="server" />
                                   <asp:FileUpload ID="FileUpload2" onchange="javascript:__doPostBack('lbUploadPhoto1','')" runat="server" /> <asp:LinkButton ID="lbUploadPhoto1" OnClick="lbUploadPhoto1_Click" runat="server"></asp:LinkButton><img src="../img/加.png" id="pic2" class="add1" runat="server" /></td>
                                <td class="reg3"><div id="g3" runat="server" class="reg4">请上传联系人身份证正反面 *</div></td>
                            </tr>
                            <tr>
                                <td class="reg1"><span style="width: 70px">联系人手持身份证照片：</span></td>
                                <td class="reg2">
                                      <asp:FileUpload ID="FileUpload3" onchange="javascript:__doPostBack('lbUploadPhoto2','')" runat="server" /> <asp:LinkButton ID="lbUploadPhoto2" OnClick="lbUploadPhoto2_Click" runat="server"></asp:LinkButton> <img src="../img/加.png" id="pic3" class="add1" runat="server" />
                                </td>
                                <td class="reg3"><div id="g4" runat="server" class="reg4">请上传联系人手持 *</div></td>
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

            </div>
    </form>
</body>
</html>
