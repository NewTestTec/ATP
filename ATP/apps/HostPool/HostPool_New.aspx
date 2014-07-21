<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HostPool_New.aspx.cs" Inherits="AppBox.apps.HostPool.HostPool_New" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" ShowBorder="false" ShowHeader="false"  AutoScroll="true" runat="server">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                            Text="关闭">
                        </f:Button>
                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                        </f:ToolbarSeparator>
                        <f:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose" OnClick="btnSaveClose_Click"
                            runat="server" Text="保存后关闭">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
                     Title="SimpleForm">
                    <Rows>
                        <f:FormRow runat="server">
                            <Items>
                                <f:TextBox ID="tbxName" runat="server" Label="Host主机名" Required="true" ShowRedStar="true">
                                </f:TextBox>                                
                            </Items>
                        </f:FormRow>
                        <f:FormRow runat="server">
                            <Items>
                               <%--  <f:DropDownList ID="ddVersion" runat="server" Label="版本" Required="true" ShowRedStar="true">
                                </f:DropDownList>       --%>     
                                 <f:TextBox ID="txtIP" runat="server" Label="IP地址" Required="true" ShowRedStar="true" Regex="^(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[0-9]{1,2})(\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[0-9]{1,2})){3}$">
                                </f:TextBox>                
                            </Items>
                        </f:FormRow>                      
                        <f:FormRow runat="server">
                            <Items>
                                <f:TextBox ID="tbxResorces" runat="server" Label="主机配置" Required="true" ShowRedStar="true">
                                </f:TextBox>                                
                            </Items>
                        </f:FormRow>
                        <f:FormRow runat="server">
                            <Items>
                                <f:TextBox ID="TextOS" runat="server" Label="平台类型" Required="true" ShowRedStar="true">
                                </f:TextBox>                                
                            </Items>
                        </f:FormRow>
                        <f:FormRow runat="server">
                            <Items>
                                <f:TextBox ID="txtAppVersion" runat="server" Label="自动化测试组件版本" Required="true" ShowRedStar="true">
                                </f:TextBox>                                
                            </Items>
                        </f:FormRow>
                        <f:FormRow runat="server">
                            <Items>
                                
                                <f:CheckBox ID="cbxEnabled" runat="server" Label="是否启用">
                                </f:CheckBox>
                            </Items>
                        </f:FormRow>
                        
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
       
        <f:Window ID="Window1" Title="编辑" Hidden="true" EnableIFrame="true" runat="server"
            EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="550px"
            Height="350px">
        </f:Window>

        <f:HiddenField ID="hfSelectedDept" runat="server">
        </f:HiddenField>
    </form>
</body>
</html>
