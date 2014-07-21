<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Script_View.aspx.cs" Inherits="AppBox.apps.Script.Script_View" %>
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
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="Form2" ShowBorder="false" ShowHeader="false"  runat="server" BodyPadding="10px"
                    Title="SimpleForm" LabelAlign="Left">
                    <Rows>
                        <f:FormRow ID="FormRow1" runat="server">
                            <Items>
                                <f:Label ID="labName" runat="server" Label="脚本名">
                                </f:Label>                                
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow4" runat="server">
                            <Items>
                               <f:Label ID="labPath" runat="server" Label="路径">
                                </f:Label>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow2" runat="server">
                            <Items>
                               <f:Label ID="labProject" runat="server" Label="所属项目">
                                </f:Label>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow7" runat="server">
                            <Items>
                               <f:Label ID="labVersion" runat="server" Label="版本">
                                </f:Label>
                            </Items>
                        </f:FormRow>
                       <%-- <f:FormRow ID="FormRow2" runat="server">
                            <Items>
                                <f:TextArea ID="labContent" runat="server" Label="内容" Readonly="true" Height="240">
                                </f:TextArea>                                
                            </Items>
                        </f:FormRow>--%>
                         <f:FormRow ID="FormRow5" runat="server">
                            <Items>
                               <f:Label ID="labEnabled" runat="server" Label="是否启用">
                                </f:Label>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow3" runat="server">
                            <Items>
                                <f:Label ID="labCreater" runat="server" Label="创建者">
                                </f:Label>                                
                            </Items>
                        </f:FormRow>
                         <f:FormRow ID="FormRow6" runat="server">
                            <Items>
                                <f:Label ID="labLanguage" runat="server" Label="语言">
                                </f:Label>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow9" runat="server">
                            <Items>
                                <f:Label ID="labModifyDate" runat="server" Label="修改时间">
                                </f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
