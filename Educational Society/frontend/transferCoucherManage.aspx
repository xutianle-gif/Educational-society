<%@ Page Title="" Language="C#" MasterPageFile="~/frontend/Personal.Master" AutoEventWireup="true" CodeBehind="transferCoucherManage.aspx.cs" Inherits="Educational_Society.frontend.transferCoucherManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../style/transferCoucherManage.css" rel="stylesheet" />
    <%--<script src="../js/jquery-1.6.js"></script>--%>
    <script src="../js/jquery.js"></script>
    <script src="../js/transferCoucherManage.js"></script>
    <script type="text/javascript">
        //function previewcheck() {
        //    //var value = this.class;
           
        //    //$(".bigimg").attr('src', value);
        //    //$(".mask").show();
        //    //$("#bigg").show();
            
        //    return false;
        //}
        //function uploading()
        //{
        //    $("#content2").fadeIn(400);
        //    return false;
        //}
    </script>
    <div id="content2" runat="server">
        <div id="new_year">
            <div id="new_title">上传缴费凭证</div>
            <div style="padding-left: 35px; margin-bottom: 15px">
                <asp:Label Text="缴费编号：" runat="server" /><asp:Label ID="lblYear" Text="" runat="server" />
            </div>
            <div style="width: 400px;">
                <asp:FileUpload ID="FileUpload1" onchange="javascript:__doPostBack('ctl00$ContentPlaceHolder1$lbUploadPhoto','')" Style="border-style: none; border-color: inherit; border-width: 0; width: 400px; height: 400px; color: rgba(0,0,0,0); outline: none; opacity: 0; position: absolute; top: 101px; left: 200px;"
                    runat="server" />
                <asp:LinkButton ID="lbUploadPhoto" OnClick="lbUploadPhoto_Click" runat="server"></asp:LinkButton>
                <img src="../img/加.png" id="pic" class="add1" runat="server" />
                <%-- <asp:Image ID="Image1" ImageUrl="/img/1.jpg" runat="server" />--%>
            </div>
            <div class="new_div">
                <asp:Button ID="btn_add" CssClass="new_btn" runat="server" Text="提交" OnClick="btn_add_Click" />
            </div>
            <div class="new_div">
                <asp:Button ID="btnback" runat="server" Text="取消" class="new_btn" Style="float: left; margin-left: 30px; line-height: 40px;" OnClick="btnback_Click" />
            </div>
        </div>
    </div>
    <div id="passwordControl">
        <div>
            转账凭证管理
        </div>
        <div class="divide"></div>
    </div>

    <div id="content" style="margin-top: 30px">
        <div class="contentcontrol">
            <span>缴费年份:</span><asp:DropDownList ID="dplYear" CssClass="drop" runat="server"></asp:DropDownList><asp:Button ID="btnSearch" runat="server" Text="查询" class="btn" OnClick="btnSearch_Click" />
            <div>
                <table id="tb_menu">
                    <tr>
                        <td style="width: 10%">序号</td>
                        <td style="width: 10%">缴费年份</td>
                        <td style="width: 13%">单位负责人</td>
                        <td style="width: 13%">缴费金额</td>
                        <td style="width: 18%">缴费状态</td>
                        <td style="width: 18%">退回原因</td>
                        <td>操作</td>
                    </tr>
                </table>
                <asp:GridView ID="ltvDetails" runat="server" OnPagePropertiesChanging="ltvDetails_PagePropertiesChanging" AutoGenerateColumns="False" Style="text-align: center; width: 100%;height:40px;    margin-top: 5px;" ShowHeader="false" GridLines="None" OnRowCommand="ltvDetails_RowCommand">
                    <EmptyDataTemplate>
                        <div>
                            <h1 style="color: red; text-align: center;">暂无数据</h1>
                        </div>
                    </EmptyDataTemplate>
                    <Columns>

                        <asp:BoundField DataField="xuhao" ItemStyle-Width="10%" />
                        <asp:TemplateField ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lblpayyear" runat="server" Text='<%# Eval ("payyear") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Unitmanager" ItemStyle-Width="13%" />
                        <asp:BoundField DataField="paymoney" ItemStyle-Width="13%" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblPaymentStatus" runat="server" Text='<%# Eval ("voucherstatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="details" ItemStyle-Width="18%" />
                        <asp:TemplateField ItemStyle-Width="18%">
                            <ItemTemplate>
                                <%--    <div id="div1" style="display: none" class="div1" runat="server">--%>
                                <asp:LinkButton ID="lbupload" runat="server" Style="color: #000; text-decoration: none;" CommandName="qwer" CommandArgument='<%# Eval ("payid") %>'>上传转账凭证</asp:LinkButton>
                                <%--<span id='<%#Eval("voucherid") %>' class="upload">上传转账凭证</span></div>--%>
                                <asp:LinkButton ID="lblook" runat="server" CommandName="btnlookit" CommandArgument='<%#Eval("voucherimg").ToString() %>' OnClientClick="return previewcheck();" Style="color: #000; text-decoration: none;">预览转账凭证</asp:LinkButton>
                                <asp:LinkButton ID="lbxian" runat="server" Text="|" Style="color: #000; text-decoration: none;" />
                                <asp:LinkButton ID="lbdownload" CommandName="download" CommandArgument='<%#Eval("voucherid") %>' runat="server" Text="下载" Style="color: #000; text-decoration: none;" />
                                <%-- <div id="div2" style="display: none" class="div2" runat="server">--%>
                                <%--    <asp:Image ID="Image2" CssClass="pic" ImageUrl='<%#Eval("voucherimg") %>' runat="server" /><span id='<%#Eval("voucherimg").ToString() %>' class="getpic">预览转账凭证</span>|<asp:Button CommandName="download" CommandArgument='<%#Eval("voucherid") %>' CssClass="btn_download" OnCommand="Button2_Command" ID="Button2" runat="server" Text="下载" />--%>
                                <%--  </div>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--  <asp:ListView runat="server" ID="ltvDetails" OnPagePropertiesChanging="ltvDetails_PagePropertiesChanging" class="tb_user">
                    <EmptyDataTemplate>
                        <div>
                            <h1 style="color: red; text-align: center;">暂无数据</h1>
                        </div>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <table id="tb_user" class="tb_user">
                            <tr>
                                <td style="width: 10%"><%# Container.DataItemIndex + 1%></td>
                                <td style="width: 10%"><%#Eval("payyear") %></td>
                                <td style="width: 13%"><%#Eval("Unitmanager") %></td>
                                <td style="width: 13%"><%#Eval("payyear") %></td>
                                <td style="width: 18%"><%#Eval("voucherstatus") %></td>
                                <td style="width: 18%"><%#Eval("details") %></td>
                                <td>
                                    <span class="span" id="span" style="display: none"><%#Eval("voucherstatus") %></span>
                                    <div id="div3" class="div3" runat="server">鼠标悬浮查看</div>
                                    <div id="div1" style="display: none" class="div1" runat="server"><span id='<%#Eval("voucherid") %>' class="upload">上传转账凭证</span></div>
                                    <div id="div2" style="display: none" class="div2" runat="server">
                                        <asp:Image ID="Image2" CssClass="pic" ImageUrl='<%#Eval("voucherimg") %>' runat="server" /><span id='<%#Eval("voucherimg").ToString() %>' class="getpic">预览转账凭证</span>|<asp:Button CommandName="download" CommandArgument='<%#Eval("voucherid") %>' CssClass="btn_download" OnCommand="Button2_Command" ID="Button2" runat="server" Text="下载" /></div>
                                </td>

                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:ListView>--%>
                <div id="pre" class="pre" style="text-align: center">
                    <%--<asp:DataPager ID="DataPager1" runat="server" PagedControlID="ltvDetails" PageSize="10">
                        <Fields>
                            <asp:NextPreviousPagerField />
                            <asp:NumericPagerField ButtonType="Button" />
                        </Fields>
                    </asp:DataPager>--%>
                </div>
            </div>
        </div>
    </div>
    <img src="" id="bigg" alt="" class="bigimg" runat="server"/>
    <div id="masks" class="mask" runat="server">
    </div>
</asp:Content>
