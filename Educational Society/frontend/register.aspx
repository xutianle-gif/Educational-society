<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Educational_Society.frontend.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script src="../js/jquery.js"></script>
    <script src="../js/MiniDialog-es5.min.js"></script>
    <script src="../js/register.js"></script>
    <link href="../style/register.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
    <span>江苏省职教协会-会员注册</span>
    </div>
    <div id="body">
    <div id="content">
        <asp:ImageButton ID="ImageButton1" CssClass="back" ImageUrl="/img/back.png" runat="server" OnClick="ImageButton1_Click" />
        <div id="menu">
            <div class="get"><div class="getreg" id="reg1">1</div><span>基本信息</span></div>
            <div class="get"><div class="getreg" id="reg2">2</div><span>联系信息</span></div>
            <div class="get"><div class="getreg" id="reg3">3</div><span>登录信息</span></div>
            <div class="get"><div class="getreg" id="reg4">4</div><span>服务条款</span></div>
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
                    <td class="reg3"><div class="reg4">请输入单位的名称 *</div></td>
                </tr>
                <tr>
                    <td class="reg1">单位类型：</td>
                    <td class="reg2"><asp:DropDownList ID="DropDownList3" CssClass="drop1" runat="server"></asp:DropDownList></td>
                    <td class="reg3"></td>
                </tr>
                <tr>
                    <td class="reg1">所在城市：</td>
                    <td class="reg2"><asp:DropDownList ID="DropDownList1" CssClass="drop2" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> * <asp:DropDownList ID="DropDownList2" CssClass="drop2" runat="server"></asp:DropDownList> * </td>
                    <td class="reg3"></td>
                </tr>
                <tr>
                    <td class="reg1">详细地址：</td>
                    <td class="reg2"><asp:TextBox ID="txt_address" runat="server" CssClass="input"></asp:TextBox></td>
                    <td class="reg3"><div class="reg4">请输入单位的详细地址 *</div></td>
                </tr>
                <tr>
                    <td class="reg1">邮政编码：</td>
                    <td class="reg2"><asp:TextBox ID="txt_mail" runat="server" CssClass="input"></asp:TextBox></td>
                    <td class="reg3"><div class="reg4">请输入单位的邮政编码 *</div></td>
                </tr>
                <tr>
                    <td class="reg1">入会时间：</td>
                    <td class="reg2"><input type="date" id="txt_time" class="input" runat="server" /></td>
                    <td class="reg3"><div class="reg4">已入会成员填写 *</div></td>
                </tr>
                <tr>
                    <td class="reg1">单位法人：</td>
                    <td class="reg2"><asp:TextBox ID="txt_person" runat="server" CssClass="input"></asp:TextBox></td>
                    <td class="reg3"></td>
                </tr>
                <tr>
                    <td class="reg1"><span style="width:70px">上传营业执照或法人证书：</span></td>
                    <td class="reg2"><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                    <td class="reg3"></td>
                </tr>
            </table>
        </div>
        <div id="getreg2" class="reg">
            <div class="jieshao">
                <span style="float:left">联系人信息</span>
                <span style="font-size:14px">注意带有*号的必须填写</span>
            </div>
            <table class="tb_reg">
                <tr>
                    <td class="reg1">联系人姓名：</td>
                    <td class="reg2"><asp:TextBox ID="txt_tname" runat="server" CssClass="input"></asp:TextBox></td>
                    <td class="reg3"><div class="reg4">请输入联系人的姓名 *</div></td>
                </tr>
                <tr>
                    <td class="reg1">联系人电话：</td>
                    <td class="reg2"><asp:TextBox ID="txt_tel" runat="server" CssClass="input"></asp:TextBox></td>
                    <td class="reg3"><div class="reg4">手机号或办公电话 *</div></td>
                </tr>
                <tr>
                    <td class="reg1"><span style="width:70px">上传联系人身份证<br />（正面、反面）：</span></td>
                    <td class="reg2"><asp:FileUpload ID="FileUpload2" runat="server" />
                        <asp:FileUpload ID="FileUpload3" runat="server" /></td>
                    <td class="reg3"></td>
                </tr>
                <tr>
                    <td class="reg1"><span style="width:70px">联系人手持身份证照片：</span></td>
                    <td class="reg2"><asp:FileUpload ID="FileUpload4" runat="server" /></td>
                    <td class="reg3"></td>
                </tr>
            </table>
        </div>
        <div id="getreg3" class="reg">
            <div class="jieshao">
                <span style="float:left">登录信息</span>
                <span style="font-size:14px">注意带有*号的必须填写</span>
            </div>
            <table class="tb_reg">
                <tr>
                    <td class="reg1">用户名：</td>
                    <td class="reg2"><asp:TextBox ID="txt_name" runat="server" CssClass="input"></asp:TextBox></td>
                    <td class="reg3"><div class="reg4">请设置登录网站的用户名 *</div></td>
                </tr>
                <tr>
                    <td class="reg1">密码：</td>
                    <td class="reg2"><asp:TextBox ID="txt_password" runat="server" CssClass="input" TextMode="Password"></asp:TextBox></td>
                    <td class="reg3"><div class="reg4">请设置登录网站的密码 *</div></td>
                </tr>
                <tr>
                    <td class="reg1"><span style="width:70px">电子邮箱：</span></td>
                    <td class="reg2"><asp:TextBox ID="txt_email" runat="server" CssClass="input"></asp:TextBox><input style="display:none" runat="server" id="test_yzm" value="1" /></td>
                    <td class="reg3"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">发送验证码</asp:LinkButton></td>
                </tr>
                <tr>
                    <td class="reg1"><span style="width:70px">验证码：</span></td>
                    <td class="reg2"><asp:TextBox ID="txt_yzm" runat="server" CssClass="input"></asp:TextBox></td>
                    <td class="reg3"></td>
                </tr>
            </table>
        </div>
        <div id="getreg4" class="reg">
            <div class="jieshao">
                <span style="float:left">服务条款</span>
            </div>
            <div id="tiaokuan">
                我已阅读中华人民共和国人民宪法，恪尽职守本分，尽到公民业务，我对账户信息的使用将接受职教百科公共信息服务平台信息条款的约束并遵守中华人民共和国法律
            </div>
            <div id="shuru">
            <textarea readonly="readonly" id="TextArea1" class="txt_area" cols="20" rows="2">欢迎申请江苏省职业教育平台！在您注册过程中,您需要完成我们的注册流程并通过点击同意的形式在线签署以下协议，请您务必仔
细阅读、充分理解协议中的条款内容后再击同意(尤其是以粗体或下划线标识的条款,因为这些条款可能会明确您应履行的
义务或对您的权利有所限制)。
[请您注意]如果您不同意以下协议全部或任何条款约定,请您停止注册。您停止注册后将仅可以浏览我们的商品信息但无法
享受我们的产品或服务。如您按照注册流程提示填写信息，阅读并点击同意上述协议且完成全部注册流程后，即表示您已充分
阅读、理解并接受协议的全部内容，并表明您同意我们可以依据协议内容来处理您的个人信息，并同意我们将您的订单信息共
享给为完成此订单所必须的第三方合作方(详情查看《订单共享与安全》)。如您对以下协议内容有任何疑问,您可随时通过
《京东隐私政策》中的联系方式联系我们。
如您在使用我们的产品或服务中与其他用户发生争议的，依您与其他用户达成的协议处理。</textarea>
            </div>
            <div id="check">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="我同意" />
            </div>
            <div class="div" style="text-align:right"><asp:Button ID="btn_ok" CssClass="button" runat="server" Text="提交" OnClick="btn_ok_Click" /></div>
            <div class="div" style="text-align:left"><asp:Button ID="btn_back" CssClass="button" runat="server" Text="取消" OnClick="btn_back_Click" /></div>
        </div>
    </div>
    </div>       
<%--    <div id="footer">
        <div id="footer_a"><a href="#">关于我们</a>|<a href="#">联系我们</a>|<a href="#">客服解答</a>|<a href="#">风险监测</a>|<a href="#">协会社区</a>|<a href="#">协会风采</a>|<a href="#">合作联系</a>|<a href="#">English site</a></div>
        <div id="footer_nr">
        <label>请使用1024*768 IE7.0 或更高版本浏览器浏览本站点，以保证最佳阅读效果</label><br />
            <label>◎Copyright 2020江苏职教学会版权所有A11 Rights Reserved</label>
        </div>
    </div>--%>
    </form>
</body>
</html>
