<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_New.aspx.cs" Inherits="AppBox.apps.Project.Project_New" %>
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
                                <f:TextBox ID="tbxName" Width="480px" runat="server" Label="项目名称" Required="true" ShowRedStar="true">
                                </f:TextBox>                                
                            </Items>
                        </f:FormRow>
                        <f:FormRow runat="server">
                            <Items>
                                 <f:TextBox ID="txtDomain" Width="480px" runat="server" Label="域名" Required="true" ShowRedStar="true">
                                </f:TextBox>                
                            </Items>
                        </f:FormRow>      
                        <f:FormRow runat="server">
                            <Items>
                                 <f:TriggerBox ID="tbSelectedDept" EnableEdit="false" Required="true" EnablePostBack="false" TriggerIcon="Search"
                                    Label="所属部门" runat="server">
                                </f:TriggerBox>                
                            </Items>
                        </f:FormRow>      
                        <f:FormRow runat="server">
                            <Items>
                                <f:DatePicker ID="txtStartTime" Width="480px" runat="server" Label="开始时间" Required="true" ShowRedStar="true">
                                </f:DatePicker>                
                            </Items>
                        </f:FormRow>  
                        <f:FormRow runat="server">
                            <Items>
                                 <f:DatePicker ID="txtEndTime" Width="480px" runat="server" Label="结束时间" Required="true" ShowRedStar="true">
                                </f:DatePicker>                
                            </Items>
                        </f:FormRow>                      
                        <f:FormRow runat="server">
                            <Items>
                                <f:TextBox ID="txtOwner" Width="480px" runat="server" Label="项目负责人" Required="true" ShowRedStar="true">
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
