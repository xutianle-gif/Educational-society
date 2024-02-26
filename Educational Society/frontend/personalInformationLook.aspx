<%@ Page Title="" Language="C#" MasterPageFile="~/frontend/Personal.Master" AutoEventWireup="true" CodeBehind="personalInformationLook.aspx.cs" Inherits="Educational_Society.frontend.personalInformationLook" %>

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
                        <asp:label id="txtCompany" runat="server" cssclass="textboxcss" />
                    </td>
                </tr>
                <tr class="tatr">
                    <td class="td1">单位法人：
                    </td>
                    <td>
                        <asp:label id="txtlegalperson" runat="server" cssclass="textboxcss" />
                    </td>

                </tr>
                <tr class="tatr">
                    <td class="td1">所在地区：
                    </td>
                    <td>
                        <asp:label cssclass="drop" id="dpl1" runat="server" autopostback="true"/>
                        <asp:label cssclass="drop" id="dpl2" runat="server" autopostback="true"/>
                    </td>
                </tr>
                <tr class="tatr">
                    <td class="td1">详细地址：
                    </td>
                    <td>
                        <asp:label id="txtLocationAddress" runat="server" cssclass="textboxcss" />
                    </td>

                </tr>
                <tr class="tatr">
                    <td class="td1">营业执照或<br />
                        法人证书：
                    </td>
                    <td>
                       
                        <img src="../img/加.png" id="pic" class="add1" runat="server" style=" height: 134px;" />
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
                        <asp:label id="txtContantPeopleName" runat="server" cssclass="textboxcss" />
                    </td>
                </tr>
                <tr class="tatr">
                    <td class="td1">联系电话：
                    </td>
                    <td>
                        <asp:label id="txtContantPeopleTel" runat="server" cssclass="textboxcss" />
                    </td>

                </tr>
                <tr class="tatr">
                    <td class="td1">电子邮箱：
                    </td>
                    <td>
                        <asp:label id="txtContantPeopleEmail" runat="server" cssclass="textboxcss" />
                    </td>

                </tr>
                <tr class="tatr">
                    <td class="td1">联系人身份证<br />
                        （正面、反面）：
                    </td>
                    <td>
                        
                        <img src="../img/加.png" id="pic2" class="add1" runat="server" style=" height: 134px;" />
                    </td>
                    <td>
                        
                        <img src="../img/加.png" id="pic3" class="add1" runat="server" style=" height: 134px;" />
                    </td>
                    <tr class="tatr">
                        <td class="td1">联系人手持<br />
                            身份证照片：
                        </td>
                        <td>
                            
                            <img src="../img/加.png" id="pic4" class="add1" runat="server" style=" height: 134px;" />
                        </td>

                    </tr>
                </tr>
                <tr class="tatr">
                    <td></td>
                    <td>
                        <asp:button text="修改" runat="server" id="btnConfirm" cssclass="btn" onclick="btnConfirm_Click"/>
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
