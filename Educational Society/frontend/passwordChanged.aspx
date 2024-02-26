<%@ Page Title="" Language="C#" MasterPageFile="~/frontend/Personal.Master" AutoEventWireup="true" CodeBehind="passwordChanged.aspx.cs" Inherits="Educational_Society.frontend.passwordChanged" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <link href="../style/passwordChangedCss.css" rel="stylesheet" />
    <div id="passwordControl">
        <div>
            修改密码
        </div>
        <div class="divide"></div>
    </div>
    <div id="content" style="margin-top: 25px;">
        <table id="tb_user" style="line-height:50px">
          
            <tr class="tatr">
                <td class="td1">
                    原密码：
                </td>
                <td class="td2">
                    <asp:textbox id="txtfirst" runat="server" class="textboxcss" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="必须输入原密码！" ForeColor="Red" ControlToValidate="txtfirst"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr class="tatr">
                <td class="td1">
                    新密码：
                </td>
                <td class="td2">
                    <asp:textbox id="txtNewpassword" runat="server" class="textboxcss" TextMode="Password" />
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="必须输入新密码！" ForeColor="Red" ControlToValidate="txtNewpassword"></asp:RequiredFieldValidator>
               
                </td>

            </tr>
            <tr class="tatr">
                <td class="td1">
                    重复新密码：
                </td>
                <td class="td2">
                    <asp:textbox id="txtRepeatNewpassword" runat="server" class="textboxcss" TextMode="Password" />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewpassword" ControlToValidate="txtRepeatNewpassword" ErrorMessage="CompareValidator" ForeColor="Red">两次密码不一致!</asp:CompareValidator>
                </td>

            </tr>
            <tr class="tatr">
                <td class="auto-style1"></td>
                <td  class="td2">
                    <asp:button text="修改" runat="server" id="btnConfirm" class="btn" OnClick="btnConfirm_Click" />

                   
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
