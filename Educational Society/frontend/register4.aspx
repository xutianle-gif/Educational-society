<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register4.aspx.cs" Inherits="Educational_Society.frontend.register4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery.js"></script>
    <script src="../js/MiniDialog-es5.min.js"></script>
    <script src="../js/register4.js"></script>
    <link href="../style/register.css" rel="stylesheet" />
</head>
<body>
 <form id="form2" runat="server">
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
                        <div id="getreg4" class="reg">
                            <div class="jieshao">
                                <span style="float: left">服务条款</span>
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
                            <div class="div" style="text-align: right">
                                <asp:Button ID="btn_ok" CssClass="button" runat="server" Text="提交" OnClick="btn_ok_Click" />
                            </div>
                            <div class="div" style="text-align: left">
                                <asp:Button ID="btn_back" CssClass="button" runat="server" Text="取消" OnClick="btn_back_Click" OnClientClick="javascript:return confirm('你确定要退出注册吗？您的记录将不保存！')"/>
                            </div>
                        </div>
                    </div>
            </form>
</body>
</html>
