using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Linq;
using System.Data.Entity;
using EntityFramework.Extensions;
using System.Data.Entity.Infrastructure;

namespace AppBox.apps.Plan
{
    public partial class PlanFlow : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            // 权限检查
            // CheckPowerWithButton("AppScriptEdit", btnChangeEnableScripts);

            // 每页记录数
            Grid1.PageSize = ConfigHelper.PageSize;
            ddlGridPageSize1.SelectedValue = ConfigHelper.PageSize.ToString();
            Grid2.PageSize = ConfigHelper.PageSize;
            ddlGridPageSize2.SelectedValue = ConfigHelper.PageSize.ToString();
            BindGrid();
        }
        private void BindGrid()
        {
            BindGrid1();
            BindGrid2();
        }
        private void BindGrid1()
        {
            IQueryable<AppBox.Flow> q = DB.Flows; //.Include(u => u.Dept);

            // 在用户名称中搜索
            string searchText = ttbSearchMessage.Text.Trim();
            if (!String.IsNullOrEmpty(searchText))
            {
                q = q.Where(u => u.Name.Contains(searchText));
            }
            q = q.Where(u => u.Enabled == true);

            // 在查询添加之后，排序和分页之前获取总记录数
            Grid1.RecordCount = q.Count();

            // 排列和数据库分页
            q = SortAndPage<AppBox.Flow>(q, Grid1);

            Grid1.DataSource = q;
            Grid1.DataBind();
        }
        private void BindGrid2()
        {
            int id = GetQueryIntValue("id");
            AppBox.Plan q = DB.Plans.Include(r => r.Flows)
               .Where(r => r.ID == id)
               .FirstOrDefault();
            IQueryable<AppBox.Flow> x = q.Flows.AsQueryable();
            // 在查询添加之后，排序和分页之前获取总记录数
            Grid2.RecordCount = x.Count();

            // 排列和数据库分页
            x = SortAndPage<AppBox.Flow>(x, Grid2);

            Grid2.DataSource = x;
            Grid2.DataBind();
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void Left_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid1);

            int id = GetQueryIntValue("id");

            AppBox.Plan plan = DB.Plans.Include(r => r.Flows)
                 .Where(r => r.ID == id)
                 .FirstOrDefault();

            foreach (int flowID in ids)
            {
                AppBox.Flow flow = Attach<AppBox.Flow>(flowID);
                plan.Flows.Add(flow);
            }
            DB.SaveChanges();

            BindGrid2();
        }

        protected void Right_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid2);

            int id = GetQueryIntValue("id");

            AppBox.Plan plan = DB.Plans.Include(r => r.Flows)
                 .Where(r => r.ID == id)
                 .FirstOrDefault();

            foreach (int flowID in ids)
            {
                AppBox.Flow flow = Attach<AppBox.Flow>(flowID);
                plan.Flows.Remove(flow);
            }
            DB.SaveChanges();

            BindGrid2();
        }
    }
}