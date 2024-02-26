<%@ Page Title="" Language="C#" MasterPageFile="~/backend/backmon.Master" AutoEventWireup="true" CodeBehind="useredit.aspx.cs" Inherits="Educational_Society.backend.useredit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="../style/userpass.css" rel="stylesheet" />
    <script src="../js/jquery.js"></script>
    <script src="../js/zoom.js"></script>
    <script>
        $(function () {
            var obj = new zoom('mask', 'bigimg', 'pic');
            obj.init();
        })
</script>
    <style type="text/css">
    .back_user {
    text-shadow: 3px 3px 20px #ffac66;
    color: #757575;
    background-color: #ddd;
    border-left: 5px solid #666;
    box-shadow: 0px 0px 20px 0px #ddd;
    }
    </style>
    <div id="body">
    <div id="content">
        <div id="title">
            当前位置：<asp:Label ID="Label1" runat="server" Text="Label">新入会会员管理-详情</asp:Label>
        </div>
        <div class="tb_title">单位基本信息</div>
        <table class="tb_user">
            <tr>
                <td class="td1">单位名称：</td>
                <td class="td2"><asp:Label ID="lb_name" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">单位法人：</td>
                <td class="td2"><asp:Label ID="lb_fname" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">申请类型：</td>
                <td class="td2"><asp:Label ID="lb_unit" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">所在地区：</td>
                <td class="td2"><asp:Label ID="lb_address" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">详细地址：</td>
                <td class="td2"><asp:Label ID="lb_address2" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">营业执照或法人证书：</td>
                <td class="td2">
                        <asp:Image ID="img1" CssClass="pic" runat="server" ImageUrl="/img/1.jpg" />       
                 </td>
            </tr>
        </table>
        <div class="tb_title">联系人基本信息</div>
        <table class="tb_user">
            <tr>
                <td class="td1">联系人姓名：</td>
                <td class="td2"><asp:Label ID="lb_tname" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">联系人电话：</td>
                <td class="td2"><asp:Label ID="lb_tel" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">电子邮件：</td>
                <td class="td2"><asp:Label ID="lb_email" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">联系人身份证<br />（正面、反面）：</td>
                <td class="td2"><asp:Image ID="img2" CssClass="pic" runat="server"  ImageUrl="/img/1.jpg" /><asp:Image ID="img3" CssClass="pic" runat="server"  ImageUrl="/img/1.jpg" /></td>
            </tr>
            <tr>
                <td class="td1">联系人手持身份证照片：</td>
                <td class="td2"><asp:Image ID="img4" CssClass="pic" runat="server"  ImageUrl="/img/1.jpg" /></td>
            </tr>
            <tr>
                <td class="td1"></td>
                <td class="td2">
                    <asp:Button ID="btn_ok" CssClass="btn" runat="server" Text="冻结" OnClick="btn_ok_Click" />
                    <asp:Button ID="btn_back" CssClass="btn" runat="server" Text="返回" OnClick="btn_back_Click" />
                </td>
            </tr>
        </table>
        <img src="" alt="" class="bigimg" />
        <div class="mask">
	    <img src="img/close.png" alt="" />
        </div>
    </div>
    </div>
</asp:Content>
