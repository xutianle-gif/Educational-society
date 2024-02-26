<%@ Page Title="" Language="C#" MasterPageFile="~/backend/backmon.Master" AutoEventWireup="true" CodeBehind="userpass.aspx.cs" Inherits="Educational_Society.backend.userpass" %>

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
        .back_index {
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
                当前位置：<asp:label id="Label1" runat="server" text="Label">新入会会员管理-详情</asp:label>
            </div>
            <div class="tb_title">单位基本信息</div>
            <table class="tb_user">
                <tr>
                    <td class="td1">单位名称：</td>
                    <td class="td2">
                        <asp:label id="lb_name" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="td1">单位法人：</td>
                    <td class="td2">
                        <asp:label id="lb_fname" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="td1">申请类型：</td>
                    <td class="td2">
                        <asp:label id="lb_unit" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="td1">所在地区：</td>
                    <td class="td2">
                        <asp:label id="lb_address" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="td1">详细地址：</td>
                    <td class="td2">
                        <asp:label id="lb_address2" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="td1">营业执照或法人证书：</td>
                    <td class="td2">
                        <asp:image id="img1" cssclass="pic" runat="server" imageurl="/img/1.jpg" />
                    </td>
                </tr>
            </table>
            <div class="tb_title">联系人基本信息</div>
            <table class="tb_user">
                <tr>
                    <td class="td1">联系人姓名：</td>
                    <td class="td2">
                        <asp:label id="lb_tname" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="td1">联系人电话：</td>
                    <td class="td2">
                        <asp:label id="lb_tel" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="td1">电子邮件：</td>
                    <td class="td2">
                        <asp:label id="lb_email" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="td1">联系人身份证<br />
                        （正面、反面）：</td>
                    <td class="td2">
                        <asp:image id="img2" cssclass="pic" runat="server" imageurl="/img/1.jpg" />
                        <asp:image id="img3" cssclass="pic" runat="server" imageurl="/img/1.jpg" />
                    </td>
                </tr>
                <tr>
                    <td class="td1">联系人手持身份证照片：</td>
                    <td class="td2">
                        <asp:image id="img4" cssclass="pic" runat="server" imageurl="/img/1.jpg" />
                    </td>
                </tr>
                <tr>
                    <td class="td1">审核结果：</td>
                    <td class="td2">
                        <asp:radiobutton id="rb1" checked="true" cssclass="rb" runat="server" groupname="pass" text="通过" autopostback="True" OnCheckedChanged="rb1_CheckedChanged" />
                        <asp:radiobutton id="rb2" groupname="pass" cssclass="rb" runat="server" text="驳回" autopostback="True" oncheckedchanged="rb2_CheckedChanged" />
                    </td>
                </tr>
                <tr id="tr_back" visible="false" runat="server">
                    <td class="td1">驳回原因：</td>
                    <td class="td2">
                        <textarea id="txt_back" runat="server" style="width: 450px; height: 100px; resize: none" cols="20" rows="2"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="td1"></td>
                    <td class="td2">
                        <asp:button id="btn_ok" cssclass="btn" runat="server" text="确定" onclick="btn_ok_Click" />
                        <asp:button id="btn_back" cssclass="btn" runat="server" text="返回" onclick="btn_back_Click" />
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
