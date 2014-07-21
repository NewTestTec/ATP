<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Script_New.aspx.cs" Inherits="AppBox.apps.Script.Script_New" %>
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
                                <f:TextBox ID="tbxName" runat="server" Label="脚本名" Required="true" ShowRedStar="true">
                                </f:TextBox>                                
                            </Items>
                        </f:FormRow>
                       <%-- <f:FormRow runat="server">
                            <Items>
                                <f:TextBox ID="tbxPath" runat="server" Label="路径" Required="true" ShowRedStar="true">
                                </f:TextBox>                                
                            </Items>
                        </f:FormRow>--%>
                        <f:FormRow runat="server">
                            <Items>
                                <f:DropDownList ID="ddProject" runat="server" Label="项目" Required="true" ShowRedStar="true">
                                </f:DropDownList>
                              
                            </Items>
                        </f:FormRow>
                        <f:FormRow runat="server">
                            <Items>
                               <%--  <f:DropDownList ID="ddVersion" runat="server" Label="版本" Required="true" ShowRedStar="true">
                                </f:DropDownList>       --%>     
                                 <f:TextBox ID="txtVersion" runat="server" Label="版本" Required="true" ShowRedStar="true">
                                </f:TextBox>                
                            </Items>
                        </f:FormRow>
                       
                        <f:FormRow runat="server">
                            <Items>
                                <f:TextBox ID="tbxCreater" runat="server" Label="创建者" Required="true" ShowRedStar="true">
                                </f:TextBox>                                
                            </Items>
                        </f:FormRow>
                        <f:FormRow runat="server">
                            <Items>
                                <f:RadioButtonList ID="ddlLanguage" Label="语言" Required="true" ShowRedStar="true" runat="server">
                                    <f:RadioItem Text="VBS" Value="VBS" />
                                    <f:RadioItem Text="Selenium" Value="Selenium" />
                                </f:RadioButtonList>
                                <f:CheckBox ID="cbxEnabled" runat="server" Label="是否启用">
                                </f:CheckBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow runat="server">
                            <Items>
                               <f:FileUpload ID="Upload" Required="true"  runat="server" Label="请选择要上传的脚本文件（.zip）">
                                </f:FileUpload>
                               
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

    </form>
</body>
</html>
