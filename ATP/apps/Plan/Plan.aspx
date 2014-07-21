<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Plan.aspx.cs" Inherits="AppBox.apps.Plan.Plan" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" BodyPadding="5px"  
            ShowBorder="false" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start"
            ShowHeader="false" Title="计划管理">
            <Items>
                <f:Form ID="Form2" runat="server" Height="36px" BodyPadding="5px" ShowHeader="false"
                    ShowBorder="false" LabelAlign="Right" >
                    <Rows>
                        <f:FormRow ID="FormRow1" runat="server">
                            <Items>
                                <f:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="在计划名称中搜索"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false">
                                </f:TwinTriggerBox>   
                                <f:RadioButtonList ID="rblEnableStatus" AutoPostBack="true" 
                                    Label="启用状态" ColumnNumber="3" runat="server">
                                    <f:RadioItem Text="全部" Selected="true" Value="all" />
                                    <f:RadioItem Text="启用" Value="enabled" />
                                    <f:RadioItem Text="禁用" Value="disabled" />
                                </f:RadioButtonList>                            
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                    EnableCheckBoxSelect="true" 
                    DataKeyNames="ID" AllowSorting="true" SortField="Name"
                    SortDirection="DESC" AllowPaging="true" IsDatabasePaging="true" >
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                               <%-- <f:Button ID="btnDeleteSelected" Icon="Delete" runat="server" Text="删除选中记录" OnClick="btnDeleteSelected_Click">
                                </f:Button>--%>
                                 <f:Button ID="btnDeleteSelected" Icon="Delete" runat="server" Text="删除选中记录" >
                                </f:Button>
                                <f:ToolbarSeparator runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="btnChangeEnableScripts" Icon="GroupEdit" EnablePostBack="false" runat="server"
                                    Text="设置启用状态">
                                    <Menu runat="server">
                                        <f:MenuButton ID="btnEnableScripts" runat="server" Text="启用选中记录">
                                        </f:MenuButton>
                                        <f:MenuButton ID="btnDisableScripts" runat="server"
                                            Text="禁用选中记录">
                                        </f:MenuButton>
                                    </Menu>
                                </f:Button>
                                <f:ToolbarFill ID="ToolbarFill1" runat="server">
                                </f:ToolbarFill>
                                <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="新增计划">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <PageItems>
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </f:ToolbarSeparator>
                        <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数：">
                        </f:ToolbarText>
                       <%-- <f:DropDownList ID="ddlGridPageSize" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="ddlGridPageSize_SelectedIndexChanged"
                            runat="server">--%>
                         <f:DropDownList ID="ddlGridPageSize" Width="80px" AutoPostBack="true"                            runat="server">
                            <f:ListItem Text="10" Value="10" />
                            <f:ListItem Text="20" Value="20" />
                            <f:ListItem Text="50" Value="50" />
                            <f:ListItem Text="100" Value="100" />
                        </f:DropDownList>
                    </PageItems>
                    <Columns>
                        <f:RowNumberField Width="35px" EnablePagingNumber="true" />
                        <f:BoundField DataField="Name" SortField="Name" Width="100px" HeaderText="计划名" />                       
                        <f:BoundField DataField="Project" SortField="Project" Width="100px" HeaderText="所属项目" />
                        <f:BoundField DataField="Version" SortField="Version" Width="100px" HeaderText="版本" />
                        <f:BoundField DataField="ModifyTime" SortField="ModifyTime" ExpandUnusedSpace="true" HeaderText="修改时间" />
                        <f:CheckBoxField DataField="Enabled" SortField="Enabled" HeaderText="启用" RenderAsStaticField="true"
                            Width="50px" />
                        <f:WindowField TextAlign="Center" Icon="Information" ToolTip="查看详细信息" Title="查看详细信息"
                            WindowID="Window1" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="~/apps/Plan/Plan_View.aspx?id={0}"
                            Width="50px" />
                        
                        <f:WindowField ColumnID="editField" TextAlign="Center" Icon="Pencil" ToolTip="编辑"
                            WindowID="Window1" Title="编辑" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="~/apps/Plan/Plan_Edit.aspx?id={0}"
                            Width="50px" />
                        <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ToolTip="删除"
                            ConfirmText="确定删除此记录？" ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                         <f:WindowField ColumnID="editField1" TextAlign="Center" Icon="ApplicationEdit" ToolTip="编辑对应流程"
                            WindowID="Window1" Title="编辑对应流程" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="~/apps/Plan/PlanFlow.aspx?id={0}"
                            Width="50px" />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" runat="server" IsModal="true" Hidden="true" Target="Top" EnableResize="true"
            EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank" Width="650px"
            Height="450px"  OnClose="Window1_Close">
        </f:Window>
    </form>

</body>
</html>
