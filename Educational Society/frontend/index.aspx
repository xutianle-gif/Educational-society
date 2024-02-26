<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Educational_Society.frontend.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery.js"></script>
    <script src="../js/index.js"></script>
    <link href="../style/indexCss.css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" runat="server">
        <div id="content">
            <div id="header">
                <div class="hd">
                    <button type="button" class="hd_btn" id="hd1"><font class="zchy">章程</font></button></div>
                <div class="hd">
                    <button type="button" class="hd_btn" id="hd2"><font class="zchy">会员条件</font></button></div>
                <div class="hd">
                    <asp:Button ID="hd3" CssClass="hd_btn" runat="server" Text="我要申请" OnClick="hd3_Click" /></div>
            </div>
            <div class="arthd" id="art_hd1">
                <div class="divart">
                    <span>中国职业技术教育学会入会流程</span><br />
                    <span>根据《中国职业技术教育学会章程》的有关规定，中国职业技术教育学会(以下简称“学会)实行单位会员和个人会员制。申请加入本会的单位和个人应按照以下程序办理入会手续。</span><br />
                    <span>1.申请加入学会的单位，可向学会秘书处或学会某- 分支机构提出申请，办理入会手续。申请单位需填写《中国职业技术教育学会单位会员申请
            表》，提供申请单位法人登记证书或相关证件复印件(扫描件可直接上传到网上)申请表可从中国职业技术教育网(www. chinazy.org)“入会申请”上
            下载。目前暂不接收个人会员。
                    </span>
                    <br />
                    <span>2.入会申请受理后，由学会秘书处汇总，报常务理事会或理事会讨论通过。</span><br />
                    <span>3.常务理事会或理事会每年分上半年和下半年两次讨论入会申请。讨论通过的名单在学会网站上公布。</span><br />
                    <span>4.入会申请获得批准后的单位会员，由学会颁发《中国职业技术教育学会单位会员证书》; 个人会员由学会颁发《中国职业技术教育学会会员证》。会费标准:</span><br />
                    <span>经中国职业技术教育学会第五次会员代表大会审议，并表决通过了《关于修改中国职业技术教育学会会费标准的报告》，会费标准为:</span><br />
                    <span>1.常务理事单位每年缴纳会费20000元;</span><br />
                    <span>2.理事单位每年缴纳会费1000元;</span><br />
                    <span>3.单位会员每年缴纳会费3000元;</span><br />
                    <span>4.个人会员(院士、青年科学家等)暂不缴纳会费。</span><br />
                    <span>(按照民政部关于“分支机构不得单独制定会费标准"的规定，所有分支机构发展的单位会员一律按照学会规定的会费标准缴纳会费。)</span>
                </div>
            </div>
            <div class="arthd" id="art_hd2">
                <div class="divart">
                    <span style="font-weight: bold">当前位置：章程</span><br />
                    <span>中国职业技术教育学会章程</span><br />
                    <span>第一章总则</span><br />
                    <span>第-条本会名称为中国职业技术教育学会(英文全称为THE CHINESE SOCIETY FOR TECHNICAL AND VOCATIONAL EDUCATION,缩写为
              CSTVE)。 
                    </span>
                    <br />
                    <span>第三条本会的宗旨是:以马克思列宁主义、毛泽东思想邓小平理论、“三个代表重要思想科学发展观和习近平新时代中国特色社会主义思想为指导
              思想和行动指南;始终坚持党的领导，全面贯彻党的教育方针，围绕中心、服务大局、紧贴基层:坚持政治强会、学术立会、服务兴会、依法治会:团
              化。遵循职业技术教育规律和“百花齐放，百家争鸣”的方针,开展学术活动，恪守学术道德，建设新时代新型中国职业技术教育学会，为实现两个- -百
              本会坚持党的全面领导，根据中国共产党章程的规定，设立中国共产党的组织，开展党的活动，为党组织的活动提供必要条件。
              年”奋斗目标和中华民族伟大复兴的中国梦做出应有的贡献。
                    </span>
                    <br />
                    <span>本会坚持党的全面领导，根据中国共产党章程的规定，设立中国共产党的组织，开展党的活动，为党组织的活动提供必要条件。</span><br />
                    <span>本会遵守宪法、法律、法规和国家政策，践行社会主义核心价值观，遵守社会道德风尚。</span><br />
                    <span>第四条本会接受业务主管单位中华人民共和国教育部和社团登记管理机关民政部的业务指导和监督管理。</span><br />
                    <span>第五条本会的住所在北京市。</span><br />
                   
                </div>
            </div>
            <div class="arthd" id="art_hd3">
                <div class="divart">
                    <span style="font-weight: bold">当前位置:会员条件</span><br />
                    <span>中国职业技术教育学会会员条件</span><br />
                    <span>本会实行单位会员和个人会员制。</span><br />
                    <span>1.单位会员应具备法人资格，包括在省级民政部1门]登记的职业技术教育学会:与职业技术教育相关的行业教育学会;从事或开展职业技术教育的各级
              各类职业学校和其他高等院校;职业技术教育科学研究机构和其他教育机构;职业技术教育的管理、服务机构;举办、参与职业教育和培训的企业、社
              会组织、事业单位等机构。
                    </span>
                    <br />
                    <span>2.个人会员是指各级各类职业学校和其他高等院校中从事职业技术教育的人员;职业技术教育科学研究机构和其他职业技术教育机构的人员;职业技
              术教育的管理、服务机构的人员;以及其他社会组织、行业、企事业单位的人员。
                    </span>
                    <br />
                    <span>申请加入本会的会员，必须具备下列基本条件:</span><br />
                    <span>1.中华人民共和国公民;</span><br />
                    <span>2.拥护中国共产党的领导，全面贯彻党的教育方针;</span><br />
                    <span>3.自愿加入本会，拥护本会章程;</span><br />
                    <span>4.愿意参与职业技术教育科学研究和改革实践活动;</span><br />
                    <span>5.在职业技术教育科学研究和实践中具有一定影响。</span><br />
                    <span>本会会员享有下列权利: </span>
                    <br />
                    <span>1.本会的选举权、被选举权和表决权;</span>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
