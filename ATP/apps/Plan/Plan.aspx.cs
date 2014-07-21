using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data.Entity;
using FineUI;
using EntityFramework.Extensions;

namespace AppBox.apps.Plan
{
    public partial class Plan : PageBase
    {
        #region ViewPower

        //<summary>
        //本页面的浏览权限，空字符串表示本页面不受权限控制
        //</summary>
        public override string ViewPower
        {
            get
            {
                return "AppPlanView";
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        protected void Window1_Close(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void LoadData()
        {
            // 权限检查
            //CheckPowerWithButton("AppScriptEdit", btnChangeEnableScripts);
            //CheckPowerWithButton("AppScriptDelete", btnDeleteSelected);
            //CheckPowerWithButton("AppScriptNew", btnNew);

            ResolveDeleteButtonForGrid(btnDeleteSelected, Grid1);

            ResolveEnableStatusButtonForGrid(btnEnableScripts, Grid1, true);
            ResolveEnableStatusButtonForGrid(btnDisableScripts, Grid1, false);

            btnNew.OnClientClick = Window1.GetShowReference("~/apps/Plan/Plan_New.aspx", "新增计划");

            // 每页记录数
            Grid1.PageSize = ConfigHelper.PageSize;
            ddlGridPageSize.SelectedValue = ConfigHelper.PageSize.ToString();

            BindGrid();
        }
        private void BindGrid()
        {
            IQueryable<AppBox.Plan> q = DB.Plans;

            // 在用户名称中搜索
            string searchText = ttbSearchMessage.Text.Trim();
            if (!String.IsNullOrEmpty(searchText))
            {
                q = q.Where(u => u.Name.Contains(searchText));
            }

            // 过滤启用状态
            if (rblEnableStatus.SelectedValue != "all")
            {
                q = q.Where(u => u.Enabled == (rblEnableStatus.SelectedValue == "enabled" ? true : false));
            }

            // 在查询添加之后，排序和分页之前获取总记录数
            Grid1.RecordCount = q.Count();

            // 排列和数据库分页
            q = SortAndPage<AppBox.Plan>(q, Grid1);

            Grid1.DataSource = q;
            Grid1.DataBind();
        }
    }
}