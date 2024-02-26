<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register1.aspx.cs" Inherits="Educational_Society.frontend.register1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
       <script src="../js/jquery.js"></script>
    <script src="../js/MiniDialog-es5.min.js"></script>
    <script src="../js/register1.js"></script>
    <link href="../style/register.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 20%;
            font-size: 16px;
            text-align: right;
            letter-spacing: 1px;
            height: 49px;
        }
        .auto-style2 {
            width: 20%;
            padding-left: 20px;
            height: 49px;
        }
        .auto-style3 {
            width: 45%;
            height: 49px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div id="header">
    <span>江苏省职教协会-会员注册</span>
    </div>
    <div id="body">
    <div id="content">
        <asp:ImageButton ID="ImageButton1" CssClass="back" ImageUrl="/img/back.png" runat="server" OnClick="ImageButton1_Click" OnClientClick="javascript:return confirm('你确定要退出注册吗？您的记录将不保存！')" />
        <div id="menu">
            <div class="get"><div class="getreg" id="reg1">1</div><span>基本信息</span></div>
            <div class="get"><div class="getreg" id="reg2">2</div><span>联系信息</span></div>
            <div class="get"><div class="getreg" id="reg3">3</div><span>登录信息</span></div>
            <div class="get"><div class="getreg" id="reg4">4</div><span>服务条款</span></div>
        </div>
        <div id="leakerror">

        </div>
        <div id="getreg1" class="reg">
            <div class="jieshao">
                <span style="float:left">基本信息</span>
                <span style="font-size:14px">注意带有*号的必须填写</span>
            </div>
            <table class="tb_reg">
                <tr>
                    <td class="reg1">单位名称：</td>
                    <td class="reg2"><asp:TextBox ID="pic_name" runat="server" CssClass="input"></asp:TextBox></td>
                    <td class="reg3"><div id="g1" class="reg4" runat="server">请输入单位的名称 *</div></td>
                </tr>
                <tr>
                    <td class="reg1">单位类型：</td>
                    <td class="reg2"><asp:DropDownList ID="DropDownList3" CssClass="drop1" runat="server"></asp:DropDownList></td>
                    <td class="reg3"></td>
                </tr>
                <tr>
                    <td class="reg1">所在城市：</td>
                    <td class="reg2"><asp:DropDownList ID="DropDownList1" CssClass="drop2" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> * <asp:DropDownList ID="DropDownList2" CssClass="drop2" runat="server"></asp:DropDownList> * </td>
                     <td class="auto-style3"><div id="Div1" runat="server" class="reg4">请选择所在城市 *</div></td>
                </tr>
                <tr>
                    <td class="auto-style1">详细地址：</td>
                    <td class="auto-style2"><asp:TextBox ID="txt_address" runat="server" CssClass="input"></asp:TextBox></td>
                    <td class="auto-style3"><div id="g2" runat="server" class="reg4">请输入单位的详细地址 *</div></td>
                </tr>
                <tr>
                    <td class="reg1">邮政编码：</td>
                    <td class="reg2"><asp:TextBox ID="txt_mail" runat="server" CssClass="input"></asp:TextBox></td>
                    <td class="reg3"><div id="g3" runat="server" class="reg4">请输入单位的邮政编码 *</div></td>
                </tr>
                <tr>
                    <td class="reg1">入会时间：</td>
                    <td class="reg2"><input type="date" id="txt_time" class="input" runat="server" name="content"/></td>
                    <td class="reg3"><div class="reg4">已入会成员填写 </div></td>
                </tr>
                <tr>
                    <td class="reg1">单位法人：</td>
                    <td class="reg2"><asp:TextBox ID="txt_person" runat="server" CssClass="input"></asp:TextBox></td>
                    <td class="reg3"></td>
                </tr>
                <tr>
                    <td class="reg1"><span style="width:70px">上传营业执照或法人证书：</span></td>
                    <td class="reg2"><asp:FileUpload ID="FileUpload1" onchange="javascript:__doPostBack('lbUploadPhoto','')" runat="server" /><asp:LinkButton ID="lbUploadPhoto" OnClick="lbUploadPhoto_Click" runat="server"></asp:LinkButton> <img src="../img/加.png" id="pic" class="add1" runat="server" /></td>
                    <td class="reg3"><div id="g4" class="reg4" runat="server">请上传营业执照或法人证书 * </div></td>
                </tr>
                 <tr>
                    <td class="reg1"></td>
                    <td class="reg2">
                        <asp:Button Text="下一步" runat="server" ID="btnNext" OnClick="btnNext_Click"/></td>
                    <td class="reg3"></td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
