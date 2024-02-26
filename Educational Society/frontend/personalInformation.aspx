<%@ Page Title="" Language="C#" MasterPageFile="~/frontend/Personal.Master" AutoEventWireup="true" CodeBehind="personalInformation.aspx.cs" Inherits="Educational_Society.frontend.personalInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../style/personalInformation.css" rel="stylesheet" />
    <script src="../js/jquery.js"></script>
    <script src="../js/zoom.js"></script>
    <script>
        $(function () {
            var obj = new zoom('mask', 'bigimg', 'pic');
            obj.init();
        })
    </script>
    <div id="basic">

        <div id="basictable">
            <div class="tb_title">单位基本信息</div>
            <table class="tb_user">
                <tr class="tatr">
                    <td class="td1">单位名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompany" runat="server" CssClass="textboxcss" /></td>
                </tr>
                <tr class="tatr">
                    <td class="td1">单位法人：
                    </td>
                    <td>
                        <asp:TextBox ID="txtlegalperson" runat="server" CssClass="textboxcss" /></td>

                </tr>
                <tr class="tatr">
                    <td class="td1">所在地区：
                    </td>
                    <td>
                        <asp:DropDownList CssClass="drop" ID="dpl1" runat="server" OnSelectedIndexChanged="dpl1_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:DropDownList CssClass="drop" ID="dpl2" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="tatr">
                    <td class="td1">详细地址：
                    </td>
                    <td>
                        <asp:TextBox ID="txtLocationAddress" runat="server" CssClass="textboxcss" /></td>

                </tr>
                <tr class="tatr">
                    <td class="td1">营业执照或<br />
                        法人证书：
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" onchange="javascript:__doPostBack('ctl00$ContentPlaceHolder1$lbUploadPhoto1','')" runat="server" Style="border-style: none; border-color: inherit; border-width: 0; width: 134px; height: 134px; color: rgba(0,0,0,0); outline: none; opacity: 0; position: absolute;" />
                        <asp:LinkButton ID="lbUploadPhoto1" OnClick="lbUploadPhoto1_Click" runat="server"></asp:LinkButton>
                        <img src="../img/加.png" id="pic" class="add1" runat="server" style="width:134px;height: 134px;"/>
                        <%-- <asp:FileUpload ID="FileUpload1" runat="server" Visible="false" /><asp:Button ID="btnloadCompany" runat="server" Text="上传" Visible="false" OnClick="btnloadCompany_Click" style="height: 21px"/>
                        <br />
                        
                        <asp:Image ID="Image1" CssClass="pic" runat="server" Width="100px" Height="100px" />
                        <asp:Button ID="btnLoadlegal" runat="server" CssClass="btn_2" Text="重新上传" CausesValidation="false" OnClick="btnLoadlegal_Click" />--%>
                    </td>

                </tr>
            </table>
            <div class="tb_title">联系人基本信息</div>
            <table class="tb_user">
                <tr class="tatr">
                    <td class="td1">联系人姓名：
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtContantPeopleName" runat="server" CssClass="textboxcss" /></td>
                </tr>
                <tr class="tatr">
                    <td class="td1">联系电话：
                    </td>
                    <td>
                        <asp:TextBox ID="txtContantPeopleTel" runat="server" CssClass="textboxcss" /></td>

                </tr>
                <tr class="tatr">
                    <td class="td1">电子邮箱：
                    </td>
                    <td>
                        <asp:TextBox ID="txtContantPeopleEmail" runat="server" CssClass="textboxcss" /></td>

                </tr>
                <tr class="tatr">
                    <td class="td1">联系人身份证<br />
                        （正面、反面）：
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload2" onchange="javascript:__doPostBack('ctl00$ContentPlaceHolder1$lbUploadPhoto2','')" runat="server" Style="border-style: none; border-color: inherit; border-width: 0; width: 134px; height: 134px; color: rgba(0,0,0,0); outline: none; opacity: 0; position: absolute;"/><asp:LinkButton ID="lbUploadPhoto2" OnClick="lbUploadPhoto2_Click" runat="server"></asp:LinkButton>
                        <img src="../img/加.png" id="pic2" class="add1" runat="server" style="width:134px;height: 134px;"/>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload3" onchange="javascript:__doPostBack('ctl00$ContentPlaceHolder1$lbUploadPhoto3','')" runat="server" Style="border-style: none; border-color: inherit; border-width: 0; width: 134px; height: 134px; color: rgba(0,0,0,0); outline: none; opacity: 0; position: absolute;"/><asp:LinkButton ID="lbUploadPhoto3" OnClick="lbUploadPhoto3_Click" runat="server"></asp:LinkButton>
                        <img src="../img/加.png" id="pic3" class="add1" runat="server" style="width:134px;height: 134px;"/>
                    </td>
                    <tr class="tatr">
                        <td class="td1">联系人手持<br />
                            身份证照片：
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload4" onchange="javascript:__doPostBack('ctl00$ContentPlaceHolder1$lbUploadPhoto4','')" runat="server" Style="border-style: none; border-color: inherit; border-width: 0; width: 134px; height: 134px; color: rgba(0,0,0,0); outline: none; opacity: 0; position: absolute;"/><asp:LinkButton ID="lbUploadPhoto4" OnClick="lbUploadPhoto4_Click" runat="server"></asp:LinkButton>
                            <img src="../img/加.png" id="pic4" class="add1" runat="server" style="width:134px;height: 134px;"/>
                        </td>

                    </tr>
                </tr>
                <tr class="tatr">
                    <td></td>
                    <td>
                        <asp:Button Text="确定" runat="server" ID="btnConfirm" CssClass="btn" OnClick="btnConfirm_Click" />

                        <asp:Button Text="返回" runat="server" ID="btnback" CssClass="btn" OnClick="btnback_Click"/>
                    </td>
                </tr>
            </table>
        </div>
        <img src="" alt="" class="bigimg" />
        <div class="mask">
            <img src="img/close.png" alt="" />
        </div>
    </div>
</asp:Content>
