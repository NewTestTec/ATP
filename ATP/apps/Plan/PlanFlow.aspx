<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanFlow.aspx.cs" Inherits="AppBox.apps.Plan.PlanFlow" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        
            <f:Panel ID="Panel1" runat="server"  ShowBorder="True" EnableFrame="true"
              Layout="HBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start" BoxConfigPadding="5"
              BoxConfigChildMargin="0 5 0 0" ShowHeader="false" >  
                <Toolbars>
                <f:Toolbar ID="Toolbar2" runat="server">
                    <Items>
                       
                        <f:Button ID="btnConfirm" ValidateForms="SimpleForm1" Icon="SystemSaveClose" OnClick="btnConfirm_Click"
                            runat="server" Text="关闭">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
                <Items>
                   <f:Panel ID="Panel6" Title="面板1" BoxFlex="1" runat="server"
                        BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                        <Items>
                            <f:Grid ID="Grid2" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                                EnableCheckBoxSelect="true" 
                                DataKeyNames="ID" AllowSorting="true" SortField="Name"
                                SortDirection="DESC" AllowPaging="true" IsDatabasePaging="true" >
                               
                                <PageItems>
                                    <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                    </f:ToolbarSeparator>
                                    <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数：">
                                    </f:ToolbarText>
                             
                                     <f:DropDownList ID="ddlGridPageSize2" Width="80px" AutoPostBack="true"                            runat="server">
                                        <f:ListItem Text="10" Value="10" />
                                        <f:ListItem Text="20" Value="20" />
                                        <f:ListItem Text="50" Value="50" />
                                        <f:ListItem Text="100" Value="100" />
                                    </f:DropDownList>
                                </PageItems>
                                <Columns>
                                    <%--<f:RowNumberField Width="15px" EnablePagingNumber="true" ID="ctl14" ColumnID="Panel1_Grid1_ctl14" />--%>
                                    <f:BoundField DataField="Name" SortField="Name" Width="100px" HeaderText="流程名" />
                       
                                    <f:WindowField ColumnID="Up" TextAlign="Center" Icon="ArrowUp" ToolTip="向上排序"
                                    WindowID="Window1" Title="↑" DataIFrameUrlFields="ID" 
                                    Width="20px" />
                                    <f:WindowField ColumnID="Down" TextAlign="Center" Icon="ArrowDown" ToolTip="向下排序"
                                    WindowID="Window1" Title="↓" DataIFrameUrlFields="ID" 
                                    Width="20px" />
                                </Columns>
                            </f:Grid>
                     
                        </Items>
                     </f:Panel>
                     
                    <f:Panel ID="Panel2" Title="面板2" Width="50px"  Layout="Vbox" BoxConfigAlign="Center"
                        runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false">
                        <Items>
                            <f:Button ID="Left" Text="<<" runat="server" OnClick="Left_Click"></f:Button>
                       
                            <f:Button ID="Right" Text=">>" runat="server" OnClick="Right_Click"></f:Button>
                        </Items>
                    </f:Panel>
                    <f:Panel ID="Panel3" Title="面板3" BoxFlex="3" runat="server"
                        BodyPadding="5px" BoxMargin="0" ShowBorder="true" ShowHeader="false">
                        <Items>
                            <f:Form ID="Form2" runat="server" Height="36px" BodyPadding="5px" ShowHeader="false"
                            ShowBorder="false" LabelAlign="Right" >
                                <Rows>
                                    <f:FormRow ID="FormRow1" runat="server">
                                        <Items>
                                            <f:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="在脚本名称中搜索"
                                                Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false">
                                            </f:TwinTriggerBox>   
                                        </Items>
                                    </f:FormRow>
                                </Rows>
                            </f:Form>
                                        
                            <f:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                            EnableCheckBoxSelect="true" 
                            DataKeyNames="ID" AllowSorting="true" SortField="Name"
                            SortDirection="DESC" AllowPaging="true" IsDatabasePaging="true" >
                
                                <PageItems>
                                    <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                    </f:ToolbarSeparator>
                                    <f:ToolbarText ID="ToolbarText2" runat="server" Text="每页记录数：">
                                    </f:ToolbarText>
                  
                                        <f:DropDownList ID="ddlGridPageSize1" Width="80px" AutoPostBack="true" runat="server">
                                        <f:ListItem Text="10" Value="10" />
                                        <f:ListItem Text="20" Value="20" />
                                        <f:ListItem Text="50" Value="50" />
                                        <f:ListItem Text="100" Value="100" />
                                    </f:DropDownList>
                                </PageItems>
                                <Columns>
                                    <f:RowNumberField Width="35px" EnablePagingNumber="true" />
                                    <f:BoundField DataField="Name" SortField="Name" Width="100px" HeaderText="流程名" />
                                    <f:BoundField DataField="Project" SortField="Project" Width="100px" HeaderText="所属项目" />
                                    <f:BoundField DataField="Version" SortField="Version" Width="100px" HeaderText="版本" />
                                    <f:BoundField DataField="Creater" SortField="Creater" Width="100px"  HeaderText="创建者" />
                                    <f:BoundField DataField="ModifyTime" SortField="ModifyTime" ExpandUnusedSpace="true" HeaderText="修改时间" />
                                </Columns>
                            </f:Grid>
                        </Items>   
                    </f:Panel>
                </Items>
            </f:Panel>
         <f:Window ID="Window1" Title="编辑" Hidden="true" EnableIFrame="true" runat="server"
            EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="550px"
            Height="350px">
        </f:Window>
    </form>

</body>
</html>
